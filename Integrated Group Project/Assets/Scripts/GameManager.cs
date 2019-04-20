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
    private static int coins = 0;               //  Current number of coins held by the player
    public static int current_building = 0;     //  Current Building ID, used for question generation
    public static bool in_conversation = false; //  Determine if player is in conversation

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
