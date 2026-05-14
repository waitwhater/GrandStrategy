using Assets.Scripts.Game.HexCell;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Buildings.Workplace
{
    internal class WorkplaceLogic
    {
        private Guid guid;
        private BuildingLogic building;
        private WorkplaceData workplaceData;
        private int maxHealth;
        private int currentHealth;
        private WorkplaceDecay workplaceDecay;

    }
}

public enum WorkplaceDecay
{
    Solid,
    Corrupt,
    Ruined
}
