using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Park : MonoBehaviour
{
    private PlayerController player_controller;
    private Camera camera;
    private bool zoom = false;
    private float zoom_to = 0.0f;

    public float zoom_min = 2.0f;
    public float zoom_max = 5.0f;

    void Start ( )
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if ( zoom )
            camera.orthographicSize = Mathf.Lerp ( camera.orthographicSize, zoom_to, Time.deltaTime );

        if ( camera.orthographicSize == zoom_to )
            zoom = false;
    }

    void OnTriggerEnter2D ( Collider2D collider )
    {
        if ( collider.gameObject.tag == "Player" )
        {
            zoom = true;
            zoom_to = zoom_min;
            player_controller.movement_enabled = false;
        }
    }

    void OnTriggerExit2D ( Collider2D collider )
    {
        if ( collider.gameObject.tag == "Player" )
        {
            zoom = true;
            zoom_to = zoom_min;

            player_controller.movement_enabled = true;
        }
    }
}
