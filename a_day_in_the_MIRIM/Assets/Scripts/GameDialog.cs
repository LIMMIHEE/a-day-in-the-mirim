using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDialog : MonoBehaviour
{

    private PlayerMove Pm;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction=false;
    public int talkindex;

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            Debug.Log("a");
        }
    }
    */
    ///*
    ///
    void Update()
    {
        
    }

    public void Action(GameObject scanObject)
    {
        if (isAction && scanObject != null)   //Exit Action
        {
            isAction = false;
        }
        else   //Enter Action
        {
            isAction = true;
            this.scanObject = scanObject;
            talkText.text = "이건 " + scanObject.name + "이다.";
        }
        talkPanel.SetActive(isAction);

    }

    
}
