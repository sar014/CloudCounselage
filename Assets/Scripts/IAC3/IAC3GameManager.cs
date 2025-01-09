using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IAC3GameManager : MonoBehaviour
{
    [SerializeField] GameObject MainGame;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject RulesPage;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject winMessage;
    [SerializeField] MatchCards matchCards;

    AudioSource WinaudioSource;
    AudioSource LoseaudioSource;
    AudioSource backgroundMusic;
    bool PlayedWinScreen = false;
    bool PlayedGameOverScreen = false;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
        WinaudioSource = winMessage.GetComponent<AudioSource>();
        LoseaudioSource = gameOver.GetComponent<AudioSource>();

        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(matchCards.lives==0 && PlayedGameOverScreen==false)   
        {
            GameOver();
            PlayedGameOverScreen = true;
        }
        else if (matchCards.cardCount==3 && PlayedWinScreen==false)
        {
            PlayedWinScreen = true;
            WinScreen();
        }
    }

    public void StartGame()
    {
        MainGame.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void ShowRules()
    {
        MainMenu.SetActive(false);
        RulesPage.SetActive(true);
    }

    public void GoBack()
    {
        RulesPage.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void GameOver()
    {
        backgroundMusic.Stop();

        LoseaudioSource.Play();
        Debug.Log("Game Over");
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void WinScreen()
    {
        backgroundMusic.Stop();
        
        Debug.Log("WinScreen called");
        WinaudioSource.Play();
        winMessage.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        backgroundMusic.Play();
        MainMenu.SetActive(true);
        MainGame.SetActive(false);
        gameOver.SetActive(false);
    }

    public void GoBackToMainGame()
    {
        SceneManager.LoadScene(0);
    }
}
