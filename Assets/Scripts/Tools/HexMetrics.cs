using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Tools
{
    public static class HexMetrics
    {
        public const float outerRadius = 10f;
        public const float innerRadius = outerRadius * 0.866025404f;

        public static HexCoordinates FromOffsetCoordinates(int x, int z)
        {
            var cubeX = x - z / 2;
            var cubeZ = -cubeX - z;
            return new HexCoordinates(cubeX, z, cubeZ); //это надо рефакторить, Z можно не хранить, оно вычисляемое - можно return new HexCoordinates(x - z / 2, z);
        }

    }

    [Serializable]
    public struct HexCoordinates
    {
        [field: SerializeField] public int X { get; private set; }
        [field: SerializeField] public int Y { get; private set; }
        [field: SerializeField] public int Z { get; private set; } //это надо рефакторить, Z можно не хранить, оно вычисляемое

        public HexCoordinates(int x, int y, int z) { X = x; Y = y; Z = z; }

        public override string ToString()
        {
            return $"X = {X.ToString()}\\n Y = {Y.ToString()}\\n Z = {Z.ToString()}";
        }
    }

    [Serializable]
    public enum LandscapeTypes
    {
        Water,
        Grassland,
        Plain,
        Desert,
        Tundra,
        Snow
    }


}
