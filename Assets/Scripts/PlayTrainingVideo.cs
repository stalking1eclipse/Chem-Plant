using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayTrainingVideo : MonoBehaviour
{
    [SerializeField]
    VideoPlayer videoPlayer;

    public void playVideo()
    {
        videoPlayer.Play();
    }

    public void stopVideo()
    {
        videoPlayer.Stop();
    }

    public void toggleVideoPlay()
    {
        if (videoPlayer.isPlaying)
            stopVideo();
        else
            playVideo();
    }
}
