using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public int PlayerScore;
    public int PlayerHighScore;

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
        if (PlayerPrefs.GetInt("HighScore")!= 0)
        {
            PlayerHighScore = PlayerPrefs.GetInt("HighScore");
        }

        LoadNewScene("Day1Patch", false);
    }

    public void GameOverFunction()
    {
        UIManager.UI.GameOver();
        if (PlayerScore > PlayerHighScore)
        {
            PlayerHighScore = PlayerScore;
            Debug.Log("Setting High Score");
            PlayerPrefs.SetInt("HighScore", PlayerScore);
        }
        PlayerScore = 0;
    }
    public void LoadNewScene(string SceneName, bool Additive)
    {
        if (Additive)
            SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        else
            SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Single);
    }
}
