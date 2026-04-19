using Assets.Scripts.Game.Grid;
using Assets.Scripts.Game.HexCell;
using System.Collections;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Game.Board
{
    public class Board : MonoBehaviour
    {
        private HexGrid hexGrid;

        //[SerializeField] private int gridWidth;
        //[SerializeField] private int gridHeight;
        //[SerializeField] private HexGridConfig gridConfigure;


        void Start()
        {
            Debug.Log("Start");
            hexGrid.FillGrid();
        }


        [Inject]
        public void Construct(HexGrid mapGrid)
        {
            Debug.Log("Inject in Board");
            hexGrid = mapGrid;
        }
    }
}