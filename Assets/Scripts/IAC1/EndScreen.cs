using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOver;
    [SerializeField] AudioSource audioSource;
    public List<GameObject> errorImages;
    public GameObject FinalImage;
    public float displayTime = 3f; 

    public void StartShowingErrors(string text)
    {
        if (errorImages.Count > 0)
        {
            StartCoroutine(ShowErrorMessages());
        }

        gameOver.text = text;
        
    }

    IEnumerator ShowErrorMessages()
    {
        for(int i=0;i<errorImages.Count;i++)
        {
            audioSource.Play();
            GameObject image = errorImages[i];
            image.SetActive(true);
            yield return new WaitForSeconds(displayTime);
            displayTime-=0.1f;
        }
        yield return new WaitForSeconds(5f);
        FinalImage.SetActive(true);
        audioSource.Play();
        
    }
}
