using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMainScript : MonoBehaviour
{
    private Animator anim;
    public Rigidbody2D rb;
    public bool isAttacking = false;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    public float damage;
    public float health; 
    public float enemyDamage;
    public UnityEvent OnHit;
    private bool babyHeld = false;
    public GameObject baby;
    public float jump;
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movement();
        if(Input.GetKeyDown("space"))
        {
            Attack();
        }
        if (Input.GetKeyDown("w"))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.layer == LayerMask.NameToLayer("Enemy layer"))
        {
            Hit();
        }
        if(collision.gameObject.name == "Baby")
        {
            babyHeld = true;
            baby.transform.parent = this.gameObject.transform;
        }
    }
    
    public void Movement()
    {
        if(babyHeld == false){
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
        if(babyHeld == true){
            if (Input.GetKey("d"))
            {
                anim.SetTrigger("Run");
                rb.velocity = new Vector2(1, 0);
                this.gameObject.transform.localScale = new Vector2(1,1);
            } else if(Input.GetKey("a"))
            {
                anim.SetTrigger("Run");
                rb.velocity = new Vector2(-1, 0);
                this.gameObject.transform.localScale = new Vector2(-1,1);
            }
        }
    }
    public void Attack()
    {
        anim.SetTrigger("Attack");
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach(Collider2D enemyGameobject in enemy)
        {
            Debug.Log("HitEnemy");
            enemyGameobject.GetComponent<Enemy>().enemyHealth -= damage;
        }
    }
    public void Dead()
    {
        Debug.Log("you died");
        Destroy(this.gameObject);
    }
    public void Hit()
    {
        Debug.Log("yeoowwchhh");
        health -= enemyDamage;
        if (health <= 0)
        {
           Dead();
        }
    }
}
