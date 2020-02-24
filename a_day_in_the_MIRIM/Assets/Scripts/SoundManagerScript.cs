using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
