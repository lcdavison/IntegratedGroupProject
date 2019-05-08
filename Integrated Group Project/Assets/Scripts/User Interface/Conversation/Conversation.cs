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

    [SerializeField]
    private ConversationScript script;

    private int current_segment;
    public bool no_activation = false;

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
                if ( !no_activation )
                    to_activate.SetActive ( true );

                current_segment = 0;
                segment_display.text = script.segments [ current_segment ];

                gameObject.SetActive ( false );
                return;
            }

            segment_display.text = script.segments [ current_segment ];
        }
    }

    public void ChangeConversation ( ConversationScript new_script )
    {
        script = new_script;
        current_segment = 0;
        segment_display.text = script.segments [ current_segment ];
    }

    public void SetActivationUI ( GameObject ui_object )
    {
        to_activate = ui_object;
    }
}
