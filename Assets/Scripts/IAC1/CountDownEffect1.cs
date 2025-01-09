using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownEffect1 : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI text;
    [SerializeField] GameObject mcqGame;
    int count = 3;
    // Start is called before the first frame update
    void Start()
    {
        ChangeEffect();
    }

    void ChangeEffect()
    {
        if(count>0)
        {
            Debug.Log(count);
            string countString = count.ToString();
            text.text = countString;
            animator.SetTrigger("FadeOut");
            StartCoroutine(SlowDown()); 
        }
        else
        {
             mcqGame.SetActive(true);
        }
    }

    IEnumerator SlowDown()
    {
        yield return new WaitForSeconds(1f);
        count--;
        ChangeEffect();
    }
}
