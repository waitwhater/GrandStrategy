using Assets.Scripts.Tools;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Game.HexCell
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Hex : MonoBehaviour
    {
        public HexCoordinates hexCoordinates;

        public Vector3 GetHexWorldPosition() => this.transform.position;

        public void SetColor()
        {
            this.GetComponent<MeshRenderer>().material.color = Color.magenta;
        }
    }
}
