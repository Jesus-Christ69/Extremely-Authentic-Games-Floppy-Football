using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour
{
    public Button PlayGame, GameOptions, GameCredits, QuitGame, HowToPlay;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        PlayGame.onClick.AddListener(() => StartCoroutine(CloseMenu("FlappyBird")));
        GameOptions.onClick.AddListener(() => StartCoroutine(CloseMenu("OptionsMenu")));
        GameCredits.onClick.AddListener(() => StartCoroutine(CloseMenu("GameCredits")));
        HowToPlay.onClick.AddListener(() => StartCoroutine(CloseMenu("HowToPlay")));
        QuitGame.onClick.AddListener(() => Application.Quit());
      //  GameOptions.onClick.AddListener(() => GameManager.GM.LoadNewScene("GameOptions", false));
      //  GameCredits.onClick.AddListener(() => GameManager.GM.LoadNewScene("GameCredits", false));
    }

    public void LaunchGame()
    {
        GameManager.GM.LoadNewScene("FlappyBird", false);

    }

    IEnumerator CloseMenu(string Scene)
    {
        AudioManager._AudioManager.PlaySound("Menu");
        anim.SetTrigger("CloseMenu");
        yield return new WaitForSeconds(0.25f);
        GameManager.GM.LoadNewScene(Scene, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
