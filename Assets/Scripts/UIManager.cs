using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager UI;
    public GameObject eventManager;

    public TMP_Text playerScore, HighScore, playerScoreGameOver;
    public GameObject HighScoreText, BonusRoundTxt, GameOverBox;
    public Button MainMenu, PlayAgain, BonusButton;

    private void Awake()
    {
        if (UI == null)
        {
            UI = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("UI Loaded");

       // GameManager.GM.uiManager = GetComponent<UIManager>();

        MainMenu.onClick.AddListener(() => GameManager.GM.LoadNewScene("MainMenu", false));
        PlayAgain.onClick.AddListener(() =>
        {
            GameManager.GM.PlayerLevel = 1;
            GameManager.GM.PlayerScore = 0;
            GameManager.GM.LoadNewScene("FlappyBird", false);
        });
        BonusButton.onClick.AddListener(() => GameManager.GM.LoadNewScene("BonusSpin", false));
        playerScore.text = GameManager.GM.PlayerScore.ToString();
        HighScore.text = GameManager.GM.PlayerHighScore.ToString();

        BonusButton.gameObject.SetActive(false);
        PlayAgain.gameObject.SetActive(true);

        GameOverBox.SetActive(false);
        HighScoreText.SetActive(false);
        BonusRoundTxt.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerScore.text = GameManager.GM.PlayerScore.ToString();
    }

    public void GameOver(bool BonusRound)
    {
        GameOverBox.SetActive(true);
        if (BonusRound)
        {
            BonusRoundTxt.SetActive(true);
            BonusButton.gameObject.SetActive(true);
            PlayAgain.gameObject.SetActive(false);
            /*   PlayAgain.onClick.AddListener(() => {
                   GameManager.GM.LevelEndScore = GameManager.GM.PlayerScore;
                   GameManager.GM.LoadNewScene("BonusSpin", false);
               });*/
         //   PlayAgainBtnTxt.text = "Bonus Round";
        }
        else
        {
            BonusRoundTxt.SetActive(false);

            BonusButton.gameObject.SetActive(false);
            PlayAgain.gameObject.SetActive(true);
            if (GameManager.GM.PlayerScore > GameManager.GM.PlayerHighScore)
            {
                HighScoreText.SetActive(true);
                HighScore.text = GameManager.GM.PlayerHighScore.ToString();
            }
        }
        playerScoreGameOver.text = GameManager.GM.PlayerScore.ToString();
    }
}
