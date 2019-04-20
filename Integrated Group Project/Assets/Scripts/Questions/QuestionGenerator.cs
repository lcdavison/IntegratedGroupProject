using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  TODO: Cleanup

public class QuestionGenerator : MonoBehaviour
{
    private bool answered = true;

    [SerializeField]
    private InputField input_answer;

    [SerializeField]
    private Text question_output;

    private int correct_answer;

    // Use this for initialization
    void Start()
    {
    }

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
            case 1:
                ChurchQuestion ( );
                break;
            case 2:
                ParkQuestion ( );
                break;
        }
        
        Debug.Log ( correct_answer );
    }

    void ChurchQuestion ( )
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

    void ParkQuestion ( )
    {
        float value = Mathf.Floor ( Random.Range ( 11.0f, 99.0f ) );

        correct_answer = RoundTo10 ( value );

        Debug.Log ( "Value : " + value + " Rounded : " + correct_answer );
        question_output.text = "Round " + value + " to the nearest 10";
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
}
