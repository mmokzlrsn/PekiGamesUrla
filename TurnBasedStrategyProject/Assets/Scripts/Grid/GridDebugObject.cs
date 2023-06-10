using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{
    //[SerializeField] private TextMeshPro textMeshPro;
    private GridObject gridObject;
    public Food Food;
    private float hideDuration = 3f;

    public void SetGridObject(GridObject gridObject)
    { 
        this.gridObject = gridObject; 
    
    }

    private void Start()
    {
        
    }

        


    private void Update()
    {
        //textMeshPro.text = gridObject.ToString();
    }
}
