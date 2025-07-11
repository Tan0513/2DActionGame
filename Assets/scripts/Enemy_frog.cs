using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_frog : Enemy
{
    private Rigidbody2D rb;
    private bool Faceleft = true;
    private float leftx, rightx;
    //private Animator anim;
    private Collider2D coll;
    public LayerMask Ground;
    public Transform leftpoint, rightpoint; 
    public float Speed, jumpForce;



    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        transform.DetachChildren();
        leftx = leftpoint.position.x;
        rightx = rightpoint.position.x;
        Destroy(leftpoint.gameObject);
        Destroy(rightpoint.gameObject);
    }

    void Update()
    {
        SwitchAnim();
    }

    void Movement() 
        {
            if(Faceleft)
            {
                if(coll.IsTouchingLayers(Ground))
                {
                    anim.SetBool("jumping", true);
                    rb.velocity = new Vector2(-Speed, jumpForce);
                }
                if(transform.position.x < leftx)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    Faceleft = false;
                }
            }

            else
            {
                if(coll.IsTouchingLayers(Ground))
                {
                    anim.SetBool("jumping", true);
                    rb.velocity = new Vector2(Speed, jumpForce);
                }
                if(transform.position.x > rightx)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    Faceleft = true;
                }
            }
        }

    void SwitchAnim()
    {
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0.1)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling",true);
            }
        }
        
        if(coll.IsTouchingLayers(Ground) && anim.GetBool("falling"))
        {
            anim.SetBool("falling", false);
        }
    }

}
