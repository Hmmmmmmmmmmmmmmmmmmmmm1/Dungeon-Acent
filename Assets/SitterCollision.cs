using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitterCollision : MonoBehaviour
{
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Babyitter")
        {
             Destroy (this.gameObject);
        }
    }
}