using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Projekt.Scripts.Core.Player
{
    public class PlayerMovement
    {
        private Rigidbody2D rb;
        private float moveSpeed;

        public PlayerMovement(Rigidbody2D rb, float moveSpeed)
        {
            this.rb = rb;
            this.moveSpeed = moveSpeed;
        }

        public void Move(Vector2 input)
        {
            rb.velocity = input * moveSpeed;
        }

        public void Stop()
        {
            rb.velocity = Vector2.zero;
        }
    }
}
