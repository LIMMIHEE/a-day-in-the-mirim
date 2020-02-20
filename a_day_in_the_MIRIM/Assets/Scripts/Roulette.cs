using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Roulette : MonoBehaviour
{
    int randVal;
    private float timeInterval;
    private bool isCoroutine;
    private int finalAngle;
    public TextMeshProUGUI Ptext;
    public int section;
    private float totalAngle;
    public string[] PrizeName;
    //float roultteSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        isCoroutine = true;
        totalAngle = 360 / section;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //클릭시 회전
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("asdf");
            this.roultteSpeed = 30;
        }
        transform.Rotate(0, 0, this.roultteSpeed);

        this.roultteSpeed *= 0.99f;
        */
        if(Input.GetMouseButtonDown(0)&& isCoroutine)
        {
            StartCoroutine(Spin());
        }


    }

   private IEnumerator Spin()
    {
        isCoroutine = false;
        randVal = Random.Range(200, 300);

        timeInterval = 0.0001f * Time.deltaTime * 2;
        for (int i = 0; i < randVal; i++){
            transform.Rotate(0, 0, (totalAngle / 2));

            if (i > Mathf.RoundToInt(randVal*0.2f))
                timeInterval = 0.5f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.5f))
                timeInterval = 1f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.7f))
                timeInterval = 1.5f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.8f))
                timeInterval = 2f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.9f))
                timeInterval = 2.5f * Time.deltaTime;

            yield return new WaitForSeconds(timeInterval);
        }

        if(Mathf.RoundToInt(transform.eulerAngles.z)% totalAngle != 0)
        {
            transform.Rotate(0, 0, totalAngle / 2);
        }
        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);
        print(finalAngle);

        for(int i=0; i<section; i++)
        {
            if(finalAngle == i * totalAngle)
            {
                Ptext.text = PrizeName[i];
            }
        }
        isCoroutine = true;
    }
}
