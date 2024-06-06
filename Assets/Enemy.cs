using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHealth, maxHealth = 3f;
    public float enemyDamage;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = maxHealth;
    }
    public void Update()
    {
       if(enemyHealth<=0 )
       {
        Destroy(this.gameObject);
       }
    }
}
