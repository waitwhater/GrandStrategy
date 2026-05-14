using Assets.Scripts.Game.HexCell;
using Assets.Scripts.Tools;
using System.Collections;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Game.Grid
{
    public class HexGrid
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Hex[] Hexes { get; private set; }

        private readonly HexSpawner _hexSpawner;

        public HexGrid(HexSpawner hexSpawner)
        {
            _hexSpawner = hexSpawner;
        }

        public void FillGrid (Transform parent, int width, int height)
        {
            Width = width;
            Height = height;
            Hexes = new Hex[Width * Height];

            for (int x = 0, i = 0; x < Width; x++)
                for (int z = 0; z < Height; z++, i++)
                {
                    var newHexLogic = new HexLogic(HexMetrics.FromOffsetCoordinates(x, z), x, z, i);

                    Hexes[i] = _hexSpawner.CreateHex(parent, LandscapeTypes.Water, newHexLogic);
                    _hexSpawner.SetupHex(Hexes[i]);
                }

            Debug.Log($"Grid filled: {Width}x{Height}");
        }

    }
}