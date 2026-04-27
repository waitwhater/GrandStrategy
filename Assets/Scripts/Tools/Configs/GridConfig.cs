using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Tools.Configs
{
    [CreateAssetMenu(fileName = "GridConfig", menuName = "Configs/GridConfig")]
    public class GridConfig : ScriptableObject
    {
        [Header("Grid")]
        [SerializeField] private int _height;
        [SerializeField] private int _width;

        public int Height { get => _height; }
        public int Width { get => _width; }
    }
}
