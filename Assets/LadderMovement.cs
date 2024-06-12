using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    public GameObject player;
    public Collider2D oooo;
    public Rigidbody2D aaaa;

    void Start()
    {
        oooo = player.GetComponent<Collider2D>();
        aaaa = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == oooo)
        {
            if( Input.GetKey("w"))
            {
                aaaa.velocity = new Vector2(0,3);
            }
        }
    }
}
