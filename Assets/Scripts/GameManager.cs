using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Texture2D cellsDefinition;
    [SerializeField] private Texture2D elementsDefinition;

    private DataGrid grid;
    private GraphicsManager graphicsManager;
    private bool isBusy = false;


    public DataGrid Grid { get { return grid; } }
    public bool IsBusy { get { return isBusy; } }


    public void ButtonNextTurn()
    {
        StartCoroutine(NextTurn());
    }


    public void ButtonSelectBuilding(int id)
    {

    }


    IEnumerator NextTurn()
    {
        isBusy = true;

        Debug.Log("Next Turn");

        yield return new WaitForSeconds(1);

        isBusy = false;
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
