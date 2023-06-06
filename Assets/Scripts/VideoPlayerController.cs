using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        if (Time.timeScale == 0f && videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else if (Time.timeScale != 0f && !videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
    }
}
