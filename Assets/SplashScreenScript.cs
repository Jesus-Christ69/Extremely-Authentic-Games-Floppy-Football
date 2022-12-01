using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SplashScreenScript : MonoBehaviour
{
    public Animator anim;
    public GameObject splashScreen1;
    public bool SplashScreen2 = false;

    public float screen1ExitDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SplashScreen());
    }

    IEnumerator SplashScreen()
    {
        while (screen1ExitDelay > 0)
        {
            screen1ExitDelay -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

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
