using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameDialog dialog;
    public float maxSpeed;
    public float JumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    GameObject scanObject;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ScreenChk();
        //이동 제한 함수

        //점프
        if (Input.GetButtonDown("Jump") && !anim.GetBool("Jumping"))
        {
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            anim.SetBool("Jumping", true);
        }

        // 대화창
        if (Input.GetButtonDown("Submit") && scanObject != null)
        {
             dialog.Action(scanObject);
            //Debug.Log("This is " + scanObject.name);
        }

        //  멈추게할때 스피드 낮추는 거
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        // 캐릭터 좌우 방향 바꾸기
        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }


        //캐릭터 애니메이션 걷느냐에 따라 바꾸기
        if (Mathf.Abs( rigid.velocity.x) < 0.2)
        {
            anim.SetBool("Walking", false);
        }
        else
        {
            anim.SetBool("Walking", true);
        }

        
    }

    void FixedUpdate()
    {
        // 키로 움직임 컨트롤
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector3.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed) //오른쪽 최대속도
        {
            rigid.velocity = new Vector3(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed*(-1))//왼쪽 최대속도
        {
            rigid.velocity = new Vector3(maxSpeed * (-1), rigid.velocity.y);
        }


        //점프하고 돌아옥기?
        if(rigid.velocity.y < 0) { 
            //Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1 , LayerMask.GetMask("Platform"));
        
            if(rayHit.collider != null)
            {
                if(rayHit.distance < 0.5f)
                {
                    anim.SetBool("Jumping", false);
                }
            }
        }

        //Debug.DrawRay(rigid.position, Vector3.left * 0.7f, new Color(0,1,0));
        Debug.DrawRay(rigid.position, Vector3.right, new Color(0, 1, 0));
        RaycastHit2D rayHit2 = Physics2D.Raycast(rigid.position, Vector3.right, 1, LayerMask.GetMask("Object"));

        if (rayHit2.collider != null) {
            scanObject = rayHit2.collider.gameObject;
            Debug.Log("if : " + scanObject.name);
        }
        else {
            scanObject = null;
            //Debug.Log("else" + scanObject);
        }
    }

    private void ScreenChk()
    {
        Vector3 worlpos = Camera.main.WorldToViewportPoint(transform.position);
        if (worlpos.x < 0.02f) worlpos.x = 0.02f;
        if (worlpos.x > 0.98f) worlpos.x = 0.98f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlpos);
    }
}
