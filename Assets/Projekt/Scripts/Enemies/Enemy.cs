using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Projekt.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        public void OnHitPlayer(PlayerController player)
        {
            player.TryTakeHit();
        }
    }
}
