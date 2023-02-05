using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Resource
{
    water,
    energy
}


[CreateAssetMenu(fileName = "ResourcesBuildingDefinition", menuName = "Scriptable Objects/Resources Building Definition")]
public class ResourceBuildingDefinition : CellElementDefinition
{
    public int waterCost;
    public int energyCost;
    public int hp;
    public Resource resourceProduction;
    public int resourceGenerationMultiplier;
}
