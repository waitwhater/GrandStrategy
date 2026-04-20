using Assets.Scripts.Game.Board;
using Assets.Scripts.Game.Grid;
using Assets.Scripts.Game.HexCell;
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

            builder.RegisterComponentInHierarchy<Board>();
        }


    }
}