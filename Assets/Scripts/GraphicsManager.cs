using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public struct TileAssets
{
    public Tile grass;
    public Tile dirt;
    public Tile mud;
    public Tile water;
}

[System.Serializable]
public struct ElementsAssets
{
    [Header("Nature")]
    public GameObject mainTree;
    public GameObject energyTree;
    public GameObject waterTree;
    public GameObject destructionTree;
    public GameObject poisonTree;
    public GameObject root;
    [Header("Human")]
    public GameObject humanBuilding;
}

public class GraphicsManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileAssets tileAssets;
    [SerializeField] private ElementsAssets elementsAssets;    

    public void SpawnGridTiles(GridData dataGrid)
    {
        dataGrid.ForEachCell(SpawnTile);
    }


    void SpawnTile(CellData cell, int i, int j)
    {
        Vector3Int pos = new Vector3Int(i, j, 0);
        Tile tileToPlace;

        if(cell.Resources.water > cell.Resources.organicMatter)
        {
            tileToPlace = tileAssets.water;
        }
        else if(cell.Resources.water == cell.Resources.organicMatter)
        {
            tileToPlace = tileAssets.mud;
        }
        else if(cell.Resources.organicMatter == 0)
        {
            tileToPlace = tileAssets.dirt;
        }
        else
        {
            tileToPlace = tileAssets.grass;
        }

        tilemap.SetTile(pos, tileToPlace);

        //Color col = new Color(cell.Resources.insolation, cell.Resources.organicMatter, cell.Resources.water);
        //tilemap.SetColor(pos, col);
    }
}
