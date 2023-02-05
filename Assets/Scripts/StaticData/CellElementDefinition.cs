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
}
