using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class nomal_Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textDisplay;
    public string[] sentence;
    private int index;
    public float typingSpeed;
    public string n_scence;
    
    public GameObject continueButton;

    public GameObject Techer_sp;
    public GameObject char_;
    

    public int change_time;
    public int change_time_two;
    void Start()
    {
        StartCoroutine(Type());
        char_.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == sentence[index])
        {
            continueButton.SetActive(true);
        }
        if (index== change_time)
        {
            char_.SetActive(true);
            Techer_sp.SetActive(false);
        }
        if (index == change_time_two)
        {
            char_.SetActive(false);
            Techer_sp.SetActive(true);
        }
        }
    IEnumerator Type()
    {
        foreach(char letter in sentence[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void Nextsentence()
    {
        continueButton.SetActive(false);
        if (index < sentence.Length - 1) {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            SceneManager.LoadScene(n_scence);
        }
    }

   
}
