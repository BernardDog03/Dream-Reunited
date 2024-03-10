using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RiverWoodCityManager : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] GameObject mainCharacter;
    [SerializeField] GameObject spawn;
    [SerializeField] GameObject spawnLab;

    [Header("Scriptable Object")]
    [SerializeField] SceneTwoSide sceneRWC;
    [SerializeField] SceneTwoSide sceneHHC;

    [Header("Animation")]
    public Animator transition;
    public float transitionTime = 1f;
    [SerializeField] bool isInsideLab = false;

    [Header("NPC")]
    [SerializeField] GameObject doorBefore;
    [SerializeField] GameObject doorAfter;

    [Header("Story Object")]
    [SerializeField] GameObject C1M6;
    [SerializeField] GameObject C1M7;
    [SerializeField] GameObject C2M2;

    [SerializeField] StoryManager storyManager;
    //Event
    private delegate void chapter1Mission6Changed();
    private delegate void chapter1Mission7Changed();
    private delegate void chapter2Mission2Changed();
    private delegate void chapter2Mission2True();
    private static event chapter1Mission6Changed OnChapter1Mission6Changed;
    private static event chapter1Mission7Changed OnChapter1Mission7Changed;
    private static event chapter2Mission2Changed OnChapter2Mission2Changed;
    private static event chapter2Mission2True OnChapter2Mission2True;

    void Start()
    {
        storyManager = StoryManager.GetInstance();
        storyManager.LoadData();

        OnChapter1Mission6Changed += HandleChapter1Mission6Changed;
        OnChapter1Mission7Changed += HandleChapter1Mission7Changed;
        OnChapter2Mission2Changed += HandleChapter2Mission2Changed;
        OnChapter2Mission2True += HandleChapter2Mission2True;

        GetLastLocation();
        
    }

    void Update()
    {
        if (storyManager.chapter1Mission5 && !storyManager.chapter1Mission6)
        {
            OnChapter1Mission6Changed.Invoke();
        }
        if (storyManager.chapter1Mission6 && !storyManager.chapter1Mission7)
        {
            OnChapter1Mission7Changed.Invoke();
        }
        if (storyManager.chapter2Mission1 && !storyManager.chapter2Mission2)
        {
            OnChapter2Mission2Changed.Invoke();
        }
        if (storyManager.chapter2Mission2)
        {
            OnChapter2Mission2True.Invoke();
        }
    }

    //Event Handler
    //Event C1M6
    private void HandleChapter1Mission6Changed()
    {
        if (C1M6 != null)
        {
            if (storyManager.chapter1Mission5 && !storyManager.chapter1Mission6)
            {
                if (!C1M6.activeSelf)
                {
                    C1M6.SetActive(true);
                }
            }
        }
    }
    //Event C1M7
    private void HandleChapter1Mission7Changed()
    {
        if (C1M7 != null)
        {
            if (storyManager.chapter1Mission6 && !storyManager.chapter1Mission7)
            {
                C1M7.SetActive(true);
            }
        }
    }
    //Event C2M2
    private void HandleChapter2Mission2Changed()
    {
        if (C2M2 != null)
        {
            if (storyManager.chapter2Mission1 && !storyManager.chapter2Mission2)
            {
                C2M2.SetActive(true);
                doorBefore.SetActive(false);
                doorAfter.SetActive(false);
            }
        }
    }
    private void HandleChapter2Mission2True()
    {
        if (C2M2 != null)
        {
            if (storyManager.chapter2Mission2)
            {
                C2M2.SetActive(false);
                doorBefore.SetActive(false);
                doorAfter.SetActive(true);
            }
        }
    }

    //Load Scene using Coroutine Animation
    public void OnGoToHomeTown()
    {
        LoadScene("Hometown");
    }
    public void OnGoToHarmonyHills()
    {
        LoadScene("Harmony Hills City");
    }
    public void OnGoInsideLab()
    {
        LoadScene("Laboratorium");
        isInsideLab = true;
        string OnInside = isInsideLab.ToString().Trim();
        PlayerPrefs.SetString("OnInsideLab", OnInside);
        PlayerPrefs.Save();
    }

    //Save Last Location
    public void SaveLastLocationRWCH()
    {
        GameHandler.SaveEndPointLocation("posRWCH", sceneRWC.posASceneTwoSide, mainCharacter.transform.position);
    }
    public void SaveLastLocationRWCHHC()
    {
        GameHandler.SaveLocation("posRWCHHC", "River Wood City",
        "isHHCRWC", "isHHCHG",
        true, false, sceneHHC.firstSceneTwoSide,
        sceneHHC.secondSceneTwoSide, sceneRWC.posBSceneTwoSide, mainCharacter.transform.position);
    }

    //Get Last Location Data
    private void GetLastLocation()
    {
        GameHandler.GetLastLocation("isRWCH", "isRWCHHC",
        "posRWCH", "posRWCHHC", mainCharacter.transform, spawn);

        isInsideLab = bool.Parse(PlayerPrefs.GetString("OnInsideLab"));
        if (isInsideLab)
        {
            mainCharacter.transform.position = spawnLab.transform.position;
            if (mainCharacter.transform.position == spawnLab.transform.position)
            {
                isInsideLab = false;
                PlayerPrefs.SetString("OnInsideLab", isInsideLab.ToString());
                PlayerPrefs.Save();
            }
        }
    }

    //Coroutine Load Scene Animation
    private void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAnimation(sceneName));
    }
    IEnumerator LoadSceneAnimation(string sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
