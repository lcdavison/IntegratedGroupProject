using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Park : MonoBehaviour
{
    [SerializeField]
    private PlayerController player_controller;

    [SerializeField]
    private GameObject hud_canvas;

    [SerializeField]
    private GameObject conversation_canvas;

    [SerializeField]
    private GameObject park_canvas;

    [SerializeField]
    private Text question_output;

    [SerializeField]
    private Text coin_text;

    [SerializeField]
    private GameObject coin;

    private Vector3 swipe_start;    //  Swipe start position

    private float start_value;  //  The number to round

    private bool answered = true;
    private int player_answer = 0;
    private int correct_answer = 0;

    private bool zoom = false;      //  Should camera zoom?
    private float zoom_to = 0.0f;   //  Current point to zoom to

    public float zoom_min = 2.0f;   //  Minimum zoom point
    public float zoom_max = 5.0f;   //  Maximum zoom point

    //  Update is called once per frame
    void Update ( )
    {
        if ( answered )
        {
            //  Update coin text
            coin_text.text = "Coins : " + GameManager.GetCoins ( );

            GenerateQuestion ( );
        }

        ZoomCamera ( );
    }

    //  Detects objects that enter trigger zone
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

    //  Detects the start of a swipe
    public void OnBeginSwipe ( )
    {
        swipe_start = Input.mousePosition;
    }

    //  Detects the direction of the swipe
    public void OnEndSwipe ( )
    {
        Vector3 swipe = Input.mousePosition - swipe_start;  //  Calculate vector in swipes direction

        //  Determines the swipe direction
        if ( swipe.x > 0.0f )
            player_answer = ( (int) ( Mathf.Ceil ( start_value / 10 ) ) ) * 10;    //  Round the player_answer up
        else if ( swipe.x < 0.0f )
            player_answer = ( (int) ( Mathf.Floor ( start_value / 10 ) ) ) * 10;   //  Round the player_answer down

        //  Check player_answer
        if ( player_answer == correct_answer )
        {
            //  Spawn a coin
            GameObject new_coin = GameObject.Instantiate ( coin, gameObject.transform.position, Quaternion.identity );
            new_coin.transform.localScale = new Vector3 ( 0.5f, 0.5f, 0.5f );
        }

        answered = true;
    }

    //  Exits the park
    public void OnExitClicked ( )
    {
        //  Zoom Out
        zoom = true;
        zoom_to = zoom_max;

        //  Adjust user interface
        hud_canvas.SetActive ( true );
        conversation_canvas.SetActive ( false );
        park_canvas.SetActive ( false );

        //  Enable player movement
        player_controller.movement_enabled = true;
    }

    //  Zooms camera from a point to another
    private void ZoomCamera ( )
    {
        //  Interpolate to zoom destination
        if ( zoom )
            Camera.main.orthographicSize = Mathf.Lerp ( Camera.main.orthographicSize, zoom_to, Time.deltaTime );

        //  Stop zooming when at zoom destination
        if ( Camera.main.orthographicSize == zoom_to )
            zoom = false;
    }

    //  Generates a new question
    private void GenerateQuestion ( )
    {
        answered = false;

        //  Calculate a starting value
        start_value = Mathf.Floor ( Random.Range ( 11.0f, 99.0f ) );

        //  Check if number is already the nearest 10
        if ( ( start_value / 10.0f - (int) ( start_value / 10.0f ) ) == 0.0f )
        {
            start_value++;
        }

        //  Calculate correct answer
        correct_answer = RoundTo10 ( start_value );

        //  Set question text
        question_output.text = "Round " + start_value + " to the nearest 10";
    }

    //  Rounds a number to the nearest 10
    private int RoundTo10 ( float value )
    {
        //  Divide by 10 e.g. 13 / 10 = 1.3
        float tens = value / 10.0f;

        //  Round down with int cast e.g. 1.3 = 1
        int rounded = ( ( int ) tens ) * 10;

        //  Round up if unit value is greater than or equal to 5
        if ( ( tens - ( int ) tens ) >= 0.5f )
            rounded = ( ( int ) tens + 1 ) * 10;

        //  Return the rounded value
        return rounded;
    }
}
