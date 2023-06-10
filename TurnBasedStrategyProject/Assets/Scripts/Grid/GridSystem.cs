using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Jobs;

public class GridSystem
{
    private int width;
    private int height;
    private float cellSize;

    private GridObject[,] gridObjectArray; 
    public GridSystem(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridObjectArray= new GridObject[width, height]; 
        for (int x = 0;x < width; x++)
        {
            for(int z = 0; z < height; z++)
            {
                //Debug.DrawLine(GetWorldPosition(x,z), GetWorldPosition(x,z)+Vector3.right  * .5f , Color.red, 1000);


                GridPosition gridPosition = new GridPosition(x,z);
                gridObjectArray[x,z] =  new GridObject(this, gridPosition);


            }
        }
    } 

    public void CreateDebugObjects(Transform debugPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x,z);

                Transform debugTransform = GameObject.Instantiate(debugPrefab, GetWorldPosition(gridPosition), Quaternion.identity);
                GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                gridDebugObject.SetGridObject(GetGridObject(gridPosition));
                LevelGrid.instance.spawnedGridObjects.Add(gridDebugObject.gameObject);
                gridDebugObject.transform.SetParent(LevelGrid.instance.transform);
            }
        }
    }

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjectArray[gridPosition.x, gridPosition.z];
    }




    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(Mathf.RoundToInt(worldPosition.x / cellSize), Mathf.RoundToInt(worldPosition.z / cellSize));
    }

}
