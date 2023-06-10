using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject 
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;

    List<Unit> unitList;

    public bool FoodIsCollectable = true;
    

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList= new List<Unit>();
    }

    public override string ToString()
    {
        string unitString = "";
        foreach (Unit unit in unitList)
        {
            unitString += unit.ToString();
        }

        return gridPosition.ToString() + "\n" + unitString + "\n";
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    public bool FoodCollectable()
    {
        return FoodIsCollectable;
    }

    

    public void AddUnit(Unit unit)
    {
        unitList.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        unitList.Remove(unit);
    }


     
}
