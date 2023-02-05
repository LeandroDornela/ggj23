using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("Grid Data")]
    [SerializeField] private Texture2D cellsDefinition;
    [SerializeField] private Texture2D elementsDefinition;

    [Header("Elements Definition")]
    [NaughtyAttributes.Expandable][SerializeField] private CellElementDefinition[] buildingsDefinitions;

    [Header("Scene References")]
    [SerializeField] private TMP_Text turnCounterText;
    [SerializeField] private TMP_Text waterCounterText;
    [SerializeField] private TMP_Text energyCounterText;
    
    private GridData grid;
    private GraphicsManager graphicsManager;

    [Space]

    [NaughtyAttributes.ReadOnly][SerializeField] private bool isBusy = false;
    [NaughtyAttributes.ReadOnly][SerializeField] private int turnCounter = 0;
    [NaughtyAttributes.ReadOnly][SerializeField] private int selectedBuilding = -1;
    [NaughtyAttributes.ReadOnly][SerializeField] private int resourceWater = 0;
    [NaughtyAttributes.ReadOnly][SerializeField] private int resourceEnergy = 0;


    public GridData Grid { get { return grid; } }
    public bool IsBusy { get { return isBusy; } }


    /// <summary>
    /// 
    /// </summary>
    public void ButtonNextTurn()
    {
        StartCoroutine(NextTurn());
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    public void ButtonSelectBuilding(int id)
    {
        selectedBuilding = id;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator NextTurn()
    {
        isBusy = true;
        turnCounter++;
        turnCounterText.text = turnCounter.ToString();

        CustonEvents.Instance.OnNewTurn.Trigger(turnCounter);

        Debug.Log("Next Turn");

        yield return new WaitForSeconds(1);

        isBusy = false;
    }


    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        if(graphicsManager == null)
        {
            graphicsManager = FindObjectOfType<GraphicsManager>();
        }

        InitializeDataGrid();

        graphicsManager.SpawnGridTiles(grid);

        energyCounterText.text = "0";
        waterCounterText.text = "0";
        turnCounterText.text = "0";
    }


    /// <summary>
    /// 
    /// </summary>
    void InitializeDataGrid()
    {
        grid = new GridData(cellsDefinition, elementsDefinition);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnselectBuilding();
        }
    }


    /// <summary>
    /// 
    /// </summary>
    void UnselectBuilding()
    {
        selectedBuilding = -1;
    }
}
