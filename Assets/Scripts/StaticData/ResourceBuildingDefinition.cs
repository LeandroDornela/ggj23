using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ResourcesBuildingDefinition", menuName = "Scriptable Objects/Resources Building Definition")]
public class ResourceBuildingDefinition : BuildableElementDefinition
{
    public Resource resourceProduction;
    public int resourceAmount;
    public bool produceResouceOnSpawn;
    public bool produceResouceAllTurns;

    public override void OnAddedToCell(CellData cell, CellElementData element)
    {
        base.OnAddedToCell(cell, element);

        if(produceResouceOnSpawn)
        {
            GameManager.AddResource(resourceProduction, resourceAmount);
        }
    }


    public override void OnTurnUpdate(CellData cell, CellElementData element)
    {
        base.OnTurnUpdate(cell, element);

        if(produceResouceAllTurns)
        {
            GameManager.AddResource(resourceProduction, resourceAmount);
        }
    }


    public override void OnRemovedFromCell(CellData cell, CellElementData element)
    {
        base.OnRemovedFromCell(cell, element);
    }
}
