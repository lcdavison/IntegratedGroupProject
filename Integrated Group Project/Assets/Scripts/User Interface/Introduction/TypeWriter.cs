using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypeWriter : MonoBehaviour
{
    [SerializeField]
    private Text story_output;

    [SerializeField]
    private GameObject continue_button;

    [SerializeField]
    private string level;

    [SerializeField]
    [Multiline]
    private string [ ] introduction = new string [ 4 ];

    private string [ ] words;
    private int char_marker = 0;
    private int word_marker = 0;
    private int text_marker = 0;
    private float last_time = 0;

    // Start is called before the first frame update
    void Start ( )
    {
        words = introduction [ text_marker++ ].Split ( ' ' );
    }

    // Update is called once per frame
    void Update ( )
    {
        float current_time = Time.time;

        if ( current_time - last_time > 0.1f && word_marker < words.Length )
        {
            //  Cache the word
            string word = words [ word_marker ];

            //  Add character at char_marker, to the screen
            story_output.text += word [ char_marker++ ];

            //  Reset if the next word should be drawn
            if ( char_marker >= word.Length )
            {
                char_marker = 0;
                word_marker++;
                story_output.text += " ";
            }

            //  Update last update time
            last_time = current_time;
        }

        if ( word_marker == words.Length )
        {
            continue_button.SetActive ( true );
        }
    }

    public void OnClickContinue ( )
    {
        if ( text_marker == introduction.Length )
        {
            SceneManager.LoadScene ( level );
            return;
        }

        word_marker = 0;
        words = introduction [ text_marker++ ].Split ( ' ' );
        story_output.text = "";

        continue_button.SetActive ( false );
    }
}
