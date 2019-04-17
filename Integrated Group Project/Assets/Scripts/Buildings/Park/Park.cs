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

    [SerializeField]
    private Text question_text;

    [SerializeField]
    private InputField answer_input;

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

        // Generate Questions
        if ( answered )
        {
            float value = Mathf.Floor ( Random.Range ( 11.0f, 99.0f ) );

            answer = RoundTo10 ( value );

            Debug.Log ( "Value : " + value + " Rounded : " + answer );
            question_text.text = "Round " + value + " to the nearest 10";
            answered = false;
        }
    }

    void OnTriggerEnter2D ( Collider2D collider )
    {
        if ( collider.gameObject.tag == "Player" )
        {
            zoom = true;
            zoom_to = zoom_min;

            hud_canvas.SetActive ( false );
            park_canvas.SetActive ( true );

            // player_controller.movement_enabled = false;
        }
    }

    void OnTriggerExit2D ( Collider2D collider )
    {
        if ( collider.gameObject.tag == "Player" )
        {
            zoom = true;
            zoom_to = zoom_min;

            hud_canvas.SetActive ( true );
            park_canvas.SetActive ( false );

            player_controller.movement_enabled = true;
        }
    }

    private void ZoomCamera ( )
    {
        if ( zoom )
            camera.orthographicSize = Mathf.Lerp ( camera.orthographicSize, zoom_to, Time.deltaTime );

        if ( camera.orthographicSize == zoom_to )
            zoom = false;
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

    public void OnSubmitClick ( )
    {
        int input = System.Convert.ToInt16 ( answer_input.text );
        if ( input == answer )
            Debug.Log ( "Correct" );

        answered = true;
    }
}
