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

    public float spinSpeed = 10f;
    public GameObject ballSprite;

    public GameObject clickToStart;
    public bool GameStarted = false;

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
         //   GameManager.GM.PlayerScore = GameManager.GM.LevelEndScore;
        }
        clickToStart.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!GameStarted)
            {
                clickToStart.SetActive(false);

                GameStarted = true;
                Time.timeScale = 1;
            }
            rb.AddForce(Vector3.up * UpForce * Time.deltaTime);
        }

        rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
    }

    private void FixedUpdate()
    {
        ballSprite.transform.Rotate(0, 0, rb.velocity.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DeadZone")
        {
            GameManager.GM.LevelEndScore = GameManager.GM.PlayerScore;
            GameManager.GM.GameOverFunction(BonusRound);
        }
        if (other.gameObject.tag == "BonusRound")
        {
            BonusRound = true;
        }
        if (other.gameObject.tag == "AddPoints")
        {
            GameManager.GM.PlayerScore += PipeScore ;
            GameManager.GM.JackpotScore += PipeScore * GameManager.GM.PlayerLevel;
            if (GameManager.GM.PlayerScore >= (PipeScore * 10) * GameManager.GM.PlayerLevel && GameManager.GM.PlayerLevel <= 8)
            {
                GameObject.Find("PipeSpawner").GetComponent<PipeSpawn>().IncreaseSpeed();
                Debug.Log("Level Up");
                GameManager.GM.PlayerLevel++;
            }
        }
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            GameManager.GM.PlayerScore += PipeScore;
            GameManager.GM.JackpotScore += PipeScore * GameManager.GM.PlayerLevel;
            AudioManager._AudioManager.PlaySound("Coin");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BonusRound")
        BonusRound = false;
    }
}
