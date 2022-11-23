using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour
{
    public Button PlayGame, GameOptions, GameCredits, QuitGame;
    // Start is called before the first frame update
    void Start()
    {
        PlayGame.onClick.AddListener(() => GameManager.GM.LoadNewScene("FlappyBird", false));
        GameOptions.onClick.AddListener(() => GameManager.GM.LoadNewScene("GameOptions", false));
        GameCredits.onClick.AddListener(() => GameManager.GM.LoadNewScene("GameCredits", false));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
