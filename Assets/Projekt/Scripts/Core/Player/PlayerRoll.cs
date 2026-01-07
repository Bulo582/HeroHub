using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Projekt.Scripts.Core.Player
{
    public class PlayerRoll
    {
        public bool IsRolling { get; private set; }
        public event Action OnPerfectDodge;

        private Rigidbody2D rb;
        private MonoBehaviour owner;

        private float speed;
        private float duration;
        private float cooldown;
        private float perfectWindow;

        private bool canRoll = true;
        private bool perfectActive;

        public PlayerRoll(
            Rigidbody2D rb,
            MonoBehaviour owner,
            float speed,
            float duration,
            float cooldown,
            float perfectWindow)
        {
            this.rb = rb;
            this.owner = owner;
            this.speed = speed;
            this.duration = duration;
            this.cooldown = cooldown;
            this.perfectWindow = perfectWindow;
        }

        public void TryRoll(Vector2 dir)
        {
            if (!canRoll || dir == Vector2.zero) return;
            owner.StartCoroutine(RollCoroutine(dir.normalized));
        }

        private IEnumerator RollCoroutine(Vector2 dir)
        {
            IsRolling = true;
            canRoll = false;
            perfectActive = true;

            yield return new WaitForSeconds(perfectWindow);
            perfectActive = false;

            float t = 0f;
            while (t < duration)
            {
                rb.velocity = dir * speed;
                t += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }

            rb.velocity = Vector2.zero;
            IsRolling = false;

            yield return new WaitForSeconds(cooldown);
            canRoll = true;
        }

        public void TryPerfectDodge()
        {
            if (perfectActive)
                OnPerfectDodge?.Invoke();
        }
    }
}
