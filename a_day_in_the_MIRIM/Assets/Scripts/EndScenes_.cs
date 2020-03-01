using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScenes_ : MonoBehaviour
{
    public Text title;
    public TextMeshProUGUI explanation;

    public GameObject Bad;
    public GameObject Good;
    public GameObject Soso;
    public GameObject VB;
    public GameObject VG;

    string[] title_name = { "운수대통", "기분좋은 하루", "평소같은 하루", "불운의 날","최악의 날"};
    string[] explanation_t = { "오늘은 모든게 완벽한 하루였다. 마치 신이 나에게 기분 좋으라고 내려준 선물 같다. 다른 날도 오늘 같았으면!",
        "수업은 그렇게 집중하지 못했지만 그래도 어때! 학교도 일찍 끝나서 기분이 좋다!",
        "그냥저냥, 평소와 같은 하루였다. 누군가 도와주는 건 기분 탓이었나보다.",
        "우울하다, 집중해야하나 수업시간에도 졸아버리고... 운수가 좋지 않았다.",
        "모든게 최악이었다. 수업시간에는 완전히 자버리고. 선생님에게 혼나기도하고.. 누군가가 일부러 나를 최악의 상황으로 몰아넣은 것 같다."};

    // Start is called before the first frame update
    void Start()
    {
        GameObject ScoreOb = GameObject.Find("SoundObject");
        if (ScoreOb.GetComponent<N_score>().Endingscore >= 280)
        {
            VG.SetActive(true);
            title.text = title_name[0];
            explanation.text = explanation_t[0];
        }
        else if (ScoreOb.GetComponent<N_score>().Endingscore >=210 )
        {
            Good.SetActive(true);
            title.text = title_name[1];
            explanation.text = explanation_t[1];
        }
        else if (ScoreOb.GetComponent<N_score>().Endingscore >= 140)
        {
            Soso.SetActive(true);
            title.text = title_name[2];
            explanation.text = explanation_t[2];
        }
        else if (ScoreOb.GetComponent<N_score>().Endingscore >= 70)
        {
            Bad.SetActive(true);
            title.text = title_name[3];
            explanation.text = explanation_t[3];
        }
        else 
        {
            VB.SetActive(true);
            title.text = title_name[4];
            explanation.text = explanation_t[4];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Gostart()
    {
        SceneManager.LoadScene("Main");
    }
}
