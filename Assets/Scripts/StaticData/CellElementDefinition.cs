using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CellElementDefinition : ScriptableObject
{
    public string elementName;
    [TextArea] public string elementDescription;
    public ElementGraphics graphicsPrefab;
    public Color definitionColor;
    public CellElementCategory cellElementCategory;
    public ConditionToPlaceElement conditionToPlaceElement;
    public ConditionToPlaceElement secondaryConditionToPlaceElement;

    public virtual void OnAddedToCell(CellData cell, CellElementData element) { }
    public virtual void OnRemovedFromCell(CellData cell, CellElementData element) { }
    public virtual void OnTurnUpdate(CellData cell, CellElementData element) { }
}
