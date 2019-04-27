using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  TODO: Perhaps use some buttons for selecting answers
//  TODO: Include some more drag and drop interactivity

public class QuestionGenerator : MonoBehaviour
{
    private bool answered = true;

    [SerializeField]
    private InputField input_answer;

    [SerializeField]
    private Text question_output;

    private int correct_answer;

    [SerializeField]
    private string exit_level;  //  Level to exit to

    // Update is called once per frame
    void Update()
    {
        if ( answered )
        {
            GenerateQuestion ( );
            answered = false;
        }
    }

    private void GenerateQuestion ( )
    {
        Debug.Log( "Generate Question" );

        switch ( GameManager.current_building )
        {
            case 0:
                ParkQuestion ( );
                break;
            case 1:
                ChurchQuestion ( );
                break;
            case 2:
                MusicShopQuestion ( );
                break;
            case 3:
                BarQuestion ( );
                break;
            case 4:
                BankQuestion ( );
                break;
        }

        Debug.Log ( correct_answer );
    }

    private void ChurchQuestion ( )
    {
        float rand = Random.Range ( 0.0f, 4.0f );
        Debug.Log ( "Random Value : " + rand );

        int value = ( int ) Mathf.Floor ( rand );

        int op_a = 0, op_b = 0;

        char symbol = '+';

        switch ( value )
        {
            case 0:
                Debug.Log ( "QUOT" );
                op_b = (int) Random.Range ( 1.0f, 12.0f );
                op_a = ( (int) Random.Range ( 1.0f, 12.0f ) ) * op_b;
                correct_answer = op_a / op_b;
                symbol = '\u00f7';
                break;
            case 1:
                Debug.Log ( "PROD" );
                op_a = (int) Random.Range ( 1.0f, 12.0f );
                op_b = (int) Random.Range ( 1.0f, 12.0f );
                correct_answer = op_a * op_b;
                symbol = '*';
                break;
            case 2:
                Debug.Log ( "DIFF" );
                op_a = (int) Random.Range ( 1.0f, 20.0f );
                op_b = (int) Random.Range ( 1.0f, 20.0f );
                correct_answer = op_a - op_b;
                symbol = '-';
                break;
            case 3:
                Debug.Log ( "SUM" );
                op_a = (int) Random.Range ( 1.0f, 20.0f );
                op_b = (int) Random.Range ( 1.0f, 20.0f );
                correct_answer = op_a + op_b;
                break;
        }

        question_output.text = "Question : " + op_a + " " + symbol + " " + op_b;
    }

    private void ParkQuestion ( )
    {
        float value = Mathf.Floor ( Random.Range ( 11.0f, 99.0f ) );

        correct_answer = RoundTo10 ( value );

        Debug.Log ( "Value : " + value + " Rounded : " + correct_answer );
        question_output.text = "Round " + value + " to the nearest 10";
    }

    private void MusicShopQuestion ( )
    {
        float rand = Random.Range ( 0.0f, 1.0f );

        byte value = (byte) ( ( rand >= 0.5f ) ? 1.0f : 0.0f );

        Diagram diagram = GameObject.Find ( "Diagram" ).GetComponent < Diagram > ( );

        int width = (int) ( Random.Range ( 1.0f, 30.0f ) );
        int height = (int) ( Random.Range ( 1.0f, 30.0f ) );
        int length = 1;

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

    private void BarQuestion ( )
    {
        byte [ ] values = new byte [ 5 ];
        values [ 0 ] = (byte) ( Random.Range ( 0.0f, 50.0f ) );

        correct_answer = values [ 0 ];
        for ( int i = 1; i < 5; ++i )
        {
            values [ i ] = (byte) ( values [ i - 1 ] + 1 );
            correct_answer += values [ i ];
        }

        correct_answer /= 5;

        string question = "Find the average of : ";

        for ( int i = 0; i < 5; ++i )
        {
            question += System.Convert.ToString ( values [ i ] ) + ( ( i == 4 ) ? "" : ", " );
        }

        SetQuestion ( question );
    }

    private void BankQuestion ( )
    {
        //  TODO: Question On Currency
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

    private void SetQuestion ( string question )
    {
        question_output.text = question;
    }

    public void OnClickSubmit()
    {
        int answer = System.Convert.ToInt16 ( input_answer.text );
        int result = System.Convert.ToInt16 ( answer == correct_answer );

        GameManager.AddCoins ( result );

        if ( result == 1 )
            Debug.Log ( "Correct" );
        else
            Debug.Log ( "Incorrect" );

        answered = true;
    }

    public void OnClickExit ( )
    {
        GameManager.LoadBuilding ( exit_level );
    }
}
