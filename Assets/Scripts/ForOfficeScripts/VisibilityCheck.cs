using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VisibilityCheck : MonoBehaviour
{
    VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer == null)
        {
            Debug.LogError("No VideoPlayer component found on this GameObject!");
        }
        
    }

    void OnBecameVisible()
    {
        // Resume playing the video when the object is visible
        if (videoPlayer != null)
        {
            videoPlayer.Play();
           
        }
    }

    void OnBecameInvisible()
    {
        // Pause the video when the object is not visible
        if (videoPlayer != null)
        {
            videoPlayer.Pause();
            
        }
    }
}
