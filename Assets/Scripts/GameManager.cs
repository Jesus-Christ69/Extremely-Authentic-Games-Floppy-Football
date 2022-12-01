using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   // public UIManager uiManager;
    public static GameManager GM;

    public int JackpotScore;

    public int PlayerScore;
    public int LevelEndScore;
    public int PlayerHighScore;

    public int PlayerLevel;

    public bool Continued = false;

    // Game options Settings
    public float MusicVolume;
    public float AudioVolume;
    private bool isFullScreen = false;
    private Resolution screenResolution;

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

       // LoadNewScene("Day1Patch", false);
    }

    public void GameOverFunction(bool bonusRound)
    {
        if (SceneManager.GetSceneByBuildIndex(5).IsValid())
        UIManager.UI.GameOver(bonusRound);

        //UIManager.UI.GameOver(bonusRound);
        PlayerPrefs.SetInt("Jackpot", JackpotScore);
        if (PlayerScore > PlayerHighScore)
        {
            PlayerHighScore = PlayerScore;
            Debug.Log("Setting High Score");
            PlayerPrefs.SetInt("HighScore", PlayerScore);
        }
        //PlayerScore = 0;
    }

    public void BonusRoundOverHighScore()
    {
        PlayerHighScore = PlayerScore;
        Debug.Log("Setting High Score");
        PlayerPrefs.SetInt("HighScore", PlayerScore);
    }

    public void BonusPointsAward(int bonus)
    {
        Debug.Log("player score end bonus round: " + PlayerScore);
        PlayerScore = LevelEndScore + bonus;
        GameOverFunction(false);
    }

    public void ContinueBonus(int bonus)
    {
        PlayerScore = LevelEndScore + bonus;
        Continued = true;
        //UI Bonus Won
    }

    public void JackPotHit()
    {
        PlayerScore = LevelEndScore + JackpotScore;
        JackpotScore = 0;
        PlayerPrefs.SetInt("Jackpot", 0);
        GameOverFunction(false);
    }

    public void LoadNewScene(string SceneName, bool Additive)
    {

            SceneManager.LoadSceneAsync(SceneName);
    }

    public void UnloadScene(string ScenenName)
    {
        SceneManager.UnloadSceneAsync(ScenenName);
    }

    //Game option Settings
    
    public void isFullScreenUpdate(bool IsFullScreen)
    {
        isFullScreen = IsFullScreen;
        Screen.fullScreen = IsFullScreen;
    }
    public void ResolutionUpdate(Resolution res)
    {
        Screen.SetResolution(res.width, res.height, isFullScreen);
    }
}
