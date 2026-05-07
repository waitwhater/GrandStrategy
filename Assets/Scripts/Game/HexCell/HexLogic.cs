using Assets.Scripts.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Game.HexCell
{
    [Serializable]
    public class HexLogic
    {
        private readonly HexCoordinates _hexCoordinates;
        private readonly int _offsetWidth;
        private readonly int _offsetHeight;
        private readonly int _index;

        private LandscapeTypes landscapeType;
        public LandscapeTypes LandscapeType { get => landscapeType; set => landscapeType = value; }

        public HexCoordinates HexCoordinates => _hexCoordinates;
        public int OffsetWidth => _offsetWidth;
        public int OffsetHeight => _offsetHeight;
        public int Index => _index;

        public HexLogic(HexCoordinates hexCoordinates, int offsetWidth, int offsetHeight, int index)
        {
            _hexCoordinates = hexCoordinates;
            _offsetWidth = offsetWidth;
            _offsetHeight = offsetHeight;
            _index = index;
        }

    }
}
