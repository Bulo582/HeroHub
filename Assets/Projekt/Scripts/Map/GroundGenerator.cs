using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Tilemaps;
using UnityEngine;

namespace Assets.Projekt.Scripts.Map
{
    public class GroundGenerator
    {
        private Tilemap tilemap;
        private TileBase baseTile;

        public GroundGenerator(Tilemap tilemap, TileBase baseTile)
        {
            this.tilemap = tilemap;
            this.baseTile = baseTile;
        }

        public void Generate(int width, int height)
        {
            for (int x = -width / 2; x < width / 2; x++)
            {
                for (int y = -height / 2; y < height / 2; y++)
                {
                    Debug.Log($"Placing tile at {x},{y}");
                    tilemap.SetTile(new Vector3Int(x, y, 0), baseTile);
                }
            }
        }
    }
}
