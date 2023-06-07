using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 10f; // 跳躍力度
    public float crouchScale = 0.5f; // 蹲下時的縮放比例

    public AudioSource hitSource;

    public Transform groundDetect;

    public bool isCrouching = false;
    public bool isGrounded = false;

    private Rigidbody2D rb;
    private CapsuleCollider2D capsuleCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.Raycast(groundDetect.position, Vector2.down, 0.1f);
        // 處理跳躍
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isCrouching)
        {
            Jump();
        }

        // 處理蹲下
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            Crouch();
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) && isCrouching)
        {
            Uncrouch();
        }
    }


    private void Jump()
    {
        isGrounded = false;
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        hitSource.Play();
    }

    private void Crouch()
    {
        isCrouching = true;
        capsuleCollider.size = new Vector2(capsuleCollider.size.x, capsuleCollider.size.y * crouchScale);
        capsuleCollider.offset = new Vector2(capsuleCollider.offset.x, -capsuleCollider.size.y * crouchScale);
    }

    private void Uncrouch()
    {
        isCrouching = false;
        capsuleCollider.size = new Vector2(capsuleCollider.size.x, capsuleCollider.size.y / crouchScale);
        capsuleCollider.offset = new Vector2(capsuleCollider.offset.x, 0f);
    }

}
