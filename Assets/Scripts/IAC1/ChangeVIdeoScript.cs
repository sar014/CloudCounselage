using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ChangeVIdeoScript : MonoBehaviour
{
    public int randomIndex;
    public VideoPlayer videoPlayer;
    public List<VideoClip> videoClips;
    public GameObject VideoScreen;

    public GameObject QuestionAndAnswer;

    void Awake()
    {
        PlayRandomVideo();
    }

   void PlayRandomVideo()
    {
        if (videoClips.Count > 0)
        {
            randomIndex = Random.Range(0, videoClips.Count);
            videoPlayer.clip = videoClips[randomIndex];
            videoPlayer.Play();
            videoClips.Remove(videoClips[randomIndex]);

            // Deregister the previous callback (if any) to avoid multiple registrations
            videoPlayer.loopPointReached -= OnVideoEnd;
            // Register the new callback
            videoPlayer.loopPointReached += OnVideoEnd;
        }
        else
        {
            Debug.LogWarning("No video clips assigned to the array.");
        }
    }

    public void FastForward()
    {
        videoPlayer.time+=20.0f;
    }

    public void Rewind()
    {
        videoPlayer.time-=20.0f;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        DisplayQuestions();
    }

    void DisplayQuestions()
    {
        VideoScreen.SetActive(false);
        QuestionAndAnswer.SetActive(true);
    }
}
