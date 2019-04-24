using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClockTowerQuestion : MonoBehaviour
{
    [SerializeField]
    private Dictionary <string, Clock> clocks = new Dictionary <string, Clock> ( );

    void OnTriggerEnter2D ( Collider2D collider )
    {
        if ( collider.gameObject.tag == "Clock" )
        {
            clocks.Add ( collider.gameObject.name, collider.gameObject.GetComponent <Clock> () );
        }
    }

    void OnTriggerExit2D ( Collider2D collider )
    {
        if ( collider.gameObject.tag == "Clock" )
        {
            clocks.Remove ( collider.gameObject.name );
        }
    }

    public void OnClickSubmit ( )
    {
        if ( clocks.Count == 0 )
        {
            // TODO: Display message to tell player to select a clock
            return;
        }

        Vector2 answer = new Vector2 ( 4, 0 );

        byte total = 0;

        foreach ( KeyValuePair <string, Clock> entry in clocks )
        {
            total += Convert.ToByte ( entry.Value.time == answer );
        }

        GameManager.LoadBuilding ( "lvlTutorial" );

        Debug.Log ( "Correct : " + total );
    }
}
