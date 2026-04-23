using Assets.Scripts.Tools;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Game.HexCell
{
    public class Hex : MonoBehaviour
    {
        public HexCoordinates hexCoordinates;

        public Vector3 GetHexWorldPosition() => this.transform.position;

    }
}
