using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mythomorph
{
    public class Stats {

        public static Stats PLAYER = new Stats("Player", 0, 1, 0);
        public static Stats VERGIC = new Stats("Player", 1, 10, 15);

        public string name;
        public string nickname;
        public int level;
        public int base_health;
        public int base_attack;
        public int health;
        public int attack;
        //public moves

        public Stats(string name, string nickname, int level, int base_health, int base_attack)
        {
            this.name = name;
            this.nickname = nickname;
            this.level = level;
            this.base_health = base_health;
            this.base_attack = base_attack;
            this.DetermineStats();
        }

        public Stats(string name, int level, int health, int attack) : this(name, name, level, health, attack) {}

        public void SetLevel(int level)
        {
            this.level = level;
            DetermineStats();
        }

        private void DetermineStats()
        {
            health = 10 * base_health * level;
            attack = 3 * base_attack * level;
        }
    }
}