using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mythomorph;

namespace Handler
{
    public class StageHandler : MonoBehaviour
    {
        public ArrayList onField;
        public GameObject prefab;

        void Start()
        {
            onField = new ArrayList();
            GameObject obj = SpawnMorph(MythomorphEnum.PLAYER, new BehaviorControlled());
            GameObject obj2 = SpawnMorph(MythomorphEnum.VERGIC, new BehaviorControlled());

        }

        private GameObject SpawnMorph(MythomorphEnum mythomorphEnum, Behavior behavior)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            obj.GetComponent<Mythomorph.Mythomorph>().Setup(mythomorphEnum);
            obj.GetComponent<Mythomorph.Mythomorph>().SetBehavior(behavior);
            obj.GetComponent<Mythomorph.Mythomorph>().SetHandler(this);
            GameObject model = Instantiate(obj.GetComponent<Mythomorph.Mythomorph>().model.GetModel());
            model.SetActive(false);
            model.transform.parent = obj.transform;
            model.SetActive(true);
            AddMorph(obj);
            obj.SetActive(true);
            return obj;
        }
        
        public void AddMorph(GameObject obj)
        {
            onField.Add(obj);
        }

        public void KillMorph(GameObject obj)
        {
            onField.Remove(obj);
            Destroy(obj);
        }
    }
}