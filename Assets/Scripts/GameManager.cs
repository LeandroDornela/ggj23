using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Texture2D cellsDefinition;
    [SerializeField] private Texture2D elementsDefinition;

    private DataGrid grid;

    private GraphicsManager graphicsManager;


    public DataCell GetDataOfCell(int i, int j)
    {
        return grid.GetDataOfCell(i, j);
    }


    private void Awake()
    {
        if(graphicsManager == null)
        {
            graphicsManager = FindObjectOfType<GraphicsManager>();
        }

        InitializeDataGrid();

        graphicsManager.SpawnGridTiles(grid);
    }

    void InitializeDataGrid()
    {
        grid = new DataGrid(cellsDefinition, elementsDefinition);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
