using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", Math.Abs(rb.velocity.x));
        anim.SetFloat("velY", rb.velocity.y);
        anim.SetBool("jump", controller.isJumping);
        anim.SetBool("ground", controller.isGround);
    }
}
