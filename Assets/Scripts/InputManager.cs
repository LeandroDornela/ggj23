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

            if(pos != currentMouseGridPos)
            {
                currentMouseGridPos = pos;

                CustonEvents.Instance.OnNewMouseGridPosition.Trigger(currentMouseGridPos);
            }

#if UNITY_EDITOR

            Debug.DrawLine(hit.point, hit.point + Vector3.up * 3, Color.gray);
            Debug.DrawLine(pos, hit.point + Vector3.up * 3, Color.green);

#endif
        }
    }


    void DebugText()
    {
        DataCell currentCell = gameManager.GetDataOfCell(currentMouseGridPos.x, currentMouseGridPos.z);
        debugText.text = $"Sol: {currentCell.Resources.insolation}\nMateria Organica: {currentCell.Resources.organicMatter}\nAgua: {currentCell.Resources.water}";
        transform.position = currentMouseGridPos;
    }
}
