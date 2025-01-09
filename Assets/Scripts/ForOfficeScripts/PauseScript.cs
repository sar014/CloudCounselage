using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject pauseGameObject;
    private static PauseScript instance;

    void Awake()
    {
        // Ensure only one instance of this script exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    public void QuitGame()
    {
       Application.Quit();
    }

    public void ResumeGame()
    {
        pauseGameObject.SetActive(false);
        Time.timeScale =  1f;
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            pauseGameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }
}
