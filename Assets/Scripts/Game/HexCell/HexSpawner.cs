using Assets.Scripts.Game.Grid;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Game.HexCell
{
    public class HexSpawner
    {
        [Inject] private readonly Hex _hex;

        public HexSpawner(Hex hex)
        {
            _hex = hex;
            Debug.Log("hex spawner has been created");
        }

        public Hex CreateHex() => _hex;

        public void SetupHex(int widthPos, int heightPos, Hex hex)
        {
            UnityEngine.Vector3 position;
            position.x = widthPos * 10f;
            position.y = 0f;
            position.z = heightPos * 10f;

            hex.transform.position = position;
            hex.gameObject.SetActive(true);
        }

    }
}
