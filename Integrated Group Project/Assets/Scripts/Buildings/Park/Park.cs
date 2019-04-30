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
    private GameObject conversation_canvas;

    [SerializeField]
    private GameObject park_canvas;

    [SerializeField]
    private Text question_output;

    private Vector3 swipe_start;
    private float start_value;

    private bool answered = true;
    private int answer = 0;
    private int correct_answer = 0;

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
        if ( answered )
        {
            GenerateQuestion ( );
        }

        ZoomCamera ( );
    }

    void OnTriggerEnter2D ( Collider2D collider )
    {
        if ( collider.gameObject.tag == "Player" )
        {
            zoom = true;
            zoom_to = zoom_min;

            hud_canvas.SetActive ( false );
            conversation_canvas.SetActive ( true );

            GameManager.current_building = 0;

            player_controller.movement_enabled = false;
            player_controller.Reset ( );
        }
    }

    public void OnExitClicked ( )
    {
        zoom = true;
        zoom_to = zoom_max;

        hud_canvas.SetActive ( true );
        conversation_canvas.SetActive ( false );
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

    private void GenerateQuestion ( )
    {
        answered = false;
        start_value = Mathf.Floor ( Random.Range ( 11.0f, 99.0f ) );

        correct_answer = RoundTo10 ( start_value );

        Debug.Log ( "Value : " + start_value + " Rounded : " + correct_answer );
        question_output.text = "Round " + start_value + " to the nearest 10";
    }

    private int RoundTo10 ( float value )
    {
            float tens = value / 10.0f;

            //  Round Down
            int rounded = ( ( int ) tens ) * 10;

            //  Round Up
            if ( ( tens - ( int ) tens ) >= 0.5f )
                rounded = ( ( int ) tens + 1 ) * 10;

            return rounded;
    }

    public void OnBeginSwipe ( )
    {
        swipe_start = Input.mousePosition;
    }

    public void OnEndSwipe ( )
    {
        Vector3 swipe = Input.mousePosition - swipe_start;

        if ( swipe.x > 0.0f )
            answer = ( (int) ( Mathf.Ceil ( start_value / 10 ) ) ) * 10;
        else if ( swipe.x < 0.0f )
            answer = ( (int) ( Mathf.Floor ( start_value / 10 ) ) ) * 10;

        //  Check Answer
        if ( answer == correct_answer )
            Debug.Log ( "Correct" );

        answered = true;
    }
}
