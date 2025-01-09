using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class OfficeSceneManager : MonoBehaviour
{
    [SerializeField] GameObject HighlightGameObject;
    [SerializeField] GameObject ContinueGameObject;
    [SerializeField] PlayMiniGame playMiniGame;
    public bool playGame = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make it visible
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            HighlightGameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        HighlightGameObject.SetActive(false);
    }

    void LoadScene(string IAC)
    {
        if(playMiniGame.playGame)
        {
            if(IAC=="IAC1")
            {
                SceneManager.LoadScene(2);
            }
            else if(IAC=="IAC2")
            {
                SceneManager.LoadScene(3);
            }
            else if (IAC=="IAC3")
            {
                SceneManager.LoadScene(4);
            }
        }
    }

   

    public void OnMouseDown() {
        ContinueGameObject.SetActive(true);
        LoadScene(gameObject.tag);
    }
}
