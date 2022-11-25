using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager UI;

    public TMP_Text playerScore, HighScore, playerScoreGameOver;
    public GameObject HighScoreText, BonusRoundTxt, GameOverBox;
    public Button MainMenu, PlayAgain;
    public TextMeshProUGUI PlayAgainBtnTxt;

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
        MainMenu.onClick.AddListener(() => GameManager.GM.LoadNewScene("MainMenu", false));
        PlayAgain.onClick.AddListener(() => GameManager.GM.LoadNewScene("FlappyBird", false));

        playerScore.text = GameManager.GM.PlayerScore.ToString();
        HighScore.text = GameManager.GM.PlayerHighScore.ToString();

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
            HighScoreText.SetActive(false);
            BonusRoundTxt.SetActive(true);
            PlayAgain.onClick.AddListener(() => GameManager.GM.LoadNewScene("BonusSpin", false));
            PlayAgainBtnTxt.text = "Bonus Round";
        }
        else
        {
            if (GameManager.GM.PlayerScore > GameManager.GM.PlayerHighScore)
            {
                HighScoreText.SetActive(true);
                HighScore.text = GameManager.GM.PlayerHighScore.ToString();
            }
        }
        playerScoreGameOver.text = GameManager.GM.PlayerScore.ToString();
    }
}
