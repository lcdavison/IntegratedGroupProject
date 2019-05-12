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
    private string level;   //  Level to load

    [SerializeField]
    [Multiline]
    private string [ ] introduction = new string [ 4 ];

    private string [ ] words;       //  Text blocks to display
    private int char_marker = 0;    //  Current character in word
    private int word_marker = 0;    //  Current word in text block
    private int text_marker = 0;    //  Current text block to display
    private float last_time = 0;    //  Previous update time

    // Start is called before the first frame update
    void Start ( )
    {
        //  Split the text block into words
        words = introduction [ text_marker++ ].Split ( ' ' );
    }

    // Update is called once per frame
    void Update ( )
    {
        float current_time = Time.time;

        //  Print next character if 0.1 seconds has passed
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

        //  Show continue button when text block is displayed
        if ( word_marker == words.Length )
        {
            continue_button.SetActive ( true );
        }
    }

    //  Continue to next text block
    public void OnClickContinue ( )
    {
        //  Load the level when all text has been displayed
        if ( text_marker == introduction.Length )
        {
            SceneManager.LoadScene ( level );
            return;
        }

        //  Reset word marker and load next text block
        word_marker = 0;
        words = introduction [ text_marker++ ].Split ( ' ' );
        story_output.text = "";

        //  Deactivate continue button
        continue_button.SetActive ( false );
    }
}
