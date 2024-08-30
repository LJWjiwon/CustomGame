using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class In : MonoBehaviour
{
    public GameObject[] Item;
    public GameObject[] SpawnLocation;
    private float lastSpawnTime;
    private float timeBetSpawn;
    private float xPos;
    private float yPos;

    private void Start()
    {
        lastSpawnTime = 0f;
        timeBetSpawn = 1f;
        yPos = SpawnLocation[0].transform.position.y;
    }

    private void Update()
    {
        xPos = Random.Range(SpawnLocation[0].transform.position.x, SpawnLocation[1].transform.position.x);


        if(Time.time >= lastSpawnTime + timeBetSpawn)
        {
            if (Random.Range(0, 5) == 0)
            {
                Item[0].transform.position = new Vector3(xPos, yPos);
                Instantiate(Item[0], Item[0].transform.position, Item[0].transform.rotation);
            }
            else
            {
                Item[1].transform.position = new Vector3(xPos, yPos);
                Instantiate(Item[1], Item[1].transform.position, Item[1].transform.rotation);
            }
            lastSpawnTime = Time.time;
        }
    }

    

}
