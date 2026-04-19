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
        public Hex[,] GridHexes { get; private set; }

        [Inject] private HexSpawner hexSpawner;


        public HexGrid(/*int width, int height*/)
        {
            Width = 6;
            Height = 6;
            GridHexes = new Hex[Width, Height];
        }

        public void FillGrid ()
        {
            for (int i = 0; i < GridHexes.GetLength(0); i++)
                for (int j = 0; j < GridHexes.GetLength(1); j++)
                {
                    GridHexes[i, j] = hexSpawner.CreateHex();
                    hexSpawner.SetupHex(i, j, GridHexes[i, j]);
                }
        }

    }
}