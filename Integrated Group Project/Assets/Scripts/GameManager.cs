using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    /*
          Have a reference to a class for the player, that contains all the player's data.
          e.g.
          Name
          Coins
          Score
          etc.
    */

    public static void LoadBuilding ( string level_string )
    {
        SceneManager.LoadScene ( level_string );
    }
}
