using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Dalog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;

    public TextMeshProUGUI Dialog;
    public GameObject SayDialog;
    public GameObject SayButton;
    public GameObject FadeWin;
    public GameObject Img;
    public string[] Mainsentences;
    public string[] sentences;
    private int Mindex;
    private int index;
    public float typingSpeed;

    private float fDestroyTime = 2f; private float fTickTime;


    private void StartD()
    {
        SayDialog.SetActive(false);
        SayButton.SetActive(false);
    }

    private void Update()
    {
        fTickTime += Time.deltaTime;
        if ((fTickTime > fDestroyTime) && (fTickTime < fDestroyTime+0.02))
        {
            StartCoroutine(Type());
            SayDialog.SetActive(true);
            SayButton.SetActive(true);
            
        }


            if (index == 4)
        {
            textDisplay = Dialog;
            SayDialog.SetActive(false);
            SayButton.SetActive(false);
            FadeWin.SetActive(false);
            Img.SetActive(false);
        }
    }

    IEnumerator Type()
    {
        //yield
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Nextsentences()
    {
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            SceneManager.LoadScene("RouletteScene");
        }
   
    }
}
