using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Projekt.Scripts.System.Auras
{
    public class MomentumAura : IAura
    {
        private float timer;

        public MomentumAura(float duration)
        {
            timer = duration;
        }

        public void OnApply(PlayerController player)
        {
            UnityEngine.Debug.Log("Momentum ON");
        }

        public void Tick(PlayerController player, float deltaTime)
        {
            timer -= deltaTime;

            if (timer <= 0f)
            {
                player.GetComponent<AuraController>().RemoveAura(this);
            }
        }

        public void OnRemove(PlayerController player)
        {
            UnityEngine.Debug.Log("Momentum OFF");
        }
    }
}
