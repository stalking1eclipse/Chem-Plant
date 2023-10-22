using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayTrainingVideo : MonoBehaviour
{
    [SerializeField]
    List<VideoPlayer> videoPlayer;

    public void playVideo()
    {
        foreach (VideoPlayer player in videoPlayer)
        {
            player.Play();
        }        
    }

    public void stopVideo()
    {
        foreach (VideoPlayer player in videoPlayer)
        {
            player.Play();
        }
    }

    public void toggleVideoPlay()
    {
        foreach (VideoPlayer player in videoPlayer)
        {
            if (player.isPlaying)
                stopVideo();
            else
                playVideo();
        }
    }
}
