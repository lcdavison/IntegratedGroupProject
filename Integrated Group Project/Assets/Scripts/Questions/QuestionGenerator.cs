using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionGenerator : MonoBehaviour
{
    [SerializeField]
    private InputField input_answer;

    [SerializeField]
    private Text question_output;

    [SerializeField]
    private Text response_output;

    [SerializeField]
    private GameObject question_ui;

    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private Text coin_output;

    [SerializeField]
    private string exit_level;  //  Level to exit to

    private int correct_answer;

    private bool answered = true;
    private bool finished = true;

    //  Start is called before the first frame update
    void Start ( )
    {
        //  Set Current Coins
        coin_output.text = "Coins : " + GameManager.GetCoins ( );
    }

    // Update is called once per frame
    void Update ( )
    {
        //  Check if the question was answered
        if ( answered )
        {
            //  Check if the screen was tapped
            if ( Input.GetMouseButtonDown ( 0 ) )
            {
                //  Adjust UI
                response_output.transform.parent.gameObject.SetActive ( false );
                question_ui.SetActive ( true );

                answered = false;
                finished = true;
            }
        }

        //  When the player is finished generate a new question
        if ( finished )
        {
            GenerateQuestion ( );
            finished = false;
        }
    }

    //  Generates a new question based on the current building
    private void GenerateQuestion ( )
    {
        //  Determine question to generate
        switch ( GameManager.current_building )
        {
            case 1:
                ChurchQuestion ( );
                break;
            case 2:
                MusicShopQuestion ( );
                break;
            case 3:
                BarQuestion ( );
                break;
        }
    }

    //  Generate a BIDMAS question
    private void ChurchQuestion ( )
    {
        //  Generate a value for operation selection
        int value = (int) ( Random.Range ( 0.0f, 4.0f ) );

        //  Question operands
        int op_a = 0, op_b = 0;

        char symbol = '+';

        //  Select operation and generate operands
        switch ( value )
        {
            case 0:
                op_b = (int) Random.Range ( 1.0f, 12.0f );
                op_a = ( (int) Random.Range ( 1.0f, 12.0f ) ) * op_b;
                correct_answer = op_a / op_b;
                symbol = '\u00f7';  //  Unicode for division symbol
                break;
            case 1:
                op_a = (int) Random.Range ( 1.0f, 12.0f );
                op_b = (int) Random.Range ( 1.0f, 12.0f );
                correct_answer = op_a * op_b;
                symbol = '*';
                break;
            case 2:
                op_a = (int) Random.Range ( 1.0f, 20.0f );
                op_b = (int) Random.Range ( 1.0f, 20.0f );
                correct_answer = op_a - op_b;
                symbol = '-';
                break;
            case 3:
                op_a = (int) Random.Range ( 1.0f, 20.0f );
                op_b = (int) Random.Range ( 1.0f, 20.0f );
                correct_answer = op_a + op_b;
                break;
        }

        SetQuestion ( "Question : " + op_a + " " + symbol + " " + op_b );
    }

    //  Generate an Area/Volume question
    private void MusicShopQuestion ( )
    {
        //  Generate a value between 0 and 1
        float rand = Random.Range ( 0.0f, 1.0f );

        //  If greater than 0.5 set to 1, else set to 0
        byte value = (byte) ( ( rand >= 0.5f ) ? 1.0f : 0.0f );

        //  Get diagram script from gameobject
        Diagram diagram = GameObject.Find ( "Diagram" ).GetComponent < Diagram > ( );

        //  Generate dimension values
        int width = (int) ( Random.Range ( 1.0f, 30.0f ) );
        int height = (int) ( Random.Range ( 1.0f, 30.0f ) );
        int length = 1;

        //  Set question and diagram based on value
        switch ( value )
        {
            case 0:
                SetQuestion ( "Find the Area of the Square" );

                diagram.SetActiveDiagram ( 0 );
                diagram.SetDimensions ( new Vector3 ( width, height, 0 ) );
                break;
            case 1:
                length = (int) ( Random.Range ( 1.0f, 30.0f ) );

                SetQuestion ( "Find the Volume of the Cube" );
                diagram.SetActiveDiagram ( 1 );
                diagram.SetDimensions ( new Vector3 ( width, height, length ) );
                break;
        }

        correct_answer = width * height * length;
    }

    //  Generate an average question
    private void BarQuestion ( )
    {
        byte [ ] values = new byte [ 5 ];

        //  Generate first random value in series
        values [ 0 ] = (byte) ( Random.Range ( 0.0f, 50.0f ) );

        correct_answer = values [ 0 ];

        //  Set next four numbers in series
        for ( int i = 1; i < 5; ++i )
        {
            values [ i ] = (byte) ( values [ i - 1 ] + 1 );
            correct_answer += values [ i ];
        }

        correct_answer /= 5;

        string question = "Find the average of : ";

        //  Append numbers in series
        for ( int i = 0; i < 5; ++i )
        {
            question += System.Convert.ToString ( values [ i ] ) + ( ( i == 4 ) ? "" : ", " );
        }

        SetQuestion ( question );
    }

    //  Set the question output text
    private void SetQuestion ( string question )
    {
        question_output.text = question;
    }

    //  Submits the players answer for checking
    public void OnClickSubmit ( )
    {
        //  Get player input
        int answer = System.Convert.ToInt16 ( input_answer.text );

        //  Check answer is correct
        int result = System.Convert.ToInt16 ( answer == correct_answer );

        if ( result == 1 )
        {
            //  Respond to correct answer
            response_output.text = "Correct";
            response_output.color = new Color ( 0.0f, 0.5f, 0.0f, 1.0f );
            GameObject.Instantiate ( coin, Vector3.zero, Quaternion.identity );
        }
        else
        {
            //  Respond to incorrect answer
            response_output.text = "Incorrect - The correct answer is " + correct_answer;
            response_output.color = new Color ( 0.5f, 0.0f, 0.0f, 1.0f );
        }

        //  Adjust UI
        response_output.transform.parent.gameObject.SetActive ( true );
        question_ui.SetActive ( false );

        answered = true;
        input_answer.text = ""; //  Reset text in input box
    }

    //  Exits the current building
    public void OnClickExit ( )
    {
        GameManager.LeaveArea ( exit_level );
    }
}
