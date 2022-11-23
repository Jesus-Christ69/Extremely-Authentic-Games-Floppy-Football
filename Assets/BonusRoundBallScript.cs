using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusRoundBallScript : MonoBehaviour
{
    private Rigidbody rb;

    public Slider powerBar;

    public bool Fired = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Physics.gravity * rb.mass);

        
        if ( Input.GetMouseButtonUp(0) && !Fired)
        {
            rb.AddForce(Vector3.up * powerBar.value *500, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (!Fired && Input.GetMouseButton(0))
        {
            powerBar.value += 1;
            if (powerBar.value >= powerBar.maxValue)
            {
                powerBar.value = 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BonusStart")
        {
            Fired = false;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BonusStart")
        {
            Fired = true;
        }
    }
}
