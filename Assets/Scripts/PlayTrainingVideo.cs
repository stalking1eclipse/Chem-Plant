using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayTrainingVideo : MonoBehaviour
{
    [SerializeField]
    VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
            videoPlayer.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (videoPlayer.isPlaying && other.CompareTag("Player"))
            videoPlayer.Stop();
    }
}
