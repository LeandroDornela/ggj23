using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DemolisherBuildingDefinition", menuName = "Scriptable Objects/Demolisher Building Definition")]
public class DemolisherBuildingDefinition : CellElementDefinition
{
    public int waterCost;
    public int energyCost;
    public int hp;
    public int damageArea;
}
