using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
    [SerializeField]
    private Text segment_display;

    [SerializeField]
    private GameObject to_activate;

    private int current_segment;
    private bool next_segment = true;

    [SerializeField]
    private ConversationScript script;

    void Start ( )
    {
        current_segment = 0;
        segment_display.text = script.segments [ current_segment ];
    }

    // Update is called once per frame
    void Update ( )
    {
        if ( Input.GetMouseButtonDown ( 0 ) )
        {
            ++current_segment;

            if ( current_segment >= script.segments.Length )
            {
                to_activate.SetActive ( true );
                gameObject.SetActive ( false );
                return;
            }

            segment_display.text = script.segments [ current_segment ];
        }
    }
}
