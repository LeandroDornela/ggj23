using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsManager : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;

    

    public void SpawnGridTiles(DataGrid dataGrid)
    {
        dataGrid.ForEachCell(SpawnTile);
    }


    void SpawnTile(DataCell cell, int i, int j)
    {
        Vector3 pos = new Vector3((float)i, 0,(float)j);
        GameObject clone = Instantiate(cellPrefab, pos, cellPrefab.transform.rotation, transform);
        clone.GetComponent<Renderer>().material.color = new Color(cell.Resources.insolation, cell.Resources.organicMatter, cell.Resources.water);
    }
}
