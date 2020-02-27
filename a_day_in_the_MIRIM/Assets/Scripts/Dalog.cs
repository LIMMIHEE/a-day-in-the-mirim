using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dalog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;


    private void Start()
    {
        StartCoroutine(Type());
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
        }
   
    }
}
