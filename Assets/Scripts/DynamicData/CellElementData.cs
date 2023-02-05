using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CellElementData
{
    protected ElementGraphics ghaphicsInstance;
    protected CellElementDefinition definition;

    public int CurrentHP { get; set; }
    public int CurentLifeTime { get; set; }

    public CellElementDefinition Definition { get { return definition; } }
    public ElementGraphics GraphicsInstance { get { return ghaphicsInstance; } }


    public CellElementData(CellElementDefinition definition)
    {
        this.definition = definition;
    }


    public void AddedToCell(CellData cell)
    {
        InstantiateGraphics(cell.Position.x, cell.Position.y);

        definition.OnAddedToCell(cell, this);
    }


    public void RemovedFromCell(CellData cell)
    {
        definition.OnRemovedFromCell(cell, this);
    }


    public void UpdateElement(CellData cell)
    {
        definition.OnTurnUpdate(cell, this);
    }


    void InstantiateGraphics(int i, int j)
    {
        Vector3 pos = new Vector3(i, 0, j);
        ghaphicsInstance = GameObject.Instantiate(definition.graphicsPrefab, pos, Quaternion.identity);
    }


    ~CellElementData()
    {
        GameObject.Destroy(GraphicsInstance);
    }
}
