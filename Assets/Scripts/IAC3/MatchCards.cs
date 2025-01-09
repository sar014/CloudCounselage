using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

[System.Serializable]
public class MatchCards : MonoBehaviour
{
    public List<MatchManager> cardPairList = new List<MatchManager>();
    public int lives = 3;
    public int cardCount=0;
    public List<GameObject> livesList = new List<GameObject>();

    [SerializeField] AudioSource correctAnswer;
    [SerializeField] AudioSource wrongAnswer;
    [SerializeField] ItemSlot itemSlot1;
    [SerializeField] ItemSlot ItemSlot2;

    private string value;
    private GameObject jobCard;
    private dragdrop cardController;


    public void GetRiddleName(GameObject currentCard)
    {

        value = GetJobName(currentCard.name);
    }

    //Have to ensure that a riddle card has been placed first
    public void MatchJobs(GameObject currentCard)
    {
        cardController = currentCard.GetComponent<dragdrop>();
        if(value == currentCard.name){
            itemSlot1.ResetSlot();
            ItemSlot2.ResetSlot();
            currentCard.SetActive(false);
            jobCard.SetActive(false);

            Debug.Log("Correct");
            correctAnswer.Play();

            cardCount++;
        }
        else
        {
            Debug.Log("Wrong");
            lives--;
            livesList[0].SetActive(false);
            livesList.RemoveAt(0);
            wrongAnswer.Play();
            currentCard.GetComponent<dragdrop>().ReturnToOriginalPosition();
        }
    }

    //Find the job from the riddle 
    string GetJobName(string riddleName)
    {
        for(int j=0;j<cardPairList.Count;j++)
        {
            if(cardPairList[j].riddleCard.name.Equals(riddleName))
            {
                jobCard = cardPairList[j].riddleCard;
                return cardPairList[j].jobCard.name;
            }
        }
        return(null);
    }
}
