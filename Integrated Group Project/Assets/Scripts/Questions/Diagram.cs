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
        }
    }

    public void SetDimensions ( Vector3 new_dimensions )
    {
        dimensions [ 0 ].text = System.Convert.ToString ( new_dimensions.x );
        dimensions [ 1 ].text = System.Convert.ToString ( new_dimensions.y );
        dimensions [ 2 ].text = ( current_index == 0 ) ? " " : System.Convert.ToString ( new_dimensions.z );
    }
}
