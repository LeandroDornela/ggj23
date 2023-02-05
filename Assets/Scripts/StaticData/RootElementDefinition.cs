using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RootBuildingDefinition", menuName = "Scriptable Objects/Root Building Definition")]
public class RootElementDefinition : BuildableElementDefinition
{
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
