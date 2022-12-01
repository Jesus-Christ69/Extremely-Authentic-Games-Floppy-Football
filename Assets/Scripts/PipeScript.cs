using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public PipeSpawn pipeSpawn;
    public float moveSpeed;

    public GameObject pipeBottom, pipeTop;
    public GameObject[] pipeObjs;

    public GameObject coin;
    public float MinYCoin, MaxYCoin;

    private void Awake()
    {
        if (pipeSpawn == null)
        {
            pipeSpawn = GameObject.Find("PipeSpawner").GetComponent<PipeSpawn>();
        }
        CoinLocation();
    }

    private void CoinLocation()
    {
        coin.SetActive(true);
        float CoinPos = Random.Range(MinYCoin, MaxYCoin);
        coin.transform.position = new Vector3(transform.position.x, transform.position.y+ CoinPos, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (transform.position.x <= pipeSpawn.ResetX)
        {
            pipeSpawn.ResetPipe(this.gameObject);

            CoinLocation();
        }
    }
}
