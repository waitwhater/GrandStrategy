using Assets.Scripts.Game.Grid;
using Assets.Scripts.Game.HexCell;
using Assets.Scripts.Tools;
using System.Collections;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Game.Board
{
    public class Board : MonoBehaviour
    {
        [SerializeField] private bool _isDebugging;

        private HexGrid _hexGrid;
        private GameDebug _gameDebug;
        private CameraControl _cameraControl;

        void Start()
        {
            Debug.Log("Start");
            _hexGrid.FillGrid(this.transform);
            _cameraControl.SetupCamera(_hexGrid.Width, _hexGrid.Height); //переделать - на точку спавна

            if (_isDebugging)
                _gameDebug.ShowDebug();
        }

        [Inject]
        public void Construct(HexGrid hexGrid, GameDebug gameDebug, CameraControl cameraControl)
        {
            _hexGrid = hexGrid;
            _gameDebug = gameDebug;
            _cameraControl = cameraControl;
        }

    }
}