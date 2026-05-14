using Assets.Scripts.Game.Buildings.Workplace;
using Assets.Scripts.Game.HexCell;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Buildings
{
    [CreateAssetMenu(fileName = "BuildingConfig", menuName = "Configs/BuildingConfig")]
    public class BuildingData : ScriptableObject
    {
        [Header("General")]
        [SerializeField] private string buildingName;
        [SerializeField] private BuildingTypes buildingType;
        [SerializeField] private int buildingLevel;
        [SerializeField] private GameObject prefab;

        [Header("Workplaces")]
        [SerializeField] private List<WorkplaceData> possibleWorkplaces;
        [SerializeField] private int workplacesLimit;

        [Header("Military")]
        [SerializeField] private int health;
        [SerializeField] private int defenceRate;
    }
}

public enum BuildingTypes
{
    House,
    Palace,
    Farm,
    Livestock,
    Mining,
    Manufactures,
    Holy,
    Warehouse,
    MilitaryFortress,
    MilitaryCamp
}
