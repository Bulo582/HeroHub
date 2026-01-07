using System.Collections.Generic;
using UnityEngine;

namespace Assets.Projekt.Scripts.System.Auras
{
    [RequireComponent(typeof(PlayerController))]
    public class AuraController : MonoBehaviour
    {
        private readonly List<IAura> activeAuras = new();
        private PlayerController player;

        private void Awake()
        {
            player = GetComponent<PlayerController>();
        }

        public void AddAura(IAura aura)
        {
            activeAuras.Add(aura);
            aura.OnApply(player);
        }

        public void RemoveAura(IAura aura)
        {
            aura.OnRemove(player);
            activeAuras.Remove(aura);
        }

        private void Update()
        {
            float dt = Time.deltaTime;

            for (int i = activeAuras.Count - 1; i >= 0; i--)
            {
                activeAuras[i].Tick(player, dt);
            }
        }
    }
}
