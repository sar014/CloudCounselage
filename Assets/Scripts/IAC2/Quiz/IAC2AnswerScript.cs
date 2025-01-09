using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAC2AnswerScript : MonoBehaviour
{
    public AudioSource errorSound;
    public bool isCorrect;
    public IAC2QuizManager quizManager;
    public void Answer()
    {
        if(isCorrect)
        {
            // Debug.Log("Correct");
            quizManager.correct();
        }
        else
        {
            errorSound.Play();
            Debug.Log("Wrong");
            // quizManager.CountLives();
        }
    }
}
