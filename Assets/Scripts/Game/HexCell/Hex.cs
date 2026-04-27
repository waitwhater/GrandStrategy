using Assets.Scripts.Tools;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Game.HexCell
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Hex : MonoBehaviour
    {
        public HexCoordinates hexCoordinates; //как будто это полный бред делать координаты публичными
        private LandscapeTypes landscapeType;
        //private bool isSelected;

        public LandscapeTypes LandscapeType
        {
            get => landscapeType;
            set
            {
                switch (value)
                {
                    case LandscapeTypes.Water:
                        this.SetColor(Color.blue);
                        break;
                    case LandscapeTypes.Grassland:
                        this.SetColor(Color.green);
                        break;
                    case LandscapeTypes.Plain:
                        this.SetColor(Color.brown);
                        break;
                    case LandscapeTypes.Desert:
                        this.SetColor(Color.yellow);
                        break;
                    case LandscapeTypes.Tundra:
                        this.SetColor(Color.grey);
                        break;
                    case LandscapeTypes.Snow:
                        this.SetColor(Color.lightGray);
                        break;

                        this.SetColor(Color.magenta);
                        break;
                }
                landscapeType = value;
            }
        }

        public Vector3 GetHexWorldPosition() => this.transform.position;

        public void SetColor(Color color)
        {
            this.GetComponent<MeshRenderer>().material.color = color;
        }
    }
}
