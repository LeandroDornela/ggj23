using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GraphicsManager : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Tilemap tilemap;

    public Tile temp_tile;

    

    public void SpawnGridTiles(DataGrid dataGrid)
    {
        dataGrid.ForEachCell(SpawnTile);
    }


    void SpawnTile(DataCell cell, int i, int j)
    {
        Vector3Int pos = new Vector3Int(i, j, 0);

        tilemap.SetTile(pos, temp_tile);

        Color col = new Color(cell.Resources.insolation, cell.Resources.organicMatter, cell.Resources.water);
        tilemap.SetColor(pos, col);

        //GameObject clone = Instantiate(cellPrefab, pos, cellPrefab.transform.rotation, transform);
        //clone.GetComponent<Renderer>().material.color = ;
    }
}
