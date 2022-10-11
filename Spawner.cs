using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject CrabPrefab;
    public float leftCorner;
    public float rightCorner;
    public float topCorner;

    float nextSpawnTime;
    public float spawnDelay;

    public int spawnCount;

    void Start()
    {
        nextSpawnTime = Time.time;
    }

    void Update()
    {
        if (nextSpawnTime < Time.time && spawnCount>0)
        {
            var CrabPosition = new Vector3(Random.Range(leftCorner, rightCorner), topCorner, 0);
            Instantiate(CrabPrefab, CrabPosition, this.transform.rotation);
            nextSpawnTime = Time.time + spawnDelay;
            spawnCount--;
        }
    }


}
