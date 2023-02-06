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

    public void UpdateElements(CellData cell)
    {
        airElement?.UpdateElement(cell);
        mainGroundElement?.UpdateElement(cell);
        secondaryGroundElement?.UpdateElement(cell);
        undergroundElement?.UpdateElement(cell);
    }
}


/// <summary>
/// Dados da celula.
/// </summary>
[System.Serializable]
public class CellData
{
    private DataCellResources resources;
    public DataCellElements elements;
    private Vector2Int position;
    private List<MobileUnit> mobileUnits;


    public Vector2Int Position { get { return position; } }
    public DataCellResources Resources { get { return resources; } }
    public DataCellElements Elements { get { return elements; } }

    public CellData(DataCellResources resources, int i, int j)
    {
        this.resources = resources;
        position.x = i;
        position.y = j;

        mobileUnits = new List<MobileUnit>();
    }


    public bool RemoveElementSafe(CellElementCategory categoty)
    {
        switch(categoty)
        {
            case CellElementCategory.air:
                return RemoveDefinedCatElement(ref elements.airElement);
            case CellElementCategory.mainGround:
                return RemoveDefinedCatElement(ref elements.mainGroundElement);
            case CellElementCategory.secondaryGround:
                return RemoveDefinedCatElement(ref elements.secondaryGroundElement);
            case CellElementCategory.underground:
                return RemoveDefinedCatElement(ref elements.undergroundElement);
        }

        return false;
    }

    bool RemoveDefinedCatElement(ref CellElementData elementDataProperty)
    {
        if (elementDataProperty == null)
        {
            return false;
        }
        else
        {
            elementDataProperty.RemovedFromCell(this);
            elementDataProperty = null;
            return true;
        }
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
            elementDataProperty.AddedToCell(this);
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// Use apenas typos derivados de CellElementDefinition.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public bool UndergroundHasElementOfType<T>()
    {
        if (elements.undergroundElement == null) return false;

        if (elements.undergroundElement.Definition.GetType() == typeof(T))
        {
            return true;
        }

        return false;
    }

    public void UpdateCell()
    {
        elements.UpdateElements(this);

        for (int i = 0; i < mobileUnits.Count; i++)
        {
            mobileUnits[i].TurnUpdate();
        }
    }


    public void ApplyDamageToMobileUnits(int damage)
    {
        for(int i = 0; i < mobileUnits.Count; i++)
        {
            mobileUnits[i].ReceiveDamage(damage);
        }
    }


    public void ApplyDamageToElement(ref CellElementData element, int amount)
    {
        element.ReceiveDamage(amount);

        if(element.CurrentHP <= 0)
        {
            RemoveDefinedCatElement(ref element);
        }
    }


    public void RemoveMobileUnit(MobileUnit unit)
    {
        mobileUnits.Remove(unit);
        unit.CurrentCell = null;
    }


    public void AddMobileUnit(MobileUnit unit)
    {
        mobileUnits.Add(unit);
        unit.CurrentCell = this;
    }
}
