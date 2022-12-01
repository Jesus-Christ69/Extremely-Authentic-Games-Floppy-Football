using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SplashScreenScript : MonoBehaviour
{
    public Animator anim;
    public GameObject splashScreen1;
    public bool SplashScreen2 = false;

    public Slider LoadSlider;

    public float screen1ExitDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SplashScreen());
        LoadSlider.maxValue = screen1ExitDelay;
    }

    IEnumerator SplashScreen()
    {
        while (screen1ExitDelay > 0)
        {
            screen1ExitDelay -= Time.deltaTime;
            LoadSlider.value = screen1ExitDelay;
            yield return new WaitForEndOfFrame();
        }

        LoadSlider.gameObject.SetActive(false);
        anim.SetTrigger("Splash1Exit");
        SplashScreen2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && SplashScreen2)
        {
            GameManager.GM.LoadNewScene("Day1Patch", false);
        }
    }
}
