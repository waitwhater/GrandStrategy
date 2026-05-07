using Assets.Scripts.Tools;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Game.HexCell
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Hex : MonoBehaviour
    {
        [SerializeField] public HexLogic hexLogic;

        /*
        public HexCoordinates hexCoordinates; //как будто это полный бред делать координаты публичными
        
        [SerializeField] private LandscapeTypes landscapeType;
        
        public int OffsetWidth { get ; set ; }
        public int OffsetHeight { get ; set ; }
        public int IndexInGrid { get ; set ; }

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
                        this.SetColor(Color.darkGreen);
                        break;
                    case LandscapeTypes.Plain:
                        this.SetColor(Color.saddleBrown);
                        break;
                    case LandscapeTypes.Desert:
                        this.SetColor(Color.darkKhaki);
                        break;
                    case LandscapeTypes.Tundra:
                        this.SetColor(Color.darkGray);
                        break;
                    case LandscapeTypes.Snow:
                        this.SetColor(Color.snow);
                        break;
                    default:
                        this.SetColor(Color.magenta);
                        break;
                }
                landscapeType = value;
            }
        }
        */
        public void OnDestroy()
        {
            hexLogic = null;
            this.gameObject.SetActive(false);

        }

        public Vector3 GetHexWorldPosition() => this.transform.position;

        public void SetColor(Color color)
        {
            this.GetComponent<MeshRenderer>().material.color = color;
        }
    }
}
