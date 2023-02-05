using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableElementDefinition : CellElementDefinition
{
    public int waterCost;
    public int energyCost;
    public int hp;

    public override void OnAddedToCell(CellData cell, CellElementData element)
    {
        base.OnAddedToCell(cell, element);

        element.CurrentHP = hp;
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
