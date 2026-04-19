using Assets.Scripts.Game.Grid;
using Assets.Scripts.Game.HexCell;
using System.Collections;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Game.Board
{
    public class Board : MonoBehaviour
    {
        private HexGrid _hexGrid;

        void Start()
        {
            Debug.Log("Start");
            _hexGrid.FillGrid();
        }

        [Inject]
        public void Construct(HexGrid hexGrid)
        {
            _hexGrid = hexGrid;
        }

    }
}