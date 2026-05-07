using Assets.Scripts.Game.Grid;
using Assets.Scripts.Game.HexCell;
using Assets.Scripts.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace Assets.Scripts.Inputs
{
    public class HexInteractions : IDisposable
    {
        public event Action<Hex> HexInteraction;

        private InputReader _inputReader;
        private CameraControl _cameraControl;
       
        public HexInteractions(InputReader inputReader, CameraControl cameraControl)
        {
            _inputReader = inputReader;
            _cameraControl = cameraControl;
            _inputReader.Click += HandleInput;

            HexInteraction += TouchCell;
        }

        public void Dispose()
        {
            _inputReader.Click -= HandleInput;
            HexInteraction -= TouchCell;
        }

        private void HandleInput()
        {
            Ray inputRay = _cameraControl.Cam.ScreenPointToRay(_inputReader.Position());
            RaycastHit hit;
            if (Physics.Raycast(inputRay, out hit))
            {
                HexInteraction?.Invoke(hit.collider.gameObject.GetComponent<Hex>());
            }
        }

        private void TouchCell(Hex hex)
        {
            Debug.Log($"touch at {hex.hexLogic.HexCoordinates}");
        }
    }
}
