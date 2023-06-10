using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{

    public static UnitActionSystem instance { get; private set; }
     


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance= this;

    }

 
 

}
