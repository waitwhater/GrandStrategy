using Assets.Scripts.Game.Board;
using Assets.Scripts.Game.Grid;
using Assets.Scripts.Game.HexCell;
using Assets.Scripts.Inputs;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Tools
{
    public class MapEditor : MonoBehaviour
    {
        public List<LandscapeTypes> landscapeTypes;
        
        private LandscapeTypes _selectedLandscape;
        private HexInteractions _hexInteractions;
        private HexGrid _grid;
        private HexSpawner _spawner;
        private Board _board;

        public void SelectLandscape(int landscapeType)
        {
            _selectedLandscape = (LandscapeTypes)landscapeType;
        }

        public void SetLandscape(Hex hex)
        {
            if(hex.hexLogic.LandscapeType != _selectedLandscape)
            {
                var hexLogic = hex.hexLogic;

                _grid.Hexes[hexLogic.Index] = null;
                Destroy(hex);
                var newHex = _spawner.CreateHex(_board.transform, _selectedLandscape, hexLogic);
                _grid.Hexes[hexLogic.Index] = newHex;
                _spawner.SetupHex(newHex);
            }
            return;
        }

        void Start()
        {
            _hexInteractions.HexInteraction += SetLandscape;
        }

        public void OnDisable()
        {
            _hexInteractions.HexInteraction -= SetLandscape;
        }

        [Inject]
        public void Construct(HexInteractions hexInteractions, HexGrid hexGrid, HexSpawner hexSpawner, Board board)
        {
            _hexInteractions = hexInteractions;
            _grid = hexGrid;
            _spawner = hexSpawner;
            _board = board;
        }


    }
}