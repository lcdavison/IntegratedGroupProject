using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //  Load character selection UI when start is clicked
    public void OnClickStart ( )
    {
        SceneManager.LoadScene ( "CharacterSelection" );
    }

    //  Exit game when quit is clicked
    public void OnClickQuit ( )
    {
        Application.Quit ( );
    }
}
