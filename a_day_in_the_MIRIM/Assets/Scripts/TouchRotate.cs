﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    public bool isRotateStart;
    public AudioSource Scurce;
    public AudioClip Clip;
    public void RotateStart()
    {
        isRotateStart = true;
    }
    private void OnMouseDown()
    {
        if (isRotateStart)
        {
            if (!GameControl.Finish)
            {
                transform.Rotate(0f, 0f, 90f);
                Scurce.PlayOneShot(Clip);
            }
        }
        
    }
}
