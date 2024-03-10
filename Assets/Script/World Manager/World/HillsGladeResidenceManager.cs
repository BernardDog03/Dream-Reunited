using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Fungus;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class HillsGladeResidenceManager : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] GameObject mainCharacter;
    [SerializeField] GameObject spawn;
    [SerializeField] GameObject spawnStory;
    [SerializeField] GameObject NPCStory;

    [Header("Scripatble Object")]
    [SerializeField] SceneTwoSide sceneHG;
    [SerializeField] SceneTwoSide sceneHGR;

    [Space]
    [SerializeField] Flowchart flowchart;
    public Animator transition;
    public float transitionTime = 1f;

    [Header("NPC")]
    [SerializeField] GameObject ElaraValeska;
    [SerializeField] GameObject SamHunter;

    [Header("Story Object")]
    [SerializeField] GameObject C1M1;
    [SerializeField] GameObject C1M2;
    [SerializeField] GameObject C1M4;
    [SerializeField] GameObject C2M1;
    [SerializeField] GameObject C5M2;

    [SerializeField] StoryManager storyManager;

    //Event
    private delegate void chapter1Mission1Changed();
    private delegate void chapter1Mission2Changed();
    private delegate void chapter1Mission4Changed();
    private delegate void chapter2Mission1Changed();
    private delegate void chapter5Mission2Changed();
    private delegate void chapter1Mission2True();
    private delegate void chapter1Mission4True();
    private delegate void chapter2Mission1True();
    private delegate void chapter5Mission2True();
    private static event chapter1Mission2True OnChapter1Mission2True;
    private static event chapter1Mission4True OnChapter1Mission4True;
    private static event chapter2Mission1True OnChapter2Mission1True;
    private static event chapter5Mission2True Onchapter5Mission2True;
    private static event chapter1Mission1Changed OnChapter1Mission1Changed;
    private static event chapter1Mission2Changed OnChapter1Mission2Changed;
    private static event chapter1Mission4Changed OnChapter1Mission4Changed;
    private static event chapter2Mission1Changed OnChapter2Mission1Changed;
    private static event chapter5Mission2Changed Onchapter5Mission2Changed;



    void Start()
    {
        storyManager = StoryManager.GetInstance();
        storyManager.LoadData();
        OnChapter1Mission1Changed += HandleChapter1Mission1Changed;
        OnChapter1Mission2Changed += HandleChapter1Mission2Changed;
        OnChapter1Mission2True += HandleChapter1Mission2True;
        OnChapter1Mission4Changed += HandleChapter1Mission4Changed;
        OnChapter1Mission4True += HandleChapter1Mission4True;
        OnChapter2Mission1Changed += HandleChapter2Mission1Changed;
        OnChapter2Mission1True += HandleChapter2Mission1True;
        Onchapter5Mission2Changed += HandleChapter5Mission2Changed;
        Onchapter5Mission2True += HandleChapter5Mission2True;
        

        GetLastLocation();
    }

    void Update()
    {

        if (storyManager != null)
        {
            if (storyManager.newGame)
            {
                OnChapter1Mission1Changed.Invoke();
            }
            if (storyManager.chapter1Mission1 && !storyManager.chapter1Mission2)
            {
                OnChapter1Mission2Changed.Invoke();
            }
            if (storyManager.chapter1Mission2)
            {
                OnChapter1Mission2True.Invoke();
            }
            if (storyManager.chapter1Mission3 && !storyManager.chapter1Mission4)
            {
                OnChapter1Mission4Changed.Invoke();
            }
            if (storyManager.chapter1Mission4)
            {
                OnChapter1Mission4True.Invoke();
            }
            if (storyManager.chapter1Mission8 && !storyManager.chapter2Mission1)
            {
                OnChapter2Mission1Changed.Invoke();
            }
            if (storyManager.chapter2Mission1)
            {
                OnChapter2Mission1True.Invoke();
            }
            if(storyManager.chapter5Mission1 && !storyManager.chapter5Mission2)
            {
                Onchapter5Mission2Changed.Invoke();
            }
            if (storyManager.chapter5Mission2)
            {
                Onchapter5Mission2True.Invoke();
            }
        }
    }

    //Event Handler
    //Event Handler C1M1
    private void HandleChapter1Mission1Changed()
    {
        if (C1M1 != null && ElaraValeska != null)
        {
            if (storyManager.newGame && !storyManager.chapter1Mission1)
            {
                if (!C1M1.activeSelf)
                {
                    C1M1.SetActive(true);
                    ElaraValeska.SetActive(false);
                }
            }
            else if (storyManager.chapter1Mission1)
            {
                if (!ElaraValeska.activeSelf)
                {
                    ElaraValeska.SetActive(true);
                    C1M1.SetActive(false);
                }
            }
        }
    }
    //Event Handler C1M2
    private void HandleChapter1Mission2Changed()
    {
        if (C1M2 != null && SamHunter != null)
        {
            if (storyManager.chapter1Mission1 && !storyManager.chapter1Mission2)
            {
                if (!C1M2.activeSelf)
                {
                    C1M2.SetActive(true);
                    SamHunter.SetActive(false);
                }
            }

        }
    }
    private void HandleChapter1Mission2True()
    {
        if (C1M2 != null && SamHunter != null)
        if (storyManager.chapter1Mission2)
        {
                SamHunter.SetActive(true);
                C1M2.SetActive(false);
        }
    }

    //Event Handler C1M4
    private void HandleChapter1Mission4Changed()
    {
        if (C1M4 != null && SamHunter != null)
        {
            if (storyManager.chapter1Mission3 && !storyManager.chapter1Mission4)
            {
                    C1M4.SetActive(true);
                    SamHunter.SetActive(false);
            }
        }
    }
    private void HandleChapter1Mission4True()
    {
        if (C1M4 != null && SamHunter != null)
        {
            if (storyManager.chapter1Mission4)
            {
                    SamHunter.SetActive(true);
                    C1M4.SetActive(false);
            }
        }
    }

    //Event Handler C2M1
    private void HandleChapter2Mission1Changed()
    {
        if (C2M1 != null && SamHunter != null)
        {
            if (storyManager.chapter1Mission8 && !storyManager.chapter2Mission1)
            {
                C2M1.SetActive(true);
                SamHunter.SetActive(false);
            }
        }
    }
    private void HandleChapter2Mission1True()
    {
        if (C2M1 != null && SamHunter != null)
        {
            if (storyManager.chapter2Mission1)
            {
                C2M1.SetActive(false);
                SamHunter.SetActive(true);
            }
        }
    }

    //Event Handler C5M2
    private void HandleChapter5Mission2Changed()
    {
        if (C5M2 != null)
        {
            if (storyManager.chapter5Mission1 && !storyManager.chapter5Mission2)
            {
                C5M2.SetActive(true);
                SamHunter.SetActive(false);
            }
        }
    }
    private void HandleChapter5Mission2True()
    {
        if (C5M2 != null)
        {
            if (storyManager.chapter5Mission2)
            {
                C5M2.SetActive(false);
                SamHunter.SetActive(true);
            }
        }
    }

    //Load Scene using Coroutine Animation
    public void OnGoToHillsGlade()
    {
        LoadScene("Hills Glade");
    }
    public void OnGoToApartemen()
    {
        if (storyManager.chapter1Mission4 && !storyManager.chapter1Mission5)
        {
            flowchart.ExecuteBlock("C1M5");
        }
        else
        {
            LoadScene("Apartemen");
        }
    }

    //Save Last Location
    public void SaveLastPositionHGRHG()
    {
        GameHandler.SaveLocation("posHGRHG", "Hills Glade Residence",
        "isHGHHC", "isHGHGR", false, true,
        sceneHG.firstSceneTwoSide, sceneHG.secondSceneTwoSide,
        sceneHGR.posASceneTwoSide, mainCharacter.transform.position);
    }
    public void SaveLastPositionHGRApart()
    {
        GameHandler.SaveEndPointLocation("posHGRApart", sceneHGR.posBSceneTwoSide,
        mainCharacter.transform.position);
    }

    //Get last Location Data
    private void GetLastLocation()
    {
        GameHandler.GetLastLocation("isHGRHG", "isHGRApart", "posHGRHG", "posHGRApart",
        mainCharacter.transform, spawn);
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