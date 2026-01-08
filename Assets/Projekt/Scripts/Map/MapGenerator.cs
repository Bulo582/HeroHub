using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Tilemaps;
using UnityEngine;

namespace Assets.Projekt.Scripts.Map
{
    public class MapGenerator : MonoBehaviour
    {
        [Header("Map Size")]
        [SerializeField] private int width = 50;
        [SerializeField] private int height = 50;

        [Header("Ground")]
        [SerializeField] private Tilemap groundTilemap;
        [SerializeField] private TileBase groundTile;

        [Header("Ground Details")]
        [SerializeField] private Tilemap detailTilemap;
        [SerializeField] private TileBase[] detailTiles;
        [Range(0f, 1f)]
        [SerializeField] private float detailChance = 0.08f;

        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
            var groundGen = new GroundGenerator(groundTilemap, groundTile);
            groundGen.Generate(width, height);

            var detailGen = new GroundDetailGenerator(
                detailTilemap,
                detailTiles,
                detailChance
            );
            detailGen.Generate(width, height);
        }
    }
}
