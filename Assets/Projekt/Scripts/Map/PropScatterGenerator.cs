using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Projekt.Scripts.Map
{
    public class PropScatterGenerator
    {
        private GameObject[] prefabs;
        private Transform parent;
        private float chance;

        public PropScatterGenerator(GameObject[] prefabs, Transform parent, float chance)
        {
            this.prefabs = prefabs;
            this.parent = parent;
            this.chance = chance;
        }

        public void Generate(int width, int height)
        {
            for (int x = -width / 2; x < width / 2; x++)
            {
                for (int y = -height / 2; y < height / 2; y++)
                {
                    if (UnityEngine.Random.value < chance)
                    {
                        var prefab = prefabs[UnityEngine.Random.Range(0, prefabs.Length)];
                        var pos = new Vector3(x + UnityEngine.Random.value, y + UnityEngine.Random.value, 0);
                        UnityEngine.Object.Instantiate(prefab, pos, Quaternion.identity, parent);
                    }
                }
            }
        }
    }
}
