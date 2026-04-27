using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Inputs
{
    public class InputReader : IDisposable
    {
        public event Action Click;
        private Inputs _inputs;

        public Inputs Inputs { get => _inputs; }

        public InputReader()
        {
            _inputs = new Inputs();
            _inputs.Player.Attack.performed += OnClick;
        }

        public void EnableInputs()
        {
            _inputs.Enable();
        }

        private void OnClick(InputAction.CallbackContext context)
        {
            Click?.Invoke();
        }

        public void Dispose()
        {
            _inputs.Player.Attack.performed -= OnClick;
        }

        public Vector2 Position()
        {
            //var mousePos = _inputs.Player.Look.ReadValue<Vector2>();
            var mousePos = Pointer.current?.position.ReadValue() ?? Vector2.zero; 
            //наверное тут стоило бы обращаться к сгенерированному c# классу,
            //для этого нужно в юнити в инпутс добавить новый ввод с Position(Pointer).
            //Пока используем это
            return mousePos;
        }
    }
}
