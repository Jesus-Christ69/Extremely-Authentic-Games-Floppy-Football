using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public GameObject[] backgrounds;
    public Transform resetPos, StartPos;
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (backgrounds[i].transform.position.x <= resetPos.transform.position.x)
            {
                backgrounds[i].transform.position = StartPos.transform.position;
            }
        }
    }
}
