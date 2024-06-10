using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGeneration : MonoBehaviour
{
    public GameObject floorLeft;
    public GameObject floorRight;
    public GameObject player;
    int floor;
    void Start()
    {
        floor = 0;
        //generate first couple floors
        for(int i = 1; i < 5; i++)
        {
            GenerateFloor(-5*i);
        }
    }
    void Update()
    {
        //if player below point
        if (gameObject.transform.localPosition.y < floor*-5)
        {
            //call generate floor with a depth
            GenerateFloor((floor+4)*-5);
        }
        
    }

    public void GenerateFloor(float depth)
    {
        //Make Random number
        System.Random r = new System.Random();
        int gap = (int)(r.Next(1,41));
        //find xscale for the objects
        int leftScale = 2*(gap-1);
        int rightScale = 2*(gap-40);
        //Instantiate
        GameObject leftFloor = Instantiate(floorLeft, new Vector3(-20,depth,0), Quaternion.identity);
        leftFloor.transform.localScale = new Vector3(leftScale,2,1);
        GameObject rightFloor = Instantiate(floorRight, new Vector3(20,depth,0), Quaternion.identity);
        rightFloor.transform.localScale = new Vector3(rightScale,2,1);
    }
}
