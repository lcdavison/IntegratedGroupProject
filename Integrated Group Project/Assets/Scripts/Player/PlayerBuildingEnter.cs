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

            GameManager.EnterArea ( data.scene, data.marker );
            GameManager.current_building = data.id;
        }
    }
}
