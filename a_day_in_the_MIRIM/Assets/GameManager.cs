using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int EndingScore;
    public int CardGameScore;

    public GameObject[] Objectrand = new GameObject[5];
    private static GameManager _instence;
    public float LimiTime;
    public Text Timetext;
    public GameObject panel;
    public GameObject GS_panel;
    private bool objControl = true;

    public AudioClip Music;
    public AudioSource MusicSource;

    private bool isGameStart=false;
    private bool isGameinside = false;

    public void Gamestart()
    {
        isGameStart = true;
        GS_panel.SetActive(false);
    }
    public void CardGameScore_UP()
    {
        CardGameScore++;
    }
    public static GameManager instence
    {
        get
        {
            if (_instence == null)
            {
                _instence = FindObjectOfType<GameManager>();

            }
            return _instence;
        }
    }

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStart)
        {
            CreateBook();
            StartCoroutine(CrateBookRotation());
            isGameinside = true;
            isGameStart = false;

        }
        if (isGameinside)
        {
            if (LimiTime > 0)
            {
                LimiTime -= Time.deltaTime;
                Timetext.text = "TIME : " + (int)LimiTime;
                panel.SetActive(false);
            }
            else
            {
                StopCoroutine(CrateBookRotation());
                panel.SetActive(true);
                objControl = false;
            }
        }
        
    }

    IEnumerator CrateBookRotation()
    {
        while (objControl)
        {
            CreateBook();
            yield return new WaitForSeconds(0.5f);
        }
            
    }


    [SerializeField]
    private Text ScoreText;

    public void Score()
    {
        MusicSource.PlayOneShot(Music);
        score++;
        ScoreText.text = "SCORE : " + score;
    }
    private void CreateBook()
    {
        int num_name = Random.Range(0, 5);
        GameObject a1 = Objectrand[num_name];
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f,1.0f),1.1f,0));
        pos.z = 0.0f;
      
        Instantiate(a1, pos, Quaternion.identity);    // Quaternion.identity = 회전 하지 않음/
        
    }
    public void NextScence()
    {
        GameObject ScoreOb = GameObject.Find("SoundObject");
        if (score >= 50)
        {
            ScoreOb.GetComponent<N_score>().Score_up(50);
        }else if(score >= 35)
        {
            ScoreOb.GetComponent<N_score>().Score_up(30);
        }else if (score >= 25)
        {
            ScoreOb.GetComponent<N_score>().Score_up(20);
        }else if (score >= 10)
        {
            ScoreOb.GetComponent<N_score>().Score_up(10);
        }
           
    }


    
}
