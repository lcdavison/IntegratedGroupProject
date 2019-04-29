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
    private byte current_index;

    // Start is called before the first frame update
    void Start ( )
    {
        sprite_renderer = gameObject.GetComponent < SpriteRenderer > (  );
    }

    public void SetActiveDiagram ( byte index )
    {
        if ( index < diagrams.Length )
        {
            sprite_renderer.sprite = diagrams [ index ];
            current_index = index;

            Vector3 width_position = dimensions [ 0 ].gameObject.transform.localPosition;
            Vector3 height_position = dimensions [ 1 ].gameObject.transform.localPosition;

            width_position.y = -255.0f;
            height_position.x = -405.0f;

            if ( index == 1 )
            {
                //  Set Positions of Text
                width_position.y = -210.0f;
                height_position.x = -355.0f;
            }

            dimensions [ 0 ].gameObject.transform.localPosition = width_position;
            dimensions [ 1 ].gameObject.transform.localPosition = height_position;
        }
    }

    public void SetDimensions ( Vector3 new_dimensions )
    {
        dimensions [ 0 ].text = "Width : " + System.Convert.ToString ( new_dimensions.x );
        dimensions [ 1 ].text = "Height : " + System.Convert.ToString ( new_dimensions.y );
        dimensions [ 2 ].text = ( current_index == 0 ) ? " " : "Length : " + System.Convert.ToString ( new_dimensions.z );
    }
}
