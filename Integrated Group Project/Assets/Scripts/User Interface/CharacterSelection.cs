using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public void OnClickMale ( )
    {
        GameManager.LoadSpriteAtlas ( GameManager.Gender.MALE );
        LoadStory ( );
    }

    public void OnClickFemale ( )
    {
        GameManager.LoadSpriteAtlas ( GameManager.Gender.FEMALE );
        LoadStory ( );
    }

    void LoadStory ( )
    {
        SceneManager.LoadScene ( "StoryIntro" );
    }
}
