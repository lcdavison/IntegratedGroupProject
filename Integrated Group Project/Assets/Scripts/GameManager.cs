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
    private static int coins = 0;

    public static void AddCoins ( int amount )
    {
        coins += amount;
    }

    public static int GetCoins ( )
    {
        return coins;
    }

    public static void LoadBuilding ( string level_string )
    {
        SceneManager.LoadScene ( level_string );
    }
}
