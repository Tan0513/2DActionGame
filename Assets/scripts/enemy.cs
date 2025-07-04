using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    protected AudioSource deathAudio;
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        deathAudio = GetComponent<AudioSource>();
    }

    public void Death()
    {
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }

    public void Jumpup()
    {
        anim.SetTrigger("death");
        deathAudio.Play();
    }
}
