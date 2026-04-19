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
        [SerializeField] private Board board;
        [SerializeField] private Hex hexPrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("Configure");

            builder.RegisterComponent(board);

            builder.Register<HexGrid>(Lifetime.Singleton);
            builder.Register<HexSpawner>(Lifetime.Scoped);

            builder.RegisterComponentInNewPrefab<Hex>(hexPrefab, Lifetime.Scoped); //создание нового монобех объекта

            //builder.RegisterInstance(board);

        }


    }
}