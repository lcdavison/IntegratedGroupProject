using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public enum Gender
    {
        MALE,
        FEMALE
    };

    private static int coins = 0;               //  Current number of coins held by the player
    public static int current_building = 0;     //  Current Building ID, used for question generation
    public static bool in_conversation = false; //  Determine if player is in conversation

    public static SpriteAtlas player_sprite;

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

    public static void LoadSpriteAtlas ( Gender gender )
    {
        switch ( gender )
        {
            case Gender.MALE:
                player_sprite = Resources.Load ( "Spritesheets/Boy" ) as SpriteAtlas;
                break;
            case Gender.FEMALE:
                player_sprite = Resources.Load ( "Spritesheets/Girl" ) as SpriteAtlas;
                break;
        }
    }

    public static ConversationScript LoadConversation ( string name )
    {
        return Resources.Load ( "Conversations/" + name ) as ConversationScript;
    }
}
