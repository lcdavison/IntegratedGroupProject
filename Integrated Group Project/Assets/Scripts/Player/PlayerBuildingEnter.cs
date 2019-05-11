using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerBuildingEnter : MonoBehaviour
{
    //  Detects objects that enter the trigger zone
    void OnTriggerEnter2D ( Collider2D collision )
    {
        //  Check the other object is a building
        if ( collision.gameObject.tag == "Building")
        {
            //  Get the building handler
            BuildingHandler building = collision.gameObject.GetComponent < BuildingHandler > (  );

            //  Get the data from the building
            Building data = building.GetData ( );

            //  Load the building and update the building ID
            GameManager.EnterArea ( data.scene, data.marker );
            GameManager.current_building = data.id;
        }
    }
}
