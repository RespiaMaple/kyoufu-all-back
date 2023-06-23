using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerAnimation : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Animator anim;
    public PlayerMovement movement;

    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }


    void Update()
    {
        anim.SetBool("isJumping", !movement.isGrounded);
        anim.SetBool("isCrouching", movement.isCrouching);


        if (videoPlayer.isPlaying)
        {
            // 取得目前影片的播放時間
            float currentTime = (float)videoPlayer.time;

            // 在指定的時間範圍內觸發動畫
            if (currentTime >= 14.5f && currentTime <= 28.5f)
            {
                anim.SetBool("Flute", true);
            }
            else if (currentTime >= 78.5f && currentTime <=86f)
            {
                anim.SetBool("Flute", true);
            }
            else if (currentTime >= 117.5f && currentTime <=131.5f)
            {
                anim.SetBool("Flute", true);
            }
            else
            {
                anim.SetBool("Flute", false);
            }
        }
}
}
