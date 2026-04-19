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
        [Inject] private Func<Hex> hexFactory;

        public void CreateHex(int widthPos, int heightPos)
        {
            UnityEngine.Vector3 position;
            position.x = widthPos * 10f;
            position.y = 0f;
            position.z = heightPos * 10f;

            Hex hex = hexFactory();

            hex.transform.position = position;
            hex.gameObject.SetActive(true);
        }

    }
}
