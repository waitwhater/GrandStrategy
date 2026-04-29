using Assets.Scripts.Game.Grid;
using Assets.Scripts.Game.HexCell;
using Assets.Scripts.Inputs;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Tools
{
    public class MapEditor : MonoBehaviour
    {
        public List<LandscapeTypes> landscapeTypes;
        
        private LandscapeTypes _selectedLandscape;
        private HexInteractions _hexInteractions;

        public void SelectLandscape(int landscapeType)
        {
            _selectedLandscape = (LandscapeTypes)landscapeType;
        }

        public void SetLandscape(Hex hex) => hex.LandscapeType = _selectedLandscape;

        void Start()
        {
            _hexInteractions.HexInteraction += SetLandscape;
        }

        public void OnDisable() => _hexInteractions.HexInteraction -= SetLandscape;

        [Inject]
        public void Construct(HexInteractions hexInteractions)
        {
            _hexInteractions = hexInteractions;
        }


    }
}