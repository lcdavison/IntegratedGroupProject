using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    [SerializeField]
    private Text story_output;

    [SerializeField]
    [Multiline]
    private string introduction;

    private string [ ] words;
    private int word_marker = 0;
    private float last_time = 0;

    // Start is called before the first frame update
    void Start()
    {
        words = introduction.Split ( ' ' );
    }

    // Update is called once per frame
    void Update()
    {
        float current_time = Time.time;

        if ( current_time - last_time > 0.5 && word_marker < words.Length )
        {
            story_output.text += words [ word_marker++ ] + " ";
            last_time = current_time;
        }
    }
}
