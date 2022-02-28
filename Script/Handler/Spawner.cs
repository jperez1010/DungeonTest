using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Handler
{
    public class Spawner : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject[] mythomorphPrefabs;
        public GameObject playerPrefab;
        public MYTHOMORPH_FIELD_CONDITION condition;

        public CameraController cameraController;

        public GameObject[] onFieldGameObjects;
        public int onField;
        private int teamSize;
        public int currentTeamIndex = 0;

        void Start()
        {
            teamSize = mythomorphPrefabs.Length;
            onFieldGameObjects = new GameObject[teamSize];
            SpawnPlayer();
            SetCamaraTarget(0);
        }

        private void SetCamaraTarget(int i)
        {
            cameraController.player = onFieldGameObjects[i];
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (onFieldGameObjects[currentTeamIndex] && condition != MYTHOMORPH_FIELD_CONDITION.PLAYER)
                {
                    ReturnMythomorph();
                }
                else
                {
                    SpawnMythomorph();
                }
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                currentTeamIndex += 1;
                currentTeamIndex %= teamSize;
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                currentTeamIndex -= 1 - teamSize;
                currentTeamIndex %= teamSize;
            }
        }
        private void ReturnMythomorph()
        {
            switch (condition)
            {
                case MYTHOMORPH_FIELD_CONDITION.ONE:
                    Vector3 playerTransform = onFieldGameObjects[currentTeamIndex].transform.position;
                    Destroy(onFieldGameObjects[currentTeamIndex]);
                    GameObject spawn = Instantiate(playerPrefab, playerTransform, Quaternion.identity);
                    onFieldGameObjects[0] = spawn;
                    condition = MYTHOMORPH_FIELD_CONDITION.PLAYER;
                    break;
                case MYTHOMORPH_FIELD_CONDITION.TWO:
                    Destroy(onFieldGameObjects[currentTeamIndex]);
                    onFieldGameObjects[currentTeamIndex] = null;
                    condition = MYTHOMORPH_FIELD_CONDITION.ONE;
                    break;
                case MYTHOMORPH_FIELD_CONDITION.THREE:
                    Destroy(onFieldGameObjects[currentTeamIndex]);
                    onFieldGameObjects[currentTeamIndex] = null;
                    condition = MYTHOMORPH_FIELD_CONDITION.TWO;
                    break;
                case MYTHOMORPH_FIELD_CONDITION.FOUR:
                    Destroy(onFieldGameObjects[currentTeamIndex]);
                    onFieldGameObjects[currentTeamIndex] = null;
                    condition = MYTHOMORPH_FIELD_CONDITION.THREE;
                    break;
            }
            SetCamaraTarget(0);
        }
        private void SpawnMythomorph()
        {
            Vector3 position = new Vector3();
            GameObject obj;
            double angle;

            switch (condition)
            {
                case MYTHOMORPH_FIELD_CONDITION.PLAYER:
                    Destroy(onFieldGameObjects[0]);
                    onFieldGameObjects[0] = null;
                    condition = MYTHOMORPH_FIELD_CONDITION.ONE;
                    break;
                case MYTHOMORPH_FIELD_CONDITION.ONE:
                    angle = (Math.PI / 180.0) * (transform.rotation.eulerAngles.y + 180);
                    position = 2 * new Vector3((float)Math.Sin(angle), 0f, (float)Math.Cos(angle));
                    condition = MYTHOMORPH_FIELD_CONDITION.TWO;
                    break;
                case MYTHOMORPH_FIELD_CONDITION.TWO:
                    angle = (Math.PI / 180.0) * (transform.rotation.eulerAngles.y + 180);
                    position = 4 * new Vector3((float)Math.Sin(angle), 0f, (float)Math.Cos(angle));
                    condition = MYTHOMORPH_FIELD_CONDITION.THREE;
                    break;
                case MYTHOMORPH_FIELD_CONDITION.THREE:
                    angle = (Math.PI / 180.0) * (transform.rotation.eulerAngles.y + 180);
                    position = 6 * new Vector3((float)Math.Sin(angle), 0f, (float)Math.Cos(angle));
                    condition = MYTHOMORPH_FIELD_CONDITION.FOUR;
                    break;
            }
            obj = Instantiate(mythomorphPrefabs[currentTeamIndex], position, Quaternion.identity);
            onFieldGameObjects[currentTeamIndex] = obj;
            onField += 1;
            SetCamaraTarget(0);
        }

        public int GetTeamIndex()
        {
            return currentTeamIndex;
        }

        public void SpawnPlayer()
        {
            onFieldGameObjects[0] = Instantiate(playerPrefab);
            condition = MYTHOMORPH_FIELD_CONDITION.PLAYER;
        }
    }

    public enum MYTHOMORPH_FIELD_CONDITION
    {
        PLAYER, ONE, TWO, THREE, FOUR
    }
}