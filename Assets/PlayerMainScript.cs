using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public bool isAttacking = false;

    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movement();
        if (isAttacking == true)
        {
            Attack();
        }
    }
    
    public void Movement()
    {
        if (Input.GetKey("d"))
        {
            anim.SetTrigger("Run");
            rb.velocity = new Vector2(2, 0);
            this.gameObject.transform.localScale = new Vector2(1,1);
        } else if(Input.GetKey("a"))
        {
            anim.SetTrigger("Run");
            rb.velocity = new Vector2(-2, 0);
            this.gameObject.transform.localScale = new Vector2(-1,1);
        }

        
    }
    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

}
