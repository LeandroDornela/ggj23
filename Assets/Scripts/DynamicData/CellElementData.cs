using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CellElementData
{
    protected ElementGraphics ghaphicsInstance;
    protected CellElementDefinition definition;

    public CellElementDefinition Definition { get { return definition; } }
    public ElementGraphics GraphicsInstance { get { return ghaphicsInstance; } }

    public void UpdateElement()
    {

    }


    public void InstantiateGraphics(Vector3 pos)
    {
        ghaphicsInstance = GameObject.Instantiate(definition.graphicsPrefab, pos, Quaternion.identity);
    }
}
