using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct DataCellResources
{
    public float insolation;
    public float organicMatter;
    public float water;

    public DataCellResources(float insolation, float organicMatter, float water)
    {
        this.insolation = insolation;
        this.organicMatter = organicMatter;
        this.water = water;
    }
}


/// <summary>
/// Dados da celula.
/// </summary>
[System.Serializable]
public class DataCell
{
    private GraphicsCell graphicsCell;

    private DataCellResources resources;


    public DataCellResources Resources { get { return resources; } }

    public DataCell(DataCellResources resources)
    {
        this.resources = resources;
    }

    public void UpdateCell()
    {
        
    }
}
