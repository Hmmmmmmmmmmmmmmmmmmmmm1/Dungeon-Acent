using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGeneration : MonoBehaviour
{
    public GameObject floorLeft;
    public GameObject floorRight;
    public GameObject player;
    public GameObject enemy;
    int floor;
    bool up;
    List<int> gaps = new List<int>();


    void Start()
    {
        floor = 0;
        up = false;
        //generate first couple floors
        for(int i = 1; i < 5; i++)
        {
            GenerateFloor(-5*i);
            GenerateEnemies(i, (((-5*i)+2)));
        }
    }
    void Update()
    {
        switch(up)
        {
            case true:
                //generate new enemies above you
                break;
            case false:
                //if player below point
                if (player.transform.localPosition.y < floor*-5)
                {
                //call generate floor with a depth
                if (floor >= 44)
                {
                    BabyFloor((floor+4)*-5);
                    up = true;
                } else
                {
                    GenerateFloor((floor+4)*-5);
                    GenerateEnemies(floor+4, (((floor+4)*-5)+2));
                    floor++;
                }
                
                }
                break;
        }
        
        
        
    }

    public void BabyFloor(float depth)
    {
        //intantiate full floor
        GameObject babyFloor = Instantiate(floorLeft, new Vector3(-20,depth,0), Quaternion.identity);
        babyFloor.transform.localScale = new Vector3(80,2,1);
        //instantiate baby prefab

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
        gaps.Add(gap);
    }

    public void GenerateEnemies(int floor, float height)
    {
        //get gap
        int gap = gaps[floor-1];
        //gen # of enemies
        System.Random r = new System.Random();
        int numEnemy = (int)(r.Next(1+floor,5+floor));
        //place each enemy not on gap
        for (int i = 0; i < numEnemy; i++)
        {
            //make a list of locations
            List<int> spots = new List<int>();
            //gen a random number for location
            System.Random ra = new System.Random();
            float enemyLocation = (int)(ra.Next(1,41));
            //check to make sure its not near gap or another enemy
            if (!(enemyLocation > (gap-21) && enemyLocation < (gap-20)))
            {
                bool nah = false;
                foreach (int spot in spots)
                {
                    //could need (enemyLocation > (spot-21) && enemyLocation < (spot-20))
                    if (enemyLocation==spot)
                    {
                        nah = true;
                    }
                }
                if (!nah)
                {
                    Instantiate(enemy, new Vector3(enemyLocation-20.5f, height, 0), Quaternion.identity);
                    spots.Add((int)(enemyLocation));
                }
            }
        }
    }
}
