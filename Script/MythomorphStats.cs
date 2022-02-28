using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myhtomorph { 
    public class MythomorphStats : MonoBehaviour
    {
        public string morphName;
        public int level;
        public int health;
        public int attack;
        //public moves

        public void DetermineStats()
        {
            level = 0;
            health = 100;
            attack = 12;
        }
    }
}