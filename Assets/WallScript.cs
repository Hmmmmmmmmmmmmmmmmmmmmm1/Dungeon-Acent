using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        gameObject.transform.localPosition = new Vector3(0,player.transform.localPosition.y,1);
    }
}

