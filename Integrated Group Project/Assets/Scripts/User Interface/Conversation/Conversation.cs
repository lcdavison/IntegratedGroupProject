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

    private int current_segment;    //  Current segment in conversation
    public bool no_activation = false;  //  Does conversation activate any UI

    //  Start is called before first frame update
    void Start ( )
    {
        //  Display first segment
        current_segment = 0;
        segment_display.text = script.segments [ current_segment ];
    }

    // Update is called once per frame
    void Update ( )
    {
        //  Print next conversation segment when the screen is tapped
        if ( Input.GetMouseButtonDown ( 0 ) )
        {
            ++current_segment;

            //  End conversation after all segments have been displayed
            if ( current_segment >= script.segments.Length )
            {
                //  Activate UI
                if ( !no_activation )
                    to_activate.SetActive ( true );

                //  Close conversation UI
                current_segment = 0;
                segment_display.text = script.segments [ current_segment ];

                gameObject.SetActive ( false );
                return;
            }

            //  Display next conversation segment
            segment_display.text = script.segments [ current_segment ];
        }
    }

    //  Change the script this conversation plays
    public void ChangeConversation ( ConversationScript new_script )
    {
        script = new_script;
        current_segment = 0;
        segment_display.text = script.segments [ current_segment ];
    }

    //  Set UI the conversation activates
    public void SetActivationUI ( GameObject ui_object )
    {
        to_activate = ui_object;
    }
}
