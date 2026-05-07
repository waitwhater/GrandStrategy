using Assets.Scripts.Game.Grid;
using Assets.Scripts.Tools;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;
using static UnityEngine.Rendering.DebugUI;

namespace Assets.Scripts.Game.HexCell
{
    public class HexSpawner
    {
        //private readonly GameObject _hexPrefab;

        private readonly Dictionary<LandscapeTypes, GameObject> _landscapeTypesPrefabs;
        private readonly IObjectResolver _resolver;

        public HexSpawner(Dictionary<LandscapeTypes, GameObject> landscapeTypesPrefabs, IObjectResolver objectResolver)
        {
            _landscapeTypesPrefabs = landscapeTypesPrefabs;
            _resolver = objectResolver;

            Debug.Log("HexSpawner created");
        }

        public Hex CreateHex(Transform parent, LandscapeTypes landscape, HexLogic hexLogic)
        {
            if (_landscapeTypesPrefabs.TryGetValue(landscape, out GameObject type))
            {
                var hex = _resolver.Instantiate(type, parent).GetComponent<Hex>();
                hex.hexLogic = hexLogic;
                hexLogic.LandscapeType = landscape;
                return hex;
            }

            Debug.LogError("Landscape prefab is not found. Check GameScope fields");
            return null;
        }

        /*
        public void SetupHex(int widthPos, int heightPos, Hex hex)
        {
            UnityEngine.Vector3 position;
            position.x = (widthPos + heightPos * 0.5f - heightPos / 2) * (HexMetrics.innerRadius * 2f);
            position.y = 0f;
            position.z = heightPos * (HexMetrics.outerRadius * 1.5f);
            //hex.hexCoordinates = HexMetrics.FromOffsetCoordinates(widthPos, heightPos);

            //hex.LandscapeType = (LandscapeTypes)0;

            hex.transform.position = position;
            hex.gameObject.SetActive(true);
        }
        */
        public void SetupHex(Hex hex)
        {
            UnityEngine.Vector3 position;
            position.x = (hex.hexLogic.OffsetWidth + hex.hexLogic.OffsetHeight * 0.5f - hex.hexLogic.OffsetHeight / 2) * (HexMetrics.innerRadius * 2f);
            position.y = 0f;
            position.z = hex.hexLogic.OffsetHeight * (HexMetrics.outerRadius * 1.5f);

            hex.transform.position = position;

            switch (hex.hexLogic.LandscapeType)
            {
                case LandscapeTypes.Water:
                    hex.SetColor(Color.blue);
                    break;
                case LandscapeTypes.Grassland:
                    hex.SetColor(Color.darkGreen);
                    break;
                case LandscapeTypes.Plain:
                    hex.SetColor(Color.saddleBrown);
                    break;
                case LandscapeTypes.Desert:
                    hex.SetColor(Color.darkKhaki);
                    break;
                case LandscapeTypes.Tundra:
                    hex.SetColor(Color.darkGray);
                    break;
                case LandscapeTypes.Snow:
                    hex.SetColor(Color.snow);
                    break;
                default:
                    hex.SetColor(Color.magenta);
                    break;
            }

            hex.gameObject.SetActive(true);
        }



    }
    }
