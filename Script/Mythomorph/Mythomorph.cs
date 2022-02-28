using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Handler;

namespace Mythomorph
{
    public class Mythomorph : MonoBehaviour
    {
        public Model model;
        public Stats stats;
        public Behavior behavior;
        public StageHandler stageHandler;

        public void Setup(MythomorphEnum mythomotphEnum)
        {
            switch (mythomotphEnum)
            {
                case MythomorphEnum.PLAYER:
                    Setup(Model.PLAYER, Stats.PLAYER);
                    break;
                case MythomorphEnum.VERGIC:
                    Setup(Model.VERGIC, Stats.VERGIC);
                    break;
            }
        }

        public void Setup(Model model, Stats stats, Behavior behavior, StageHandler stageHandler)
        {
            this.model = model;
            this.stats = stats;
            this.behavior = behavior;
            this.stageHandler = stageHandler;
        }

        public void Setup(Model model, Stats stats)
        {
            this.Setup(model, stats, null, null);
        }

        public void SetBehavior(Behavior behavior)
        {
            this.behavior = behavior;
        }
        public void SetHandler(StageHandler stageHandler)
        {
            this.stageHandler = stageHandler;
        }    
    }

    public enum MythomorphEnum
    {
        PLAYER, VERGIC
    }
}
