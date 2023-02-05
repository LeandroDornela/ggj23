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
    public GridData(Texture2D cellsDefinition, Texture2D elementsDifinition)
    {
        dataCells = new CellData[cellsDefinition.width, cellsDefinition.height];

        for (int i = 0; i < dataCells.GetLength(0); i++)
        {
            for (int j = 0; j < dataCells.GetLength(1); j++)
            {
                Color data = cellsDefinition.GetPixel(i, j);
                dataCells[i, j] = new CellData(new DataCellResources(data.r, data.g, data.b), i, j);
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


    public bool SetCellElement(CellElementData elementData, int i, int j)
    {
        if(!IsPositionValid(i, j))
        {
            return false;
        }
        dataCells[i, j].RemoveElementSafe(elementData.Definition.cellElementCategory);
        return dataCells[i, j].AddElementSafe(elementData);
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


    public void UpdateGrid()
    {
        ForEachCell(UpdateCell);
    }


    void UpdateCell(CellData dataCell, int i, int j)
    {
        dataCell.UpdateCell();
    }
}
