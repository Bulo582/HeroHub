using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Projekt.Scripts.Core.Player
{
    public class PlayerStamina
    {
        public float Normalized => current / max;

        private float max;
        private float current;
        private float regenRate;
        private float regenDelay;
        private float regenTimer;

        public PlayerStamina(float max, float regenRate, float regenDelay)
        {
            this.max = max;
            this.regenRate = regenRate;
            this.regenDelay = regenDelay;
            current = max;
        }

        public bool CanSpend(float amount) => current >= amount;

        public void Spend(float amount)
        {
            current -= amount;
            regenTimer = regenDelay;
        }

        public void Tick(float deltaTime)
        {
            if (current >= max) return;

            if (regenTimer > 0f)
            {
                regenTimer -= deltaTime;
                return;
            }

            current = Mathf.Min(max, current + regenRate * deltaTime);
        }
    }
}
