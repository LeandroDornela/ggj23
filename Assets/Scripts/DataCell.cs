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

public struct DataCellElements
{
    public DataCellElement airElement;
    public DataCellElement mainGroundElement;
    public DataCellElement secondaryGroundElement;
    public DataCellElement undergroundElement;

    public DataCellElements(DataCellElement airElement = null,
                            DataCellElement mainGroundElement = null,
                            DataCellElement secondaryGroundElement = null,
                            DataCellElement undergroundElement = null)
    {
        this.airElement = airElement;
        this.mainGroundElement = mainGroundElement;
        this.secondaryGroundElement = secondaryGroundElement;
        this.undergroundElement = undergroundElement;
    }
}


/// <summary>
/// Dados da celula.
/// </summary>
[System.Serializable]
public class DataCell
{
    private DataCellResources resources;
    private DataCellElements elements;


    public DataCellResources Resources { get { return resources; } }
    public DataCellElements Elements { get { return elements; } }

    public DataCell(DataCellResources resources)
    {
        this.resources = resources;
    }

    public void UpdateCell()
    {
        
    }
}
