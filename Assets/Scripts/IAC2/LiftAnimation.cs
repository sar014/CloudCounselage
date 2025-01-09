using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LiftAnimation : MonoBehaviour
{    
    public TextMeshProUGUI liftText;
    public Animator animator;
    public IAC2QuizManager quizManager;

    [SerializeField] int count = 1;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        DisplayLiftText();
    }

    void DisplayLiftText()
    {
        if(quizManager.playAnimation)
        {
            //When this animation plays, UpdateLiftText also plays because it is an animation event
            animator.SetTrigger("CorrectAns");

            //Resets animtion
            quizManager.playAnimation = false;
        }
    }

    //Part of animation event.
    public void UpdateLiftText()
    {
        if(count<=3)
        {
            count++;
            string text = "Level " +count.ToString();
            liftText.text = text;
        }
      
    }
}
