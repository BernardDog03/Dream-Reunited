using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    static AudioSource bgmInstance;
    static AudioSource sfxInstance;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioSource dialog;

    public bool IsMuteBgm { get => bgm.mute; }
    public bool IsMuteSfx { get => sfx.mute; }

    public float BgmVolume { get => bgm.volume; }
    public float SfxVolume { get => sfx.volume; }

    void Start()
    {
        GetSoundSetting();

        Debug.Log("BGM Mute: " + bgm.mute);
        Debug.Log("SFX Mute: " + sfx.mute);
        Debug.Log("BGM Volume: " + bgm.volume);
        Debug.Log("SFX Volume: " + sfx.volume);
    }
    void Awake()
    {
        // if (bgmInstance != null)
        // {
        //     Destroy(bgm.gameObject);
        //     bgm = bgmInstance;
        // }
        // else
        // {
        //     bgmInstance = bgm;
        //     bgm.transform.SetParent(null);
        //     DontDestroyOnLoad(bgm.gameObject);
        // }

        if (sfxInstance != null)
        {
            Destroy(sfx.gameObject);
            sfx = sfxInstance;
        }
        else
        {
            sfxInstance = sfx;
            sfx.transform.SetParent(null);
            DontDestroyOnLoad(sfx.gameObject);
        }
    }

    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (bgm.isPlaying)
            bgm.Stop();
        
        bgm.clip = clip;
        bgm.loop = loop;
        bgm.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (sfx.isPlaying)
            sfx.Stop();

        sfx.clip = clip;
        sfx.Play();
    }

    public void SetMuteBGM(bool value)
    {
        bgm.mute = value;

        string bgmMuteString = value.ToString().Trim();
        PlayerPrefs.SetString("BoolMuteBgm", bgmMuteString);
        PlayerPrefs.Save();
    }

    public void SetMuteSFX(bool value)
    {
        sfx.mute = value;
        dialog.mute = value;
        string sfxMuteString = value.ToString().Trim();
        PlayerPrefs.SetString("BoolMuteSfx", sfxMuteString);
        PlayerPrefs.Save();
    }

    public void SetBgmValue(float value)
    {
        bgm.volume = value;
        PlayerPrefs.SetFloat("VolumeBGM", value);
        PlayerPrefs.Save();
    }

    public void SetSfxValue(float value)
    {
        sfx.volume = value;
        dialog.volume = value;
        PlayerPrefs.SetFloat("VolumeSFX", value);
        PlayerPrefs.Save();
    }

    public void GetSoundSetting()
    {
        string muteBgm = PlayerPrefs.GetString("BoolMuteBgm").Trim();
        string muteSfx = PlayerPrefs.GetString("BoolMuteSfx").Trim();

        bgm.mute = bool.Parse(muteBgm);
        sfx.mute = bool.Parse(muteSfx);

        bgm.volume = PlayerPrefs.GetFloat("VolumeBGM");
        sfx.volume = PlayerPrefs.GetFloat("VolumeSFX");
    }
}