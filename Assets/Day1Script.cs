using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Day1Script : MonoBehaviour
{
    public float Day1Timer = 60f;
    public Slider ProgressBar;

    // Start is called before the first frame update
    void Start()
    {
        ProgressBar.maxValue = Day1Timer;
    }

    // Update is called once per frame
    void Update()
    {
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
