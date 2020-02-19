using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDialog : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction=false;

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
    public void Action(GameObject scanObj)
    {
        //if (isAction)   //Exit Action
        //{
        //    isAction = false;
        //}
        //else   //Enter Action
        //{
        isAction = true;
        scanObject = scanObj;
        talkText.text = "이건 " + scanObject.name + "이다.";
        //}
        talkPanel.SetActive(isAction);
    }
    //*/
}
