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

    public GameObject endPanel;


    private void Start()
    {
        Time.timeScale = 1f;
        UpdateScore();
        endPanel.SetActive(false);
        StartCoroutine(ShowScore());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(startClip);
            Invoke("ReturnToStartMenu", 0.5f);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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

    private IEnumerator ShowScore()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        endPanel.SetActive(true);
    }
}
