using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManagerScript : MonoBehaviour
{

    public AudioSource MusicSource;
    public AudioClip MusicClip;
    public AudioClip MusicClip_s;
    public static SoundManagerScript instance;

    void Awake() {
        if (SoundManagerScript.instance == null)
        {
            SoundManagerScript.instance = this; 
        } 
    }
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayMusic()
    {
        MusicSource.PlayOneShot(MusicClip);
    }
    public void PlayMusicAndSay()
    {
        MusicSource.PlayOneShot(MusicClip);
        
        Invoke("GoNScence", 8);
        
    }
    void GoNScence()
    {
        SceneManager.LoadScene("sideSayScence");
    }
}
