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

    private float euros;
    private float yuan;
    private float dollars;

    private float correct_answer = 0;

    private bool answered = false;
    private bool paid_ransom = false;

    private byte completed;

    void Start ( )
    {
        euros = yuan = dollars = GameManager.GetCoins ( ) / 3;
        completed = 0;

        if ( GameManager.money_converted )
        {
            euro_object.SetActive ( false );
            yuan_object.SetActive ( false );
            dollar_object.SetActive ( false );
        }
    }

    void Update ( )
    {
        if ( answered )
        {
            if ( Input.GetMouseButtonDown ( 0 ) )
            {
                response_output.gameObject.SetActive ( false );
                main_ui.SetActive ( true );
                question_ui.SetActive ( false );
                question_container.SetActive ( true );

                completed++;

                answered = false;

                if ( completed == 3 && GameManager.GetPounds ( ) >= 10.0f )
                {
                    GameManager.money_converted = true;
                    paid_ransom = true;
                }
                else
                {
                    main_ui.SetActive ( false );
                    conversation.ChangeConversation ( GameManager.LoadConversation ( "NotEnough" ) );
                    conversation.SetActivationUI ( main_ui );

                    conversation.gameObject.SetActive ( true );
                }
            }
        }
    }

    public void OnClickEuropean ( )
    {
        conversation.ChangeConversation ( GameManager.LoadConversation ( "Euro" ) );
        conversation.SetActivationUI ( question_ui );

        conversation.gameObject.SetActive ( true );

        question_output.text = "Convert your " + euros + " Euros to Great British Pounds, the exchange rate is £0.86 to the Euro";
        correct_answer = euros * 0.86f;

        GameManager.AddPounds ( correct_answer );

        main_ui.SetActive ( false );
        euro_object.SetActive ( false );
    }

    public void OnClickChinese ( )
    {
        conversation.ChangeConversation ( GameManager.LoadConversation ( "Yuan" ) );
        conversation.SetActivationUI ( question_ui );

        conversation.gameObject.SetActive ( true );

        question_output.text = "Convert your " + yuan + " Yuan to Great British Pounds, the exchange rate is £0.11 to the Yuan";
        correct_answer = yuan * 0.11f;

        GameManager.AddPounds ( correct_answer );

        main_ui.SetActive ( false );
        yuan_object.SetActive ( false );
    }

    public void OnClickAmerican ( )
    {
        conversation.ChangeConversation ( GameManager.LoadConversation ( "Dollar" ) );
        conversation.SetActivationUI ( question_ui );

        conversation.gameObject.SetActive ( true );

        question_output.text = "Convert your " + dollars + " Dollars to Great British Pounds, the exchange rate is £0.77 to the Dollar";
        correct_answer = yuan * 0.77f;

        GameManager.AddPounds ( correct_answer );

        main_ui.SetActive ( false );
        dollar_object.SetActive ( false );
    }

    public void OnClickSubmit ( )
    {
        float answer = float.Parse ( answer_input.text );

        question_container.SetActive ( false );
        response_output.gameObject.SetActive ( true );

        if ( answer == correct_answer )
        {
            GameManager.AddPounds ( correct_answer );
            response_output.text = "Correct";
        }
        else
        {
            response_output.text = "Incorrect : Correct answer is " + correct_answer;
        }

        answered = true;
    }

    public void OnClickExit ( )
    {
        if ( paid_ransom )
            GameManager.LeaveArea ( "EndScreen" );
        else
            GameManager.LeaveArea ( "lvlThree" );
    }
}
