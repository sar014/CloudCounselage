using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    int QCount=0;
    int dictIndex;
    QuestionAndAnswer selectedQnA;
    
    [SerializeField] List<RawImage> lifeSprites;

    //List of Questions and the answers
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public ChangeVIdeoScript changeVIdeoScript;
    public TextMeshProUGUI QuestionTxt;
    public int lives = 3;
    public Dictionary<int,List<QuestionAndAnswer>> Global = new Dictionary<int,List<QuestionAndAnswer>>();

    //When game ends.
    public AudioSource StopBackgrounMusic;  //Stop the backgroundmusic when the game ends so that the error message appers more realistic
    public EndScreen endScreen;
    [SerializeField] GameObject GameOverScreen;

    private void Start() 
    {
        Global.Add(0,new List<QuestionAndAnswer> { QnA[0], QnA[1], QnA[2] });
        Global.Add(1,new List<QuestionAndAnswer> { QnA[3], QnA[4], QnA[5] });
        Global.Add(2,new List<QuestionAndAnswer> { QnA[6], QnA[7], QnA[8] });
        generateQuestion();
    }

    public void correct()
    {
        QCount++;
        if (Global.ContainsKey(dictIndex) && QCount < Global[dictIndex].Count)
        {
            generateQuestion();
        }
        else
        {
            GameOverScreen.SetActive(true);
            StopBackgrounMusic.Stop();
            endScreen.StartShowingErrors("You Win !!!");
        }
    }

    void SetAnswers()
    {
        for(int i = 0; i < options.Length;i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;

            //Setting options
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = selectedQnA.Answers[i];

            //Setting the isCorrect variable to True for the button which is correct.
            if(selectedQnA.CorrectAnswer==i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public void CountLives()
    {
        lives--;
        lifeSprites[lives].gameObject.SetActive(false);
        Debug.Log("Lives "+lives);
        if(lives == 0)
        {
            GameOverScreen.SetActive(true);
            StopBackgrounMusic.Stop();
            endScreen.StartShowingErrors("Game Over !!!");
        }
        
    }

    void generateQuestion()
    {
        //Getting the index of the video playing
        dictIndex = changeVIdeoScript.randomIndex;

        //Accessing the questions assigned to particular key of the dictionary
        if(Global.ContainsKey(dictIndex) && Global[dictIndex].Count > 0)
        {

            //get the question in the list
            selectedQnA = Global[dictIndex][QCount];
            Debug.Log(QCount);
        
            // Displaying the question
            QuestionTxt.text = selectedQnA.Question;


            SetAnswers();
        }
    }
}
