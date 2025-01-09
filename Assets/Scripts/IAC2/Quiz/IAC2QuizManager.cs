using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IAC2QuizManager : MonoBehaviour
{
    int QCount=0;
    int dictIndex;
    QuestionAndAnswer selectedQnA;

    //List of Questions and the answers
    public List<QuestionAndAnswer> QnA;
    public Dictionary<int,List<QuestionAndAnswer>> Global = new Dictionary<int,List<QuestionAndAnswer>>();
    public GameObject[] options;
    public TextMeshProUGUI QuestionTxt;
    public int lives = 3;
    public int currentQuestion;

    //Outside Environment
    public GameObject OutsideBuildingEnvironment;
    

    /// <summary>
    /// On Successfully answering all questions:
    /// </summary>
    public Animator openDoor1;
    public Animator openDoor2;

    //For Changing the lift text animation
    public bool playAnimation;
    // Start is called before the first frame update
    void Start()
    {
        Global.Add(0,new List<QuestionAndAnswer> { QnA[0],QnA[1],QnA[2]});
        // Global.Add(1,new List<QuestionAndAnswer> { QnA[3], QnA[4], QnA[5] });
        // Global.Add(2,new List<QuestionAndAnswer> { QnA[6], QnA[7], QnA[8] });
        generateQuestion();
    }

    void SetAnswers()
    {
        for(int i = 0; i < options.Length;i++)
        {
            options[i].GetComponent<IAC2AnswerScript>().isCorrect = false;

            //Setting options
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = selectedQnA.Answers[i];

            //Setting the isCorrect variable to True for the button which is correct.
            if(selectedQnA.CorrectAnswer==i+1)
            {
                options[i].GetComponent<IAC2AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        //Getting the index of the video playing
        dictIndex = 0;

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

    public void correct()
    {
        QCount++;
        if (Global.ContainsKey(dictIndex) && QCount < Global[dictIndex].Count)
        {
            playAnimation = true;
            generateQuestion();
        }
        else
        {
            this.GetComponentInChildren<Camera>().enabled = false;
            this.GetComponentInChildren<Canvas>().enabled = false;
            openDoor1.SetTrigger("Win");
            openDoor2.SetTrigger("Win");

            //Moving to outside environment after winning
            OutsideBuildingEnvironment.SetActive(true);
        }
    }
}
