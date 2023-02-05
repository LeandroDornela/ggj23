using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RootBuildingDefinition", menuName = "Scriptable Objects/Root Building Definition")]
public class RootElementDefinition : CellElementDefinition
{
    public int waterCost;
    public int energyCost;
    public int hp;
}
