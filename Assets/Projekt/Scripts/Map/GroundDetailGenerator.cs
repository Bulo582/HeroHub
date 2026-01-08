using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Tilemaps;
using UnityEngine;

namespace Assets.Projekt.Scripts.Map
{
    public class GroundDetailGenerator
    {
        private Tilemap tilemap;
        private TileBase[] detailTiles;
        private float chance;

        public GroundDetailGenerator(Tilemap tilemap, TileBase[] detailTiles, float chance)
        {
            this.tilemap = tilemap;
            this.detailTiles = detailTiles;
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
                        var tile = detailTiles[UnityEngine.Random.Range(0, detailTiles.Length)];
                        tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                    }
                }
            }
        }
    }
}
