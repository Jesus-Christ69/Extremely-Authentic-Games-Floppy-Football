using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public float SpinSpeed = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, SpinSpeed);
    }
}
