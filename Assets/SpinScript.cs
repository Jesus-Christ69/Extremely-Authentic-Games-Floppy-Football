using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.PickerWheelUI;

public class SpinScript : MonoBehaviour
{
    public Button WheelSpinBtn;
    public PickerWheel pickerWheel;

    // Start is called before the first frame update
    void Start()
    {
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
                    GameManager.GM.BonusPointsAward(PickerWheel.Amount);
                }
                if (PickerWheel.Label == "Jackpot")
                {
                    GameManager.GM.JackPotHit();
                }
                if (PickerWheel.Label == "Continue")
                {
                    GameManager.GM.ContinueBonus();
                }
                Debug.Log(PickerWheel.Label);
            });
            pickerWheel.Spin();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
