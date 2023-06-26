using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public TextMeshProUGUI scoreText;

    public float scoreMutiplier = 1.5f;

    public GameObject gameOverPanel;

    public bool isGameOver = false;

    public AudioClip hitClip;
    public AudioSource hitSource;

    public VideoPlayer backgroundVideoPlayer;

    public PlayerMovement playerMovement;

    private float score = 0f;

    private void Awake() 
    {
        instance = this;
    }


    private void Start()
    {
        gameOverPanel.SetActive(false);
        score = 0f;

        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
        }
    }

    private void Update() 
    {
        AddScore();
    }

    public void AddScore()
    {
        if (playerMovement != null && !playerMovement.isCrouching)
        {
            score += Time.deltaTime * scoreMutiplier;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Distance: " + score.ToString("F1") + "m";
    }

    public static void GameOver()
    {
        instance.backgroundVideoPlayer.Stop();
        //儲存分數
        PlayerPrefs.SetFloat("Score", instance.score);
        PlayerPrefs.Save();

        instance.hitSource.PlayOneShot(instance.hitClip);
        
        instance.StartCoroutine(GameOverCoroutine());
        instance.StartCoroutine(EndCoroutine());
    }

    private static IEnumerator GameOverCoroutine()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.1f);
        instance.gameOverPanel.SetActive(true);
    }

    private static IEnumerator EndCoroutine()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("EndScene");
    }


}
