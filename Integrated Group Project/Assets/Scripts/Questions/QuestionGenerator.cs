using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionGenerator : MonoBehaviour
{
    private bool answered = true;

    [SerializeField]
    private InputField input_answer;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (answered)
        {
            GenerateQuestion();
            answered = false;
        }
    }

    private void GenerateQuestion()
    {
        Debug.Log("Generate Question");
    }

    public void OnClickSubmit()
    {

    }
}
