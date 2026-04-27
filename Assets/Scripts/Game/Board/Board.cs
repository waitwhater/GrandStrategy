using Assets.Scripts.Game.Grid;
using Assets.Scripts.Game.HexCell;
using Assets.Scripts.Inputs;
using Assets.Scripts.Tools;
using System;
using System.Collections;
using UnityEngine;
using VContainer;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Game.Board
{
    public class Board : MonoBehaviour
    {
        [SerializeField] private bool _isDebugging;

        private HexGrid _hexGrid;
        private GameDebug _gameDebug;
        private CameraControl _cameraControl;
        private InputReader _inputReader;


        void Start()
        {
            Debug.Log("Start");
            _hexGrid.FillGrid(this.transform);
            _cameraControl.SetupCamera(_hexGrid.Width, _hexGrid.Height); //потом переделать - на точку спавна
            _inputReader = new InputReader();
            _inputReader.EnableInputs(true);
            _inputReader.Click += HandleInput;

            if (_isDebugging)
                _gameDebug.ShowDebug();
        }

        private void HandleInput()
        {
            Ray inputRay = _cameraControl.Cam.ScreenPointToRay(_inputReader.Position());
            RaycastHit hit;
            if (Physics.Raycast(inputRay, out hit))
            {
                TouchCell(hit.collider.gameObject);
            }
        }

        private void TouchCell(GameObject hex)
        {
            Debug.Log($"touch at {hex.GetComponent<Hex>().hexCoordinates.ToString()}");
            hex.GetComponent<Hex>().SetColor();//прикола ради
        }

        private void OnDisable()
        {
            _inputReader.Click -= HandleInput;
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