using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_score : MonoBehaviour
{
    public int CardGame;
    public int Endingscore;
    public float CaedTime = 30;

    /*
    public bool isCardGame;
    public bool isImgGame;
    public bool isBookGame;
    public bool istrashGame;
    public bool isrollGame;
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Score_up(int i)
    {
        Endingscore += i;
    }
}

/*
 if (isCardGame)
        {

        }
        if (isImgGame)
        {

        }
        if (isBookGame)
        {

        }
        if (istrashGame)
        {

        }
        if (isrollGame)
        {

        }
     
     */
