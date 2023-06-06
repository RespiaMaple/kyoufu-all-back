using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{

    public TextMeshProUGUI distanceText;

    public AudioClip startClip;
    public AudioSource audioSource;


    private void Start()
    {
        Time.timeScale = 1f;
        UpdateScore();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(startClip);
            Invoke("ReturnToStartMenu", 0.5f);
        }
    }

    public void UpdateScore()
    {
        float score = PlayerPrefs.GetFloat("Score", 0f);
        distanceText.text = "Distance: " + score.ToString("F1") + "m";
    }

    private void ReturnToStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
