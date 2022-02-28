using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Handler
{
    public class IconDisplayer : MonoBehaviour
    {
        public Spawner spawner;
        public GameObject imageHolder;
        public Sprite[] images;
        private int teamIndex = 0;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (spawner.GetTeamIndex() != teamIndex)
            {
                teamIndex = spawner.GetTeamIndex();
                UpdateImage();
            }
        }

        void UpdateImage()
        {
            imageHolder.GetComponent<Image>().sprite = images[teamIndex];
        }
    }
}