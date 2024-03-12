using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_eagle : Enemy
{
    private Rigidbody2D rb;
    private float upy, downy;
    //private Animator anim;

    public Transform uppoint, downpoint; 
    public float FlySpeed;



    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.DetachChildren();
        rb.velocity = new Vector2(rb.velocity.x, FlySpeed);
        upy = uppoint.position.y;
        downy = downpoint.position.y;
        Destroy(uppoint.gameObject);
        Destroy(downpoint.gameObject);
    }

    void Update()
    {
        Movement();
    }

    void Movement() 
    {

        if(transform.position.y > upy)
        {
            rb.velocity = new Vector2(rb.velocity.x, -FlySpeed);
        }
        
        if(transform.position.y < downy)
        {
            rb.velocity = new Vector2(rb.velocity.x, FlySpeed);
        }
        
    }

}
