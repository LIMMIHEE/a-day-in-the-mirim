using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fadeinout : MonoBehaviour
{
    public Image BlackFade;
    public GameObject GO;

    

    // Start is called before the first frame update
    void Start()
    {
        BlackFade.canvasRenderer.SetAlpha(0.0f);
        GO.SetActive(false);
        FadeIn();
        

    }
    // Update is called once per frame
    public void FadeIn()
    {
            BlackFade.CrossFadeAlpha(1, 2,false);
        GO.SetActive(true);
    }
    public void FadeIn_()
    {
        GO.SetActive(true);
        BlackFade.CrossFadeAlpha(1, 2, false);

    }



   
    
}
