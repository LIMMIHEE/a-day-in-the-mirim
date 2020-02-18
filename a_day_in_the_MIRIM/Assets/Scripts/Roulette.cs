using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    float roultteSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //클릭시 회전
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("asdf");
            this.roultteSpeed = 30;
        }
        transform.Rotate(0, 0, this.roultteSpeed);

        this.roultteSpeed *= 0.99f;
        
    }
}
