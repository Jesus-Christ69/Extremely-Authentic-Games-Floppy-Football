using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        //GameManager.GM.LoadNewScene("UI", true);
    }

    private void Start()
    {
        if (GameManager.GM.Continued)
        {
            GameManager.GM.PlayerScore = GameManager.GM.LevelEndScore;
        }
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
            GameManager.GM.GameOverFunction(BonusRound);
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
            GameManager.GM.JackpotScore += PipeScore * GameManager.GM.PlayerLevel;
            if (GameManager.GM.PlayerScore >= (PipeScore * 10) * GameManager.GM.PlayerLevel)
            {
                GameObject.Find("PipeSpawner").GetComponent<PipeSpawn>().IncreaseSpeed();
                Debug.Log("Level Up");
                GameManager.GM.PlayerLevel++;
            }
            Debug.Log("Add Points");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BonusRound")
        BonusRound = false;
    }
}
