using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
    [SerializeField]
    private Text segment_display;

    private int current_segment = 0;
    private bool next_segment = true;

    public string [ ] segments = new string [ 5 ];

    // Update is called once per frame
    void Update()
    {
        if ( next_segment )
        {
            segment_display.text = segments [ current_segment++ ];
        }
    }
}