using Assets.Scripts.Tools;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Game.HexCell
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Hex : MonoBehaviour
    {
        public HexLogic hexLogic;

        public void OnDestroy()
        {
            hexLogic = null;
        }

        public Vector3 GetHexWorldPosition() => this.transform.position;

        public void SetColor(Color color)
        {
            this.GetComponent<MeshRenderer>().material.color = color;
        }
    }
}
