using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Buildings.Workplace
{
    [CreateAssetMenu(fileName = "WorkpalceConfig", menuName = "Configs/WorkpalceConfig")]
    public class WorkplaceData : ScriptableObject
    {
        [Header("General")]
        [SerializeField] private string workplaceName;

        [Header("Military")]
        [SerializeField] private int health;
    }
}
