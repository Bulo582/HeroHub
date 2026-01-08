using Assets.Projekt.Scripts.System.Combat;
using Assets.Projekt.Scripts.System.Debug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Projekt.Scripts.Core.Player
{
    public class PlayerHealth : IDamageable
    {
        public int CurrentHP { get; private set; }

        public PlayerHealth(int startHp)
        {
            CurrentHP = startHp;
        }

        public void TakeDamage(DamageData damage)
        {
            CurrentHP -= damage.Amount;
            GameDebug.Log($"PLAYER TOOK {damage.Amount} DAMAGE | HP: {CurrentHP}");
        }
    }
}
