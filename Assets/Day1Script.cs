using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Day1Script : MonoBehaviour
{
    [TextArea(2,10)]
    public string[] TipBarStrings;
    public TMP_Text tipBarText;

    public float Day1Timer = 60f;
    private float tipBarTextTimer;
    public float tipBarDefaultTimer = 8f;
    public Slider ProgressBar;

    // Start is called before the first frame update
    void Start()
    {
        tipBarTextTimer = tipBarDefaultTimer * 2;
        StartCoroutine(TipText(TipBarStrings[0]));
        //NewTip();
        ProgressBar.maxValue = Day1Timer;
    }

    void NewTip()
    {
        int tips = Random.Range(0, TipBarStrings.Length);
        StartCoroutine(TipText(TipBarStrings[tips]));
        tipBarTextTimer = tipBarDefaultTimer;

    }

    IEnumerator TipText(string text)
    {
        tipBarText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            tipBarText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        tipBarTextTimer -= Time.deltaTime;   

        if (tipBarTextTimer <= 0)
        {
            NewTip();
        }

        Day1Timer -= Time.deltaTime;
        ProgressBar.value = Day1Timer;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.GM.LoadNewScene("MainMenu", false);
        }
        if (Day1Timer <= 0)
        {
            GameManager.GM.LoadNewScene("MainMenu", false);
        }
    }
}
