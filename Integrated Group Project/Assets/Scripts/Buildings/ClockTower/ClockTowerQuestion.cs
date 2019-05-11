using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClockTowerQuestion : MonoBehaviour
{
    [SerializeField]
    private Dictionary < string, Clock > clocks = new Dictionary < string, Clock > ( ); //  Stores the clocks positioned in the box

    //  Detects objects that enter the trigger zone
    void OnTriggerEnter2D ( Collider2D collider )
    {
        //  Check the other object is a clock
        if ( collider.gameObject.tag == "Clock" )
        {
            //  Add clock to dictionary
            clocks.Add ( collider.gameObject.name, collider.gameObject.GetComponent <Clock> () );
        }
    }

    //  Detects objects that exit the trigger zone
    void OnTriggerExit2D ( Collider2D collider )
    {
        //  Check the other object is a clock
        if ( collider.gameObject.tag == "Clock" )
        {
            //  Remove clock from dictionary
            clocks.Remove ( collider.gameObject.name );
        }
    }

    //  Submit the players answer to be checked
    public void OnClickSubmit ( )
    {
        if ( clocks.Count == 0 )
        {
            // TODO: Display message to tell player to select a clock
            return;
        }

        Vector2 answer = new Vector2 ( 4, 0 );  //  Correct answer

        byte total = 0;     //  Total correct answers

        foreach ( KeyValuePair < string, Clock > entry in clocks )
        {
            //  Add one to total if answer is correct
            total += Convert.ToByte ( entry.Value.time == answer );
        }

        //  Add coins to player
        GameManager.AddCoins ( total );

        //  Return to tutorial
        GameManager.LeaveArea ( "lvlTutorial" );
    }
}
