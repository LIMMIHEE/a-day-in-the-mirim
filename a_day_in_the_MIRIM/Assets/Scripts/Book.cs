using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetTrigger("Book");
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameManager.instence.Score();
        }
    }
    
}
