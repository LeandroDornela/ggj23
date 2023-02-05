using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Grid para armazenamonto das celulas de dados.
/// </summary>
[System.Serializable]
public class GridData
{
    private CellData[,] dataCells;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="cellsDefinition">Definição de cada celula atravez de informação de cor.</param>
    /// <param name="elementsDifinition">Definição de elementos pre spawnados em cada celula.</param>
    public GridData(Texture2D cellsDefinition, Texture2D elementsDifinition, CellElementDefinition[] buildableElementsDefinitions, CellElementDefinition[] generalElementsDefinitions)
    {
        dataCells = new CellData[cellsDefinition.width, cellsDefinition.height];

        for (int i = 0; i < dataCells.GetLength(0); i++)
        {
            for (int j = 0; j < dataCells.GetLength(1); j++)
            {
                // set das celulas da grade.
                Color data = cellsDefinition.GetPixel(i, j);
                dataCells[i, j] = new CellData(new DataCellResources(data.r, data.g, data.b), i, j);


                // Set dos elementos presentes inicioalmente nas celulas.
                data = elementsDifinition.GetPixel(i, j);

                // No definition for this cell.
                if(data == Color.black)
                {
                    continue;
                }

                for(int k = 0; k < buildableElementsDefinitions.Length; k++)
                {
                    if (buildableElementsDefinitions[k].definitionColor == data)
                    {
                        SetCellElement(buildableElementsDefinitions[k], i, j);
                        break;
                    }
                }
                for (int k = 0; k < generalElementsDefinitions.Length; k++)
                {
                    if (generalElementsDefinitions[k].definitionColor == data)
                    {
                        SetCellElement(generalElementsDefinitions[k], i, j);
                        break;
                    }
                }
            }
        }
    }

    public void ForEachCell(Action<CellData, int, int> method)
    {
        for (int i = 0; i < dataCells.GetLength(0); i++)
        {
            for (int j = 0; j < dataCells.GetLength(1); j++)
            {
                method.Invoke(dataCells[i, j], i, j);
            }
        }
    }


    public CellData GetDataOfCell(int i, int j)
    {
        return dataCells[i, j];
    }


    public bool IsPositionValid(int i, int j)
    {
        if(i < 0 || j < 0 || i >= dataCells.GetLength(1) || j >= dataCells.GetLength(0))
        {
            return false;
        }

        return true;
    }


    public bool SetCellElement(CellElementDefinition elementDefinition, int i, int j)
    {
        if(!IsPositionValid(i, j))
        {
            return false;
        }

        Debug.Log($"<color=green>Adding Cell element {elementDefinition.elementName} to ({i}, {j}) </color>");

        CellElementData data = new CellElementData(elementDefinition);

        dataCells[i, j].RemoveElementSafe(data.Definition.cellElementCategory);
        return dataCells[i, j].AddElementSafe(data);
    }


    public List<CellData> GetNeighbors(int i, int j)
    {
        List<CellData> neighbors = new List<CellData>();

        if (i > 0)
        {
            neighbors.Add(dataCells[i - 1,j]);
        }
        if(i < dataCells.GetLength(1) - 1)
        {
            neighbors.Add(dataCells[i + 1, j]);
        }
        if(j > 0)
        {
            neighbors.Add(dataCells[i, j - 1]);
        }
        if(j < dataCells.GetLength(0) - 1)
        {
            neighbors.Add(dataCells[i, j + 1]);
        }

        return neighbors;
    }


    public bool VerifyCondition(ConditionToPlaceElement condition, int i, int j)
    {
        switch (condition)
        {
            case ConditionToPlaceElement.none:
                return true;
            case ConditionToPlaceElement.hasRootOnTile:
                if (GetDataOfCell(i, j).UndergroundHasElementOfType<RootElementDefinition>())
                {
                    return true;
                }
                break;
            case ConditionToPlaceElement.hasOnlyNeighborRoot:
                if (GetDataOfCell(i, j).UndergroundHasElementOfType<RootElementDefinition>())
                {
                    return false;
                }
                else
                {
                    List<CellData> cells = GetNeighbors(i, j);
                    for (int k = 0; k < cells.Count; k++)
                    {
                        if (cells[k].UndergroundHasElementOfType<RootElementDefinition>())
                        {
                            return true;
                        }
                    }
                }
                break;
            case ConditionToPlaceElement.mainGroundFree:
                if (GetDataOfCell(i, j).Elements.mainGroundElement == null) return true;
                return false;
            case ConditionToPlaceElement.secondaryGroundFree:
                if (GetDataOfCell(i, j).Elements.secondaryGroundElement == null) return true;
                return false;
            case ConditionToPlaceElement.airFree:
                if (GetDataOfCell(i, j).Elements.airElement == null) return true;
                return false;
            case ConditionToPlaceElement.undergroundFree:
                if (GetDataOfCell(i, j).Elements.undergroundElement == null) return true;
                return false;
        }

        return false;
    }


    public void UpdateGrid()
    {
        ForEachCell(UpdateCell);
    }


    void UpdateCell(CellData dataCell, int i, int j)
    {
        dataCell.UpdateCell();
    }
}
