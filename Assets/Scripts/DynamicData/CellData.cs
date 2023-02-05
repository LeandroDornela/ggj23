using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    public CellElementData airElement;
    public CellElementData mainGroundElement;
    public CellElementData secondaryGroundElement;
    public CellElementData undergroundElement;

    public DataCellElements(CellElementData airElement = null,
                            CellElementData mainGroundElement = null,
                            CellElementData secondaryGroundElement = null,
                            CellElementData undergroundElement = null)
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
public class CellData
{
    private DataCellResources resources;
    private DataCellElements elements;
    private Vector2Int position;


    public Vector2Int Position { get { return position; } }
    public DataCellResources Resources { get { return resources; } }
    public DataCellElements Elements { get { return elements; } }

    public CellData(DataCellResources resources, int i, int j)
    {
        this.resources = resources;
        position.x = i;
        position.y = j;
    }


    public bool RemoveElementSafe(CellElementCategory categoty)
    {
        switch(categoty)
        {
            case CellElementCategory.air:
                if (elements.airElement == null)
                {
                    return false;
                }
                else
                {
                    elements.airElement = null;
                    return true;
                }
            case CellElementCategory.mainGround:
                if (elements.mainGroundElement == null)
                {
                    return false;
                }
                else
                {
                    elements.mainGroundElement = null;
                    return true;
                }
            case CellElementCategory.secondaryGround:
                if (elements.secondaryGroundElement == null)
                {
                    return false;
                }
                else
                {
                    elements.secondaryGroundElement = null;
                    return true;
                }
            case CellElementCategory.underground:
                if (elements.undergroundElement == null)
                {
                    return false;
                }
                else
                {
                    elements.undergroundElement = null;
                    return true;
                }
        }

        return false;
    }


    public bool AddElementSafe(CellElementData elementData)
    {
        switch (elementData.Definition.cellElementCategory)
        {
            case CellElementCategory.air:
                return AddDefinedCatElement(ref elements.airElement, elementData);
            case CellElementCategory.mainGround:
                return AddDefinedCatElement(ref elements.mainGroundElement, elementData);
            case CellElementCategory.secondaryGround:
                return AddDefinedCatElement(ref elements.secondaryGroundElement, elementData);
            case CellElementCategory.underground:
                return AddDefinedCatElement(ref elements.undergroundElement, elementData);
        }

        return false;
    }


    bool AddDefinedCatElement(ref CellElementData elementDataProperty, CellElementData newData)
    {
        if (elementDataProperty == null)
        {
            elementDataProperty = newData;
            elementDataProperty.InstantiateGraphics(new Vector3(position.x, 0, position.y));
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// Use apenas typos derivados de CellElementData.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public bool UndergroundHasElementOfType<T>()
    {
        if (elements.undergroundElement == null) return false;

        if (elements.undergroundElement.GetType() == typeof(T))
        {
            return true;
        }

        return false;
    }

    public void UpdateCell()
    {
        
    }
}
