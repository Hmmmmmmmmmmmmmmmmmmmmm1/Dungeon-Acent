using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        gameObject.transform.localPosition = player.transform.localPosition - new Vector3(0,0,1);
    }
}
