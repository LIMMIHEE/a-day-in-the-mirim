﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDialog : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;

    public void Action(GameObject scanObject)
    {
        //if (isAction)   //Exit Action
        //{
        //    isAction = false;
        //}
        //else   //Enter Action
        //{
        isAction = true;
        this.scanObject = scanObject;
        talkText.text = "이건 " + scanObject.name + "이다.";
        //}
        talkPanel.SetActive(isAction);
    }
}
