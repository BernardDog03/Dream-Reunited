using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] Toggle toggleBgm;
    [SerializeField] Toggle toggleSfx;
    [SerializeField] Slider sliderBgm;
    [SerializeField] Slider sliderSfx;
    [SerializeField] TMP_Text volumeBgmText;
    [SerializeField] TMP_Text volumeSfxText;

    void Start()
    {
        audioManager.GetSoundSetting();
        toggleBgm.isOn = audioManager.IsMuteBgm;
        toggleSfx.isOn = audioManager.IsMuteSfx;

        sliderBgm.value = audioManager.BgmVolume;
        sliderSfx.value = audioManager.SfxVolume;
        SetBgmVolumeText(sliderBgm.value);
        SetSfxVolumeText(sliderSfx.value);

        
        Debug.Log("BGM Mute1: " + toggleBgm.isOn);
        Debug.Log("SFX Mute1: " + toggleSfx.isOn);
        Debug.Log("BGM Volume1: " + sliderBgm.value);
        Debug.Log("SFX Volume1: " + sliderSfx.value);
    }

    public void SetBgmVolumeText(float value)
    {
        volumeBgmText.text = Mathf.RoundToInt( value * 100).ToString();
    }

    public void SetSfxVolumeText(float value)
    {
        volumeSfxText.text = Mathf.RoundToInt( value * 100).ToString();
    }

    public void SetFullSceen(bool value)
    {
        Screen.fullScreen = value;
    }
}
