using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DemolisherBuildingDefinition", menuName = "Scriptable Objects/Demolisher Building Definition")]
public class DemolisherBuildingDefinition : BuildableElementDefinition
{
    public int damageArea;

    public override void OnAddedToCell(CellData cell, CellElementData element)
    {
        base.OnAddedToCell(cell, element);
    }


    public override void OnTurnUpdate(CellData cell, CellElementData element)
    {
        base.OnTurnUpdate(cell, element);
    }


    public override void OnRemovedFromCell(CellData cell, CellElementData element)
    {
        base.OnRemovedFromCell(cell, element);
    }
}
