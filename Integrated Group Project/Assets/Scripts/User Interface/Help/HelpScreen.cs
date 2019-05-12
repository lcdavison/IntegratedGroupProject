using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject to_hide;

    [SerializeField]
    private GameObject help_screen;

    [SerializeField]
    private Text help_output;

    [SerializeField]
    private HelpObject help_text;   //  Help information to display

    //  Show help screen when help button is clicked
    public void OnHelpClick ( )
    {
        to_hide.SetActive ( false );
        help_screen.SetActive ( true );

        help_output.text = help_text.help_information;
    }

    //  Close the help screen
    public void OnHelpExitClick ( )
    {
        to_hide.SetActive ( true );
        help_screen.SetActive ( false );
    }
}
