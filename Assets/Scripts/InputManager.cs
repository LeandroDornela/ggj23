using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Obsolete]
    public TMP_Text debugText;

    Camera cam;

    private Vector3Int currentMouseGridPos;
    private GameManager gameManager;

    private void Awake()
    {
        cam = Camera.main;
        gameManager = FindObjectOfType<GameManager>();
        currentMouseGridPos = Vector3Int.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseGridPosition();

        if(Input.GetButtonDown("Fire1"))
        {
            CustonEvents.Instance.OnClickGridCell.Trigger(currentMouseGridPos);
        }

        DebugText();
    }


    void UpdateMouseGridPosition()
    {
        RaycastHit hit;
        Vector3Int pos = Vector3Int.zero;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            pos = new Vector3Int(Mathf.RoundToInt(hit.point.x),
                                 Mathf.RoundToInt(hit.point.y),
                                 Mathf.RoundToInt(hit.point.z));

            if(pos != currentMouseGridPos && gameManager.Grid.IsPositionValid(pos.x, pos.z))
            {
                currentMouseGridPos = pos;

                CustonEvents.Instance.OnNewMouseGridPosition.Trigger(currentMouseGridPos);
            }

#if UNITY_EDITOR

            Debug.DrawLine(hit.point, hit.point + Vector3.up * 3, Color.gray);
            Debug.DrawLine(pos, hit.point + Vector3.up * 3, Color.green);

            if(gameManager.Grid.IsPositionValid(pos.x, pos.z))
            {
                //if (gameManager.Grid.GetDataOfCell(pos.x, pos.y).UndergroundHasElementOfType<RootElementDefinition>()) { Debug.Log("has root"); }

                List<CellData> cells = GridData.GetNeighbors(pos.x, pos.z);
                
                for(int i = 0; i < cells.Count; i++)
                {
                    Debug.DrawLine(new Vector3(cells[i].Position.x, 0, cells[i].Position.y), new Vector3(cells[i].Position.x, 0, cells[i].Position.y) + Vector3.up * 2, Color.red);
                }
            }

            
#endif
        }
    }


    void DebugText()
    {
        CellData currentCell = gameManager.Grid.GetDataOfCell(currentMouseGridPos.x, currentMouseGridPos.z);
        debugText.text = $"Sol: {currentCell.Resources.insolation}\nMateria Organica: {currentCell.Resources.organicMatter}\nAgua: {currentCell.Resources.water}";
        transform.position = currentMouseGridPos;
    }
}
