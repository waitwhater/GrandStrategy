using Assets.Scripts.Game.Board;
using Assets.Scripts.Game.Grid;
using Assets.Scripts.Game.HexCell;
using System.Collections;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts.DI
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private Board boardPrefab;
        [SerializeField] private Hex hexPrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("Configure");

            builder.RegisterComponentInNewPrefab<Hex>(hexPrefab, Lifetime.Transient);

            builder.Register<HexGrid>(Lifetime.Scoped);
            builder.Register<HexSpawner>(Lifetime.Singleton);

            builder.RegisterComponentInNewPrefab<Board>(boardPrefab, Lifetime.Scoped);

        }


    }
}