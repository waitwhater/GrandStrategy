using Assets.Scripts.Game.Board;
using Assets.Scripts.Game.Grid;
using Assets.Scripts.Game.HexCell;
using Assets.Scripts.Inputs;
using Assets.Scripts.Tools;
using System.Collections;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts.DI
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private GameObject boardPrefab;
        [SerializeField] private GameObject hexPrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("Configure");

            builder.RegisterInstance(hexPrefab).As<GameObject>();

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