﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickStart ( )
    {
        SceneManager.LoadScene ( "CharacterSelection" );
    }

    public void OnClickQuit ( )
    {
        Application.Quit ( );
    }
}
