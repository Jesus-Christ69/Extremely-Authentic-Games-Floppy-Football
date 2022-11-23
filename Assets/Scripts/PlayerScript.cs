using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public float UpForce = 50f;
    public int PipeScore = 10;

    public bool BonusRound = false;

    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        GameManager.GM.LoadNewScene("UI", true);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(Vector3.up * UpForce * Time.deltaTime);
        }

        rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeadZone")
        {
            GameManager.GM.GameOverFunction();
            Debug.Log("Player Died");
        }
        if (other.gameObject.tag == "BonusRound")
        {
            BonusRound = true;
            Debug.Log("Bonus Round");
        }
        if (other.gameObject.tag == "AddPoints")
        {
            GameManager.GM.PlayerScore += PipeScore ;
            Debug.Log("Add Points");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BonusRound")
        BonusRound = false;
    }
}
