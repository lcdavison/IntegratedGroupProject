using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerBuildingEnter : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Building")
        {
            BuildingHandler building = collision.gameObject.GetComponent < BuildingHandler > (  );
        
            Building data = building.GetData ( );
            Debug.Log ( "Entered The Building : " + data.name );

            GameManager.LoadBuilding ( data.scene );
            GameManager.current_building = data.id;
        }
    }
}
