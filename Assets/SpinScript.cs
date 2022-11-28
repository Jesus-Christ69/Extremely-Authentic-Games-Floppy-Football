using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.PickerWheelUI;
using TMPro;
using UnityEngine.SceneManagement;
public class SpinScript : MonoBehaviour
{
    public Button WheelSpinBtn;
    public PickerWheel pickerWheel;

    //UI Prompts
    public GameObject SpinResultBox;
    public Button PlayAgainBtn, MainMenuBtn, ContinueBtn;
    public GameObject highScoreResult;
    public TMP_Text SpinResultTxt, newScoreText;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.UnloadSceneAsync("UI");
        //Button Functions
        PlayAgainBtn.onClick.AddListener(() =>
        {
            GameManager.GM.PlayerScore = 0;
            GameManager.GM.LoadNewScene("FlappyBird", false);
        });
        MainMenuBtn.onClick.AddListener(() =>
        {
            GameManager.GM.LoadNewScene("MainMenu", false);
        });
        ContinueBtn.onClick.AddListener(() =>
        {
            GameManager.GM.LoadNewScene("FlappyBird", false);
        });

        WheelSpinBtn.gameObject.SetActive(true);

        SpinResultBox.SetActive(false);
        highScoreResult.SetActive(false);
        //Set equal to GM jackpot
        pickerWheel.wheelPieces[4].Amount = GameManager.GM.JackpotScore;

        WheelSpinBtn.onClick.AddListener(() =>
        {
            // WheelSpinBtn.gameObject.SetActive(false);
            pickerWheel.OnSpinStart(() =>
            { WheelSpinBtn.gameObject.SetActive(false);
            });

            pickerWheel.OnSpinEnd((PickerWheel) =>
            {
                if (PickerWheel.Label == "Bonus")
                {
                    PlayAgainBtn.gameObject.SetActive(true);
                    ContinueBtn.gameObject.SetActive(false);
                    GameManager.GM.BonusPointsAward(PickerWheel.Amount);
                }
                if (PickerWheel.Label == "Jackpot")
                {
                    GameManager.GM.JackPotHit();
                }
                if (PickerWheel.Label == "Continue")
                {
                    GameManager.GM.ContinueBonus();

                    PlayAgainBtn.gameObject.SetActive(false);
                    ContinueBtn.gameObject.SetActive(true);
                }
                SpinResultFunc(PickerWheel.Amount);
                Debug.Log(PickerWheel.Label);
            });
            pickerWheel.Spin();
        });
    }

    private void SpinResultFunc(int scoreBonus)
    {
        SpinResultBox.SetActive(true);
        SpinResultTxt.text = "You got an extra " + scoreBonus + " Points!";
        newScoreText.text = "Total game score: " + GameManager.GM.PlayerScore;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
