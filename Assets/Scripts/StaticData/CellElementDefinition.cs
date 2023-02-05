using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CellElementDefinition : ScriptableObject
{
    public string elementName;
    [TextArea] public string elementDescription;
    public int assetID;
}
