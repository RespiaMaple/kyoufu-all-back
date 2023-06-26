using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartMenu : MonoBehaviour
{
    static StartMenu instance;

    public string gameSceneName = "SampleScene";
    public AudioClip startClip;
    public AudioSource audioSource;
    
    private void Awake() 
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(startClip);
            Invoke("StartGame", 0.5f);
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
