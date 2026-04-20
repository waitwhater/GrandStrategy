using Assets.Scripts.Game.Grid;
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

        public void ShowDebug()
        {
            for (int x = 0; x < _hexGrid.Width; x++)
                for (int y = 0; y < _hexGrid.Height; y++)
                {
                    CreateDebugText(_hexGrid.GridHexes[x, y].transform, $"{x}, {y}",
                        _hexGrid.GridHexes[x , y].GetHexWorldPosition());
                }
        }

        public void CreateDebugText(Transform parent, string text, Vector3 position)
        {
            var debugText = new GameObject("debugText", typeof(TextMeshPro));
            debugText.transform.SetParent(parent);
            debugText.transform.position = position + new Vector3(0, 1, 0);
            debugText.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
            var TMP = debugText.GetComponent<TextMeshPro>();
            TMP.text = text;
            TMP.color = Color.black;
            TMP.alignment = TextAlignmentOptions.Center;
            TMP.fontSize = 20f;
        }
        
    }
}
