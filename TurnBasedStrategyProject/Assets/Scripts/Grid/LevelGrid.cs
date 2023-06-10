using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{

    public static LevelGrid instance { get; private set; }

    private GridSystem gridSystem;
    [SerializeField] private Transform gridDebugObjectPrefab;

    public List<GameObject> spawnedGridObjects = new List<GameObject>();

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        gridSystem = new GridSystem(50,20,2f);
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab); 
    }

    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
        if(gridObject.GetUnitList().Count > 1)
        {
            var tempList = gridObject.GetUnitList();
            for (int i = 0; i < tempList.Count - 1; i++)
            {
                for (int j = i + 1; j < tempList.Count; j++)
                {

                    
                    if (tempList[i].CompareTag(Constants.WormTag) && tempList[j].CompareTag(Constants.WormTag)) //if there are more than 2 worms remove them then destroy them
                    {
                        GameObject temp1 = tempList[i].gameObject;
                        GameObject temp2 = tempList[j].gameObject;
                        Debug.Log("Found MORE THAN ONE WORM ");
                        RemoveUnitAtGridPosition(gridPosition, tempList[i]);
                        RemoveUnitAtGridPosition(gridPosition, tempList[j-1]);

                        Destroy(temp1);
                        Destroy(temp2);

                    }

                    else //if is there any food in tempList list do these actions
                    {
                        ////gridObject.

                        GameObject temp2 = tempList[i].gameObject;

                        RemoveUnitAtGridPosition(gridPosition, tempList[j]);

                        Destroy(temp2);

                        tempList[j].GetComponent<Unit>().IncreaseSize();

                    }
                }
            }
        }

        
    }

     

    public void CheckForDestroy()
    {
        
    }

    public void CheckItemsOnGrid(GridPosition gridPosition)
    {
        
    }

    public void CheckForFood()
    {
        
    }

    public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnitList();
    }

    public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public void UnitMovedGridPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosition )
    {
        RemoveUnitAtGridPosition(fromGridPosition,unit);
        AddUnitAtGridPosition(toGridPosition, unit);
    }
 
    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
    



     
}
