using Assets.Scripts.Game.Board;
using Assets.Scripts.Game.Grid;
using Assets.Scripts.Game.HexCell;
using Assets.Scripts.Inputs;
using Assets.Scripts.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts.DI
{

    [Serializable]
    public struct HexPrefabMapping
    {
        public LandscapeTypes landscapeType;
        public GameObject prefab;
    }

    public class GameScope : LifetimeScope
    {
        //[SerializeField] private GameObject hexPrefab;
        [SerializeField] private HexPrefabMapping[] hexPrefabMappings;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("Configure");

            //builder.RegisterInstance(hexPrefab).As<GameObject>();

            var prefabMap = new Dictionary<LandscapeTypes, GameObject>();
            foreach (var mapping in hexPrefabMappings)
            {
                if (mapping.prefab != null)
                    prefabMap[mapping.landscapeType] = mapping.prefab;
            }

            builder.RegisterInstance(prefabMap);


            builder.Register<HexLogic>(Lifetime.Transient);

            builder.Register<HexGrid>(Lifetime.Scoped);

            builder.Register<HexSpawner>(Lifetime.Singleton);
            builder.Register<GameDebug>(Lifetime.Singleton);
            builder.Register<CameraControl>(Lifetime.Singleton);
            builder.Register<InputReader>(Lifetime.Singleton);
            builder.Register<HexInteractions>(Lifetime.Singleton);


            builder.RegisterComponentInHierarchy<Board>();
            builder.RegisterComponentInHierarchy<MapEditor>();

        }


    }
}