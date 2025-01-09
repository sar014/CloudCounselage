using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMiniGame : MonoBehaviour
{
    public bool playGame;
    public void ContinueMessage()
    {
        //if YES then continue to mini game (present in OfficeSceneManager script)
        playGame = true;
    }

    public void NotContinue()
    {
        this.gameObject.SetActive(false);
    }
}
