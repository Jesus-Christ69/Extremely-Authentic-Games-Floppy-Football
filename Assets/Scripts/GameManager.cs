using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public int JackpotScore;

    public int PlayerScore;
    public int PlayerHighScore;

    public int PlayerLevel;

    public bool Continued = false;

    private void Awake()
    {
        if (GM == null)
        {
            GM = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerLevel = 1;

        if (PlayerPrefs.GetInt("Jackpot") != 0)
        {
            JackpotScore = PlayerPrefs.GetInt("Jackpot");
        }

        if (PlayerPrefs.GetInt("HighScore")!= 0)
        {
            PlayerHighScore = PlayerPrefs.GetInt("HighScore");
        }

        LoadNewScene("Day1Patch", false);
    }

    public void GameOverFunction(bool bonusRound)
    {
        UIManager.UI.GameOver(bonusRound);
        PlayerPrefs.SetInt("Jackpot", JackpotScore);
        if (PlayerScore > PlayerHighScore)
        {
            PlayerHighScore = PlayerScore;
            Debug.Log("Setting High Score");
            PlayerPrefs.SetInt("HighScore", PlayerScore);
        }
        //PlayerScore = 0;
    }

    public void BonusPointsAward(int bonus)
    {
        PlayerScore += bonus;
        GameOverFunction(false);
    }

    public void ContinueBonus()
    {
        Continued = true;
        //UI Bonus Won
    }

    public void JackPotHit()
    {
        PlayerScore = JackpotScore;
        GameOverFunction(false);
    }

    public void LoadNewScene(string SceneName, bool Additive)
    {
        if (Additive)
            SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        else
            SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single);
    }
}
