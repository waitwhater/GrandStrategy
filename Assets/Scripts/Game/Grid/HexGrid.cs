using Assets.Scripts.Game.HexCell;
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

            Width = 6;
            Height = 6;
            Hexes = new Hex[Width * Height];
        }

        public void FillGrid (Transform parent)
        {
            for (int x = 0, i = 0; x < Width; x++)
                for (int z = 0; z < Height; z++, i++)
                {
                    Hexes[i] = _hexSpawner.CreateHex(parent);
                    _hexSpawner.SetupHex(x, z, Hexes[i]);
                }

            Debug.Log($"Grid filled: {Width}x{Height}");
        }

    }
}