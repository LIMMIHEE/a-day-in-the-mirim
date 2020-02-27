using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesCh_Ex : MonoBehaviour
{
    public AudioSource Button;
    public AudioClip _sound;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        
        SceneManager.LoadScene("StartScenes");
        Button.PlayOneShot(_sound);
    }
}
