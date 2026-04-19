using Assets.Scripts.Game.Grid;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts.Game.HexCell
{
    public class HexSpawner
    {
        private readonly GameObject _hexPrefab;
        private readonly IObjectResolver _resolver;

        public HexSpawner(GameObject gameObject, IObjectResolver objectResolver)
        {
            _hexPrefab = gameObject;
            _resolver = objectResolver;

            Debug.Log("HexSpawner created");

        }

        public Hex CreateHex()
        {
            return _resolver.Instantiate(_hexPrefab).GetComponent<Hex>();
        }

        public void SetupHex(int widthPos, int heightPos, Hex hex)
        {
            UnityEngine.Vector3 position;
            position.x = widthPos * 20f;
            position.y = 0f;
            position.z = heightPos * 20f;

            hex.transform.position = position;
            hex.gameObject.SetActive(true);
        }

    }
}
