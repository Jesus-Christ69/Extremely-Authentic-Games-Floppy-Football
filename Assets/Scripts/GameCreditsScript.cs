using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameCreditsScript : MonoBehaviour
{
    public TextAsset creditsTxtFile;
    public TMP_Text creditsText;
    public Button MainMenuBtn;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuBtn.onClick.AddListener(() => {
            AudioManager._AudioManager.PlaySound("Menu");
            GameManager.GM.LoadNewScene("MainMenu", false);
        });

        creditsText.text = creditsTxtFile.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
