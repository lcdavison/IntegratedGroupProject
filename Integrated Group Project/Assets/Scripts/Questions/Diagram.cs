using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diagram : MonoBehaviour
{
    [SerializeField]
    private Sprite [ ] diagrams = new Sprite [ 2 ];

    [SerializeField]
    private Text [ ] dimensions = new Text [ 3 ];

    private SpriteRenderer sprite_renderer;
    private byte current_index;     //  The current active diagram

    // Start is called before the first frame update
    void Start ( )
    {
        sprite_renderer = gameObject.GetComponent < SpriteRenderer > (  );
    }

    //  Changes the diagram that will be displayed
    public void SetActiveDiagram ( byte index )
    {
        if ( index < diagrams.Length )
        {
            sprite_renderer.sprite = diagrams [ index ];
            current_index = index;
        }
    }

    //  Sets the text for the dimensions of the diagram
    public void SetDimensions ( Vector3 new_dimensions )
    {
        dimensions [ 0 ].text = "Width : " + System.Convert.ToString ( new_dimensions.x );      //  Set width text
        dimensions [ 1 ].text = "Height : " + System.Convert.ToString ( new_dimensions.y );     //  Set height text
        dimensions [ 2 ].text = ( current_index == 0 ) ? " " : "Length : " + System.Convert.ToString ( new_dimensions.z );  //  Set length text, when cube diagram is active
    }
}
