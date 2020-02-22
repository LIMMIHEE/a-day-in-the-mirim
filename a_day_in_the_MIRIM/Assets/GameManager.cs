﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject[] Objectrand = new GameObject[5];
    private static GameManager _instence;
    public float LimiTime;
    public Text Timetext;
    public GameObject panel;
    private bool objControl=true;

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
        
        CreateBook();
        StartCoroutine(CrateBookRotation());
    }

    // Update is called once per frame
    void Update()
    {
        if(LimiTime > 0) {
            LimiTime -= Time.deltaTime;
            Timetext.text = "Time : " + (int)LimiTime;
            panel.SetActive(false);
        }
        else
        {
            StopCoroutine(CrateBookRotation());
            panel.SetActive(true);
            objControl = false;
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

        score++;
        ScoreText.text = "Score : " + score;
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
        SceneManager.LoadScene("TestScene");
    }


    
}
