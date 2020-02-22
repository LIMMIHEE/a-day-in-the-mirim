using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrogNshoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rigid;

    public Vector2 MinPower;
    public Vector2 MaxPower;

     trajectoryLine Tl;
    Camera Cam;
    Vector2 force;
    Vector3 startPosi,endPosi;

    private void Start()
    {
        
        Cam = Camera.main;
        Tl = GetComponent<trajectoryLine>();
        Tl.enabled = false;

    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            startPosi = Cam.ScreenToWorldPoint(Input.mousePosition);
            startPosi.z = 15;
        }

        if (Input.GetMouseButton(0))
        {
            Tl.enabled = true;
            Vector3 currenPoint = Cam.ScreenToWorldPoint(Input.mousePosition);
            currenPoint.z = 15;
            Tl.RenderLine(startPosi, currenPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPosi = Cam.ScreenToWorldPoint(Input.mousePosition);
            endPosi.z = 15;

            force = new Vector2(Mathf.Clamp(startPosi.x - endPosi.x, MinPower.x, MaxPower.x), Mathf.Clamp(startPosi.y - endPosi.y, MinPower.y, MaxPower.y));
            rigid.AddForce(force * power, ForceMode2D.Impulse);

            Tl.EndLine();

        }

            

        
    }

}
