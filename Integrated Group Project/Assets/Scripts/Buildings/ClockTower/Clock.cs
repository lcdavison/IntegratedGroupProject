using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private bool dragging = false;
    private RectTransform r_transform;

    public Vector2 time;

    //  Runs when the scene starts
    void Start ( )
    {
        r_transform = gameObject.GetComponent < RectTransform > ( );
    }

    //  Runs when the scene updates
    void Update ( )
    {
        //  Check if clock is being dragged
        if ( dragging )
        {
            //  Move the clock with the players finger
            r_transform.anchoredPosition = new Vector2 ( Input.mousePosition.x - Screen.width * 0.5f, Input.mousePosition.y - Screen.height * 0.5f );
        }
    }

    //  Enable dragging state
    public void OnBeginDrag ( )
    {
        dragging = true;
    }

    //  Disable dragging state
    public void OnEndDrag ( )
    {
        dragging = false;
    }
}
