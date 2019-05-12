using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    //  Set player to male sprite
    public void OnClickMale ( )
    {
        GameManager.LoadSpriteAtlas ( GameManager.Gender.MALE );
        LoadStory ( );
    }

    //  Set player to female sprite
    public void OnClickFemale ( )
    {
        GameManager.LoadSpriteAtlas ( GameManager.Gender.FEMALE );
        LoadStory ( );
    }

    //  Load the story scene
    void LoadStory ( )
    {
        SceneManager.LoadScene ( "StoryIntro" );
    }
}
