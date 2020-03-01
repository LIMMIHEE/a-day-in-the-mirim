using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class Roulette : MonoBehaviour
{
    int randVal;
    private float timeInterval;
    private bool isCoroutine;
    private int finalAngle;
    public Text Ptext;
    public int section;
    private float totalAngle;
    public string[] PrizeName;

    public GameObject panel;
    public GameObject Gamepanel;
    private float DestotyTime=2;
    private float TickTime=0;
    private bool timechk_b=false;
    public bool isGamestart=false;

    public AudioSource MusicSource;
    public AudioClip Music;


    int EndingScore;
    //float roultteSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        isCoroutine = true;
        totalAngle = 360 / section;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //클릭시 회전
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("asdf");
            this.roultteSpeed = 30;
        }
        transform.Rotate(0, 0, this.roultteSpeed);

        this.roultteSpeed *= 0.99f;
        */
        if (isGamestart) {
            Gamepanel.SetActive(false);
            if (Input.GetMouseButtonDown(0)&& isCoroutine)
            {
                StartCoroutine(Spin());
                MusicSource.PlayOneShot(Music);
            }
            if(timechk_b == true)
            {
                TickTime += Time.deltaTime;
                if (TickTime> DestotyTime)
                {
                    panel.SetActive(true);
                }
            }
        }
    }

   private IEnumerator Spin()
    {
        
        isCoroutine = false;
        randVal = Random.Range(200, 300);

        timeInterval = 0.0001f * Time.deltaTime * 2;
        for (int i = 0; i < randVal; i++){
            transform.Rotate(0, 0, (totalAngle / 2));

            if (i > Mathf.RoundToInt(randVal*0.2f))
                timeInterval = 0.5f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.5f))
                timeInterval = 1f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.7f))
                timeInterval = 1.5f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.8f))
                timeInterval = 2f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.9f))
                timeInterval = 2.5f * Time.deltaTime;

            yield return new WaitForSeconds(timeInterval);
        }

        if(Mathf.RoundToInt(transform.eulerAngles.z)% totalAngle != 0)
        {
            transform.Rotate(0, 0, totalAngle / 2);
        }
        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);
        print(finalAngle);

        

        for(int i=0; i<section; i++)
        {
            if (finalAngle == i * totalAngle)
            {
                EndingScore = int.Parse(PrizeName[i]);
                switch (int.Parse(PrizeName[i]))
                {
                    case 1: Ptext.text = "야호! 빠르게 도착했다."; break;
                    case -1: Ptext.text = "이런.. 무단지각이다."; break;
                    case 2: Ptext.text = "평범하게 도착했다."; break;
                    case 3: Ptext.text = "이런, 복장불량이다."; break;
                    default: Ptext.text = "다시 돌려보자!"; isCoroutine = true; break;
                }
            }
        }

        timechk_b = true;

          
        
    }
    public GameObject soundObj;
    private void Awake()
    {
        DontDestroyOnLoad(soundObj);
    }
    public void NextScence()
    {
        
        if (EndingScore == 1)
        {
            soundObj.GetComponent<N_score>().Score_up(100);
        }else if (EndingScore == 2)
        {
            soundObj.GetComponent<N_score>().Score_up(50);
        }
        else if (EndingScore == 3)
        {
            soundObj.GetComponent<N_score>().Score_up(30);
        }
        SceneManager.LoadScene("ClassScenes");
    }
    public void Gamestart()
    {
        isGamestart = true;
    }
    
}
