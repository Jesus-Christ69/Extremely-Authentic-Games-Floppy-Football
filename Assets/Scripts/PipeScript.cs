using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public PipeSpawn pipeSpawn;
    public float moveSpeed;

    public GameObject pipeBottom, pipeTop;
    public GameObject[] pipeObjs;

    private void Awake()
    {
        if (pipeSpawn == null)
        {
            pipeSpawn = GameObject.Find("PipeSpawner").GetComponent<PipeSpawn>();
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (transform.position.x <= pipeSpawn.ResetX)
        {
            pipeSpawn.ResetPipe(this.gameObject);
        }
    }
}
