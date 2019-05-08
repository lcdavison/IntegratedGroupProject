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
    private static float pounds = 0;            //  Current number of pounds converted by player

    public static int current_building = 0;     //  Current Building ID, used for question generation
    public static bool money_converted = false;
    public static bool leaving = false;
    public static Stack < Vector3 > spawn_positions = new Stack < Vector3 > ( );

    public static SpriteAtlas player_sprite;

    public static void AddCoins ( int amount )
    {
        coins += amount;
    }

    public static int GetCoins ( )
    {
        return coins;
    }

    public static void AddPounds ( float amount )
    {
        pounds += amount;
    }

    public static float GetPounds ( )
    {
        return pounds;
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

    public static void EnterArea ( string area, Vector3 position )
    {
        spawn_positions.Push ( position );
        SceneManager.LoadScene ( area );
    }

    public static void LeaveArea ( string area )
    {
        SceneManager.LoadScene ( area );
        leaving = true;
    }
}
