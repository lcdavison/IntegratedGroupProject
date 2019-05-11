using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    [SerializeField]
    private GameObject question_ui;

    [SerializeField]
    private GameObject main_ui;

    [SerializeField]
    private Text question_output;

    [SerializeField]
    private Text response_output;

    [SerializeField]
    private InputField answer_input;

    [SerializeField]
    private Conversation conversation;

    [SerializeField]
    private GameObject euro_object;

    [SerializeField]
    private GameObject yuan_object;

    [SerializeField]
    private GameObject dollar_object;

    [SerializeField]
    private GameObject question_container;

    //  Currency values
    private float euros;
    private float yuan;
    private float dollars;

    private float correct_answer = 0;

    private bool answered = false;
    private bool paid_ransom = false;

    private byte completed; //  The number of currencies that have been converted

    //  Runs when the level starts
    void Start ( )
    {
        //  Set each currency to one third of the players collected coins
        euros = yuan = dollars = GameManager.GetCoins ( ) / 3;

        //  Set converted currencies to zero
        completed = 0;

        //  Don't allow the player to convert coins, if they're already converted
        if ( GameManager.money_converted )
        {
            euro_object.SetActive ( false );
            yuan_object.SetActive ( false );
            dollar_object.SetActive ( false );
        }
    }

    //  Runs once per frame
    void Update ( )
    {
        //  Check if player has answered the question
        if ( answered )
        {
            //  Checks if the screen is tapped
            if ( Input.GetMouseButtonDown ( 0 ) )
            {
                //  Adjust UI
                response_output.gameObject.SetActive ( false );
                main_ui.SetActive ( true );
                question_ui.SetActive ( false );
                question_container.SetActive ( true );

                //  Increase completed conversions
                completed++;

                answered = false;

                //  Check if all currencies are converted
                if ( completed == 3 )
                {
                    GameManager.money_converted = true;

                    //  Pay the ransom
                    if ( GameManager.GetPounds ( ) >= 10.0f )
                        paid_ransom = true;
                }
                else
                {
                    //  Show conversation if target amount is not met
                    main_ui.SetActive ( false );
                    conversation.ChangeConversation ( GameManager.LoadConversation ( "NotEnough" ) );
                    conversation.SetActivationUI ( main_ui );

                    conversation.gameObject.SetActive ( true );
                }
            }
        }
    }

    //  Starts the conversion from Euro to GBP
    public void OnClickEuropean ( )
    {
        //  Setup and show conversation
        conversation.ChangeConversation ( GameManager.LoadConversation ( "Euro" ) );
        conversation.SetActivationUI ( question_ui );

        conversation.gameObject.SetActive ( true );

        //  Display question
        question_output.text = "Convert your " + euros + " Euros to Great British Pounds, the exchange rate is £0.86 to the Euro";
        correct_answer = euros * 0.86f;

        //  Adjust UI
        main_ui.SetActive ( false );
        euro_object.SetActive ( false );
    }

    //  Starts the conversion from Yuan to GBP
    public void OnClickChinese ( )
    {
        //  Setup and show conversation
        conversation.ChangeConversation ( GameManager.LoadConversation ( "Yuan" ) );
        conversation.SetActivationUI ( question_ui );

        conversation.gameObject.SetActive ( true );

        //  Display question
        question_output.text = "Convert your " + yuan + " Yuan to Great British Pounds, the exchange rate is £0.11 to the Yuan";
        correct_answer = yuan * 0.11f;

        //  Adjust UI
        main_ui.SetActive ( false );
        yuan_object.SetActive ( false );
    }

    //  Starts the conversion from Dollars to GBP
    public void OnClickAmerican ( )
    {
        //  Setup and show conversation
        conversation.ChangeConversation ( GameManager.LoadConversation ( "Dollar" ) );
        conversation.SetActivationUI ( question_ui );

        conversation.gameObject.SetActive ( true );

        //  Display question
        question_output.text = "Convert your " + dollars + " Dollars to Great British Pounds, the exchange rate is £0.77 to the Dollar";
        correct_answer = dollars * 0.77f;

        //  Adjust UI
        main_ui.SetActive ( false );
        dollar_object.SetActive ( false );
    }

    //  Submits the players answer to be checked
    public void OnClickSubmit ( )
    {
        string input = answer_input.text;

        //  Check if user has entered an answer
        if ( System.String.IsNullOrEmpty ( input ) )
            return;

        //  Convert the string to a float
        float answer = float.Parse ( input );

        //  Adjust UI
        question_container.SetActive ( false );
        response_output.gameObject.SetActive ( true );

        //  Check answer
        if ( answer == correct_answer )
        {
            //  Add converted amount
            GameManager.AddPounds ( correct_answer );
            response_output.text = "Correct";
            response_output.color = new Color ( 0.0f, 0.5f, 0.0f, 1.0f );
        }
        else
        {
            //  Present the correct answer to the player
            response_output.text = "Incorrect : Correct answer is " + correct_answer;
            response_output.color = new Color ( 0.5f, 0.0f, 0.0f, 1.0f );
        }

        answered = true;
    }

    //  Exits the building
    public void OnClickExit ( )
    {
        //  Check if the ransom is paid
        if ( paid_ransom )
            GameManager.LeaveArea ( "EndScreen" );  //  Start the end game
        else
            GameManager.LeaveArea ( "lvlThree" );   //  Return to level three
    }
}
