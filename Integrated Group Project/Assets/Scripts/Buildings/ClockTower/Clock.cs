using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private bool dragging = false;
    private RectTransform r_transform;

    public Vector2 time;

    void Start ( )
    {
        r_transform = gameObject.GetComponent <RectTransform> ( );
    }

    void Update ( )
    {
        if ( dragging )
        {
            r_transform.anchoredPosition = new Vector2 ( Input.mousePosition.x - Screen.width * 0.5f, Input.mousePosition.y - Screen.height * 0.5f );
        }
    }

    public void OnBeginDrag ( )
    {
        Debug.Log ( "Start Clock Drag" );
        dragging = true;
    }

    public void OnEndDrag ( )
    {
        Debug.Log ( "End Clock Drag" );
        dragging = false;
    }
}
