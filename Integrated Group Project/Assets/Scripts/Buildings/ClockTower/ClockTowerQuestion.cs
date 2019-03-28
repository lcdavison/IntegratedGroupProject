using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClockTowerQuestion : MonoBehaviour
{
    [SerializeField]
    private Dictionary <string, Clock> clocks = new Dictionary <string, Clock> ( );

    public void OnClickClock ( )
    {
        GameObject selected = EventSystem.current.currentSelectedGameObject;

        Clock t_clock = selected.GetComponent <Clock> ( );

        if ( t_clock == null )
            Debug.Log ( "Clock NULL" );

        Debug.Log ( "Clock Time : " + t_clock.time.ToString ( ) );

        if ( !clocks.ContainsKey ( selected.name ) )
            clocks.Add ( selected.name, t_clock );
        else
            clocks.Remove ( selected.name );

        Debug.Log ( "Clocks Size : " + clocks.Count );
    }

    public void CheckAnswers ( )
    {
        /*
            foreach ( Clock clock in clocks )
        {

        }
         */
    }
}
