using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoisonBuildingDefinition", menuName = "Scriptable Objects/Poison Building Definition")]
public class PoisonBuildingDefinition : CellElementDefinition
{
    public int waterCost;
    public int energyCost;
    public int hp;
    public int damagePerTurn;
    public int damageArea;
}
