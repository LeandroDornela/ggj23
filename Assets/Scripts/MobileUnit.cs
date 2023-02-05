using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUnit : MonoBehaviour
{
    [Min(0)] public int hp;

    private int currentHp;
    private CellData currentCell;
    public CellData CurrentCell
    {
        get
        {
            return currentCell;
        }
        set
        {
            currentCell = value;
            if(value != null) transform.position = new Vector3(currentCell.Position.x, 0, currentCell.Position.y);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TurnUpdate()
    {
        List<CellData> neighbors = GridData.GetNeighbors(currentCell.Position.x, currentCell.Position.y);

        for(int i = 0; i < neighbors.Count; i++)
        {
            if (neighbors[i].Elements.mainGroundElement == null)
            {
                currentCell.RemoveMobileUnit(this);
                neighbors[i].AddMobileUnit(this);
                break;
            }
        }
    }


    public void ReceiveDamage(int amount)
    {
        currentHp -= amount;

        if(currentHp <= 0)
        {
            CurrentCell.RemoveMobileUnit(this);
            Destroy(this);
        }
    }


    public void DoDamage()
    {

    }
}
