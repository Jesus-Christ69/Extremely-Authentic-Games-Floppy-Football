using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipeObstacleObj;

    public float spawnDistance;
    public float numSpawns;
    public float StartX;
    public float ResetX;
    public float minY, maxY;


    // Start is called before the first frame update
    void Start()
    {
        SpawnPipes();
    }

    void SpawnPipes()
    {
        for (int i = 2; i < numSpawns + 2; i++)
        {
            Vector3 SpawnLoc;
            SpawnLoc.x = spawnDistance * i;
            SpawnLoc.y = Random.Range(minY, maxY);
            SpawnLoc.z = transform.position.z;

            GameObject pipe = Instantiate(pipeObstacleObj, SpawnLoc, Quaternion.identity);
        }
    }

    public void ResetPipe(GameObject pipe)
    {
        Vector3 SpawnLoc;
        SpawnLoc.x = StartX;
        SpawnLoc.y = Random.Range(minY, maxY);
        SpawnLoc.z = transform.position.z;

        pipe.transform.position = SpawnLoc;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
