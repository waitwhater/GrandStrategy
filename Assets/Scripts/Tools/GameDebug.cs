using Assets.Scripts.Game.Grid;
using Assets.Scripts.Game.HexCell;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Tools
{
    public class GameDebug
    {
        private HexGrid _hexGrid;

        public GameDebug(HexGrid hexGrid)
        {
            _hexGrid = hexGrid;
        }

        public void ShowDebugOnStart()
        {
            for (int x = 0, i = 0; x < _hexGrid.Width; x++)
                for (int z = 0; z < _hexGrid.Height; z++, i++)
                    ShowHexCoordinates(_hexGrid.Hexes[i]);
        }

        public void ShowHexCoordinates(Hex hex)
        {
            CreateDebugText(hex.transform, $"{hex.hexLogic.HexCoordinates}", hex.GetHexWorldPosition() + new Vector3(0, hex.GetComponent<Renderer>().bounds.size.y, 0));
        }

        public void CreateDebugText(Transform parent, string text, Vector3 position)
        {
            var debugText = new GameObject("debugText", typeof(TextMeshPro));
            debugText.transform.SetParent(parent);
            debugText.transform.position = position + new Vector3(0, 0.3f, 0);
            debugText.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
            var TMP = debugText.GetComponent<TextMeshPro>();
            TMP.text = text;
            TMP.color = Color.black;
            TMP.alignment = TextAlignmentOptions.Center;
            TMP.fontSize = 10f;
        }
        
    }
}
