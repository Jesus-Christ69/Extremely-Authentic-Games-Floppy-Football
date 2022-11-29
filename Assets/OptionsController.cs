using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsController : MonoBehaviour
{
    public Toggle FullScreenToggle;
    public TMP_Dropdown ResolutionOption;
    public Slider AudioSlider, MusicSlider;

    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        ResolutionOption.ClearOptions();

        List<string> resolutionString = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " - " + resolutions[i].refreshRate;
            resolutionString.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        ResolutionOption.AddOptions(resolutionString);

        ResolutionOption.value = currentResolutionIndex;
        ResolutionOption.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        GameManager.GM.AudioVolume = volume;
    }

    public void SetMusic(float volume)
    {
        GameManager.GM.MusicVolume = volume;
    }

    public void SetResolution (int value)
    {
        Resolution resolution = resolutions[ResolutionOption.value];
        GameManager.GM.ResolutionUpdate(resolution);
    }
    public void SetFullscreen(bool isFullScreen)
    {
        GameManager.GM.isFullScreenUpdate(isFullScreen);
    }
}
