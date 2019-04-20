using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Park : MonoBehaviour
{
    [SerializeField]
    private PlayerController player_controller;
    private Camera camera;

    [SerializeField]
    private GameObject hud_canvas;

    [SerializeField]
    private GameObject park_canvas;

    private bool answered = true;
    private int answer = 0;

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
        ZoomCamera ( );
    }

    void OnTriggerEnter2D ( Collider2D collider )
    {
        if ( collider.gameObject.tag == "Player" )
        {
            zoom = true;
            zoom_to = zoom_min;

            hud_canvas.SetActive ( false );
            park_canvas.SetActive ( true );

            GameManager.current_building = 2;

            player_controller.movement_enabled = false;
            player_controller.Reset ( );
        }
    }

    public void OnExitClicked ( )
    {
        zoom = true;
        zoom_to = zoom_max;

        hud_canvas.SetActive ( true );
        park_canvas.SetActive ( false );

        player_controller.movement_enabled = true;
    }

    private void ZoomCamera ( )
    {
        if ( zoom )
            camera.orthographicSize = Mathf.Lerp ( camera.orthographicSize, zoom_to, Time.deltaTime );

        if ( camera.orthographicSize == zoom_to )
            zoom = false;
    }
}