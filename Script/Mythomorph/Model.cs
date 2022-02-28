using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mythomorph
{
    public class Model
    {
        private static readonly string pathway = "Prefabs/Models/";
        public static Model PLAYER = new Model("Player");
        public static Model VERGIC = new Model("Vergic");
        // Add other models










        private readonly GameObject model;

        public Model(string name)
        {
            Debug.Log("attempting :" + pathway + name);
            model = Resources.Load(pathway + name) as GameObject;
        }

        public GameObject GetModel()
        {
            return model;
        }
    }
}