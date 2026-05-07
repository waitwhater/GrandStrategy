using Assets.Scripts.Game.Grid;
using Assets.Scripts.Game.HexCell;
using Assets.Scripts.Inputs;
using Assets.Scripts.Tools;
using System;
using System.Collections;
using UnityEngine;
using VContainer;
using UnityEngine.InputSystem;
using Assets.Scripts.Tools.Configs;

namespace Assets.Scripts.Game.Board
{
    public class Board : MonoBehaviour
    {
        [SerializeField] private GridConfig _gridConfig;
        [SerializeField] private bool _isDebugging;

        private HexGrid _hexGrid;
        private GameDebug _gameDebug;
        private CameraControl _cameraControl;
        private InputReader _inputReader;
        private HexInteractions _hexInteractions;

        public bool IsDebugging { get => _isDebugging; }

        void Start()
        {
            Debug.Log("Start");

            _hexGrid.FillGrid(this.transform, _gridConfig.Width, _gridConfig.Height);

            _cameraControl.SetupCamera(_hexGrid.Width, _hexGrid.Height); //потом переделать - на точку спавна
            _inputReader.EnableInputs();

            if (IsDebugging)
                _gameDebug.ShowDebugOnStart();
        }

        [Inject]
        public void Construct(HexGrid hexGrid, GameDebug gameDebug, CameraControl cameraControl, InputReader inputReader, HexInteractions hexInteractions)
        {
            _hexGrid = hexGrid;
            _gameDebug = gameDebug;
            _cameraControl = cameraControl;
            _inputReader = inputReader;
            _hexInteractions = hexInteractions;
        }

    }
}