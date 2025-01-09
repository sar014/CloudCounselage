using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] GameObject welcomePage;
    [SerializeField] GameObject rulesPage;
    [SerializeField] GameObject mainGame;
    [SerializeField] GameObject mcqGame;
    [SerializeField] GameObject CountDown;
    [SerializeField] GlitchEffect glitchEffect;

    [SerializeField] GameObject ErrorImageObject;
    [SerializeField] AudioSource NotificationSound;

    [SerializeField] float glitchEffectDuration = 10f; // Duration in seconds
    [SerializeField] float glitchEffectUpdateInterval = 0.1f; // Interval in seconds to update the glitch effect

    void Start()
    {
        backgroundMusic.Play();
        welcomePage.SetActive(true);
    }

    public void ShowRules()
    {
        welcomePage.SetActive(false);
        rulesPage.SetActive(true);
    }

    public void GoBackPage()
    {
        rulesPage.SetActive(false);
        welcomePage.SetActive(true);
    }

    public async void playGame()
    {
        await TransitionToMCQGameAsync();
        welcomePage.SetActive(false);
        
    }

    public async void MCQGame()
    {
        CountDown.SetActive(true);
        // mcqGame.SetActive(true); // Activate the new game object
       
    }
    private async Task TransitionToMCQGameAsync()
    {
        glitchEffect.StartTransition(glitchEffectDuration); // Start the glitch effect transition
        
        await Task.Delay((int)(glitchEffectDuration * 1500)); // Wait for the glitch effect to complete
        mainGame.SetActive(true);
        StartCoroutine(ShowErrorMessage());
    }

    IEnumerator ShowErrorMessage()
    {
        yield return new WaitForSeconds(3f);
        NotificationSound.Play();
        ErrorImageObject.SetActive(true);
        
    }

    public void GoBackToMainGame()
    {
        SceneManager.LoadScene(0);
    }
}
