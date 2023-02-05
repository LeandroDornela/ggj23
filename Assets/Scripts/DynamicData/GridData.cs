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
                dataCells[i, j] = new CellData(new DataCellResources(data.r, data.g, data.b));
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


    public void UpdateGrid()
    {
        ForEachCell(UpdateCell);
    }


    void UpdateCell(CellData dataCell, int i, int j)
    {
        dataCell.UpdateCell();
    }
}
