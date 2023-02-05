using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;


public class GameManager : MonoBehaviour
{
    [Header("Grid Data")]
    [SerializeField] private Texture2D cellsDefinition;
    [SerializeField] private Texture2D elementsDefinition;

    [Header("Elements Definition")]
    [NaughtyAttributes.Expandable][SerializeField] private CellElementDefinition[] buildableElementsDefinitions;
    [NaughtyAttributes.Expandable][SerializeField] private CellElementDefinition[] generalElementsDefinitions;

    [Header("Scene References")]
    [SerializeField] private TMP_Text turnCounterText;
    [SerializeField] private TMP_Text waterCounterText;
    [SerializeField] private TMP_Text energyCounterText;
    
    private GridData grid;
    private GraphicsManager graphicsManager;

    [Space]

    [NaughtyAttributes.ReadOnly][SerializeField] private bool isBusy = false;
    [NaughtyAttributes.ReadOnly][SerializeField] private int turnCounter = 0;
    [SerializeField] private int selectedBuilding = -1;
    [SerializeField] private int resourceWater = 0;
    [SerializeField] private int resourceEnergy = 0;

    public MobileUnit test;


    public GridData Grid { get { return grid; } }
    public bool IsBusy { get { return isBusy; } }


    public static GameManager Instance;


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

        grid.UpdateGrid();

        yield return new WaitForSeconds(1);

        isBusy = false;
    }


    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        Instance = this;

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
        grid = new GridData(cellsDefinition, elementsDefinition, buildableElementsDefinitions, generalElementsDefinitions);

        grid.GetDataOfCell(0, 0).AddMobileUnit(Instantiate(test));
    }


    // Start is called before the first frame update
    void Start()
    {
        CustonEvents.Instance.OnClickGridCell.AddListener(OnClickCell);
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
    /// <param name="pos"></param>
    void OnClickCell(Vector3Int pos)
    {
        if (isBusy) return;

        if (selectedBuilding < 0) return;

        TryPlaceBuildableElement((BuildableElementDefinition)buildableElementsDefinitions[selectedBuilding], pos.x, pos.z);
    }


    bool TryPlaceBuildableElement(BuildableElementDefinition buildingDef, int i, int j)
    {
        if (HaveEnoughResources(buildingDef.waterCost, buildingDef.energyCost) &&
            grid.VerifyCondition(buildingDef.conditionToPlaceElement, i, j) &&
            grid.VerifyCondition(buildingDef.secondaryConditionToPlaceElement, i, j))
        {
            grid.SetCellElement(buildingDef, i, j);
            ConsumeResource(Resource.water, buildingDef.waterCost);
            ConsumeResource(Resource.energy, buildingDef.energyCost);
            return true;
        }

        return false;

        /*
        switch (buildingDef)
        {
            case RootElementDefinition:
                RootElementDefinition cast = (RootElementDefinition)buildingDef;
                if (HaveEnoughResources(cast.waterCost, cast.energyCost) && grid.VerifyCondition(cast.conditionToPlaceElement, i, j))
                {
                    grid.SetCellElement(cast, i,j);
                    ConsumeWater(cast.waterCost);
                    ConsumeEnergy(cast.energyCost);
                    break;
                }
                break;
            case ResourceBuildingDefinition:
                break;
            case PoisonBuildingDefinition:
                break;
            case DemolisherBuildingDefinition:
                break;
        }
        */
    }


    bool HaveEnoughResources(int waterCost, int energyCost)
    {
        if(waterCost <= resourceWater && energyCost <= resourceEnergy)
        {
            return true;
        }

        return false;
    }


    public static void AddResource(Resource resource, int amount)
    {
        if(resource == Resource.energy)
        {
            Instance.resourceEnergy += amount;
            Instance.energyCounterText.text = Instance.resourceEnergy.ToString();
        }
        else if(resource == Resource.water)
        {
            Instance.resourceWater += amount;
            Instance.waterCounterText.text = Instance.resourceWater.ToString();
        }
    }


    public static void ConsumeResource(Resource resource, int amount)
    {
        if (resource == Resource.energy)
        {
            Instance.resourceEnergy -= amount;
            Instance.energyCounterText.text = Instance.resourceEnergy.ToString();
        }
        else if (resource == Resource.water)
        {
            Instance.resourceWater -= amount;
            Instance.waterCounterText.text = Instance.resourceWater.ToString();
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
