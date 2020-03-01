using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sideFadeinout : MonoBehaviour
{
    
    public Image BlackFade;
    public GameObject outbutton;



    // Start is called before the first frame update
    void Start()
    {
       



    }
    // Update is called once per frame
    public void FadeIn()
    {
        BlackFade.canvasRenderer.SetAlpha(0.0f);
        BlackFade.CrossFadeAlpha(1, 2, false);

    }
    public void Fadeout()
    {
        BlackFade.canvasRenderer.SetAlpha(1.0f);
        BlackFade.CrossFadeAlpha(0, 2, false);
        outbutton.SetActive(false);

    }
}
