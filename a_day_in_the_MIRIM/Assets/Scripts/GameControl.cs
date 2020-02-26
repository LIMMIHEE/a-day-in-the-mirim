using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    public Transform[] pictures;

    [SerializeField]
    public Sprite[] pictures_two;
    public Sprite[] pictures_three;
    public Sprite[] pictures_Origi;
    [SerializeField]
    public SpriteRenderer[] Sp_change;
   

    private int Puz_num = 0;
    public float LimiTime;
    public Text Timetext;
    public Text Scoretext;


    [SerializeField]
    public GameObject panel;

    public static bool Finish;
    int Score;

    private void Start()
    {
        panel.SetActive(false);
        Finish = false;
    }

    private void Update()
    {
        if (pictures[0].rotation.z  == 0 &&
           pictures[1].rotation.z == 0 &&
           pictures[2].rotation.z == 0 &&
           pictures[3].rotation.z == 0 &&
           pictures[4].rotation.z == 0 &&
           pictures[5].rotation.z == 0 &&
           pictures[6].rotation.z == 0 &&
           pictures[7].rotation.z == 0 &&
           pictures[8].rotation.z == 0)
        {
            NectGame();

        }
       

        if (LimiTime > 0)
        {
            LimiTime -= Time.deltaTime;
            Timetext.text = "Time : " + (int)LimiTime;
            panel.SetActive(false);
        }
        else
        {
            Finish = true;
            panel.SetActive(true);
        }
    }

    void NectGame()
    {
        Debug.Log("작동");
        for (int j = 0; j < 9; j++)
        {
            int n = Random.Range(1, 4) * 90;
            pictures[j].rotation = Quaternion.Euler(0, 0, n);
        }
        Score++;
        Scoretext.text = "SCORE : " + Score;

        if (Puz_num == 0)
        {
            Puz_num++;
            for (int i = 0; i < 9; i++)
            {
                Sp_change[i].sprite = pictures_two[i];
            }
        }
        else if (Puz_num == 1)
        {
            Puz_num++;
            for (int i = 0; i < 9; i++)
            {
                Sp_change[i].sprite = pictures_three[i];
            }
        }
        else
        {
            Puz_num = 0;
            for (int i = 0; i < 9; i++)
            {
                Sp_change[i].sprite = pictures_Origi[i];
            }
        }
    }
}
