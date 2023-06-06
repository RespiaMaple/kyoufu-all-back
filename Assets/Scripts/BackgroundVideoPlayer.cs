using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class BackgroundVideoPlayer : MonoBehaviour
{
    public RawImage backgroundRawImage; // 背景顯示的RawImage組件
    public VideoPlayer videoPlayer; // 影片播放器組件
    public VideoClip videoClip; // 要播放的影片

    private void Start()
    {
        // 設置影片循環播放
        videoPlayer.isLooping = true;

        // 將影片資源設置為VideoPlayer的Clip
        videoPlayer.clip = videoClip;

        // 將VideoPlayer的顯示輸出設置為RawImage的Texture
        backgroundRawImage.texture = videoPlayer.texture;

        // 播放影片
        videoPlayer.Play();
    }
}

