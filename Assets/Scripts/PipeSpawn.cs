using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipeObstacleObj;

    public List<GameObject> spawnPipes;

    public float spawnDistance;
    public float numSpawns;
    public float StartX;
    public float ResetX;
    public float minY, maxY;

    private void Awake()
    {
        spawnPipes = new List<GameObject>();

    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnPipes();
       // spawnPipes = new List<GameObject>();
    }

    void SpawnPipes()
    {
        for (int i = 1; i < numSpawns + 1; i++)
        {
            Vector3 SpawnLoc;
            SpawnLoc.x = spawnDistance * i;
            SpawnLoc.y = Random.Range(minY, maxY);
            SpawnLoc.z = transform.position.z;

            GameObject pipe = Instantiate(pipeObstacleObj, SpawnLoc, Quaternion.identity);
            spawnPipes.Add(pipe.gameObject);
        }
    }

    public void IncreaseSpeed()
    {
        for (int i = 0; i < spawnPipes.Count; i++)
        {
            spawnPipes[i].GetComponent<PipeScript>().moveSpeed++;
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
