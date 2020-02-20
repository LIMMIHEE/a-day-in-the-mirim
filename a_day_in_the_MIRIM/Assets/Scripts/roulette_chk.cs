using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roulette_chk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Good")
        {
            Debug.Log("1");
        }
        else if (collision.transform.name == "soso")
        {
            Debug.Log("2");
        }

    }
}
