using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnClickStart ( )
    {
        //  Move onto tutorial or character selection screen
        Debug.Log ( "Start Clicked" );
    }

    public void OnClickQuit ( )
    {
        Application.Quit ( );
    }
}
