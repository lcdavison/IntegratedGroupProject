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

    public void OnClickClock ( )
    {
        GameObject selected = EventSystem.current.currentSelectedGameObject;
        Button selected_button = selected.GetComponent < Button > ( );
        ColorBlock button_colors = selected_button.colors;

        Clock t_clock = selected.GetComponent <Clock> ( );

        Debug.Log ( "Clock Time : " + t_clock.time.ToString ( ) );

        if ( !clocks.ContainsKey ( selected.name ) )
        {
            clocks.Add ( selected.name, t_clock );
            button_colors.normalColor = Color.green;
            button_colors.highlightedColor = Color.green;
        }
        else
        {
            clocks.Remove ( selected.name );
            button_colors.normalColor = Color.white;
            button_colors.highlightedColor = Color.white;
        }

        Debug.Log ( "Clocks Size : " + clocks.Count );

        selected_button.colors = button_colors;
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
