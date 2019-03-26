﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerBuildingEnter : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Building")
        {
            BuildingHandler building = collision.gameObject.GetComponent < BuildingHandler > (  );
            Debug.Log("Entered The Building : " + building.GetData ().name);
            GameManager.LoadBuilding ( building.GetData ( ).scene );
        }
    }
}
