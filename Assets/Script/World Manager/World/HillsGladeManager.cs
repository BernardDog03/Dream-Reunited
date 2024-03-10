using System.Collections;
using Fungus;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class HillsGladeManager : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] GameObject mainCharacter;
    [SerializeField] GameObject spawn;

    [Header("Scriptable Object")]
    [SerializeField] SceneTwoSide sceneHG;
    [SerializeField] SceneTwoSide sceneHHC;
    [SerializeField] SceneTwoSide sceneHGR;

    [Header("Animation")]
    public Animator transition;
    public float transitionTime = 1f;

    [Header("Story Object")]
    [SerializeField] GameObject RachelTombstone;
    [SerializeField] GameObject RachelTombstoneTrigger;
    [SerializeField] GameObject Doll;
    [SerializeField] GameObject C5M4;

    private StoryManager storyManager;

    //Event
    private delegate void chapter1Mission8Changed();
    private delegate void chapter5Mission4Changed();
    private delegate void chapter5Mission4True();
    private static event chapter1Mission8Changed OnChapter1Mission8Changed;
    private static event chapter5Mission4Changed OnChapter5Mission4Changed;
    private static event chapter5Mission4True OnChapter5Mission4True;

    void Start()
    {
        storyManager = StoryManager.GetInstance();
        storyManager.LoadData();
        GetLastLocation();
        OnChapter1Mission8Changed += HandleChapter1Mission8Changed;
        OnChapter5Mission4Changed += HandleChapter5Mission4Changed;
        OnChapter5Mission4True += HandleChapter5Mission4True;
    }

    void Update()
    {
        if (storyManager.chapter1Mission8)
        {
            OnChapter1Mission8Changed.Invoke();
        }
        if (storyManager.chapter5Mission3 && !storyManager.chapter5Mission4)
        {
            OnChapter5Mission4Changed.Invoke();
        }
        if (storyManager.chapter5Mission4)
        {
            OnChapter5Mission4True.Invoke();
        }
    }

    //Event Handler
    //Event Handler C1M8
    private void HandleChapter1Mission8Changed()
    {
        if (RachelTombstone != null)
        {
            if (storyManager.chapter1Mission8)
            {
                if (!RachelTombstone.activeSelf)
                {
                    RachelTombstone.SetActive(true);
                }
            }
        }
    }
    //Event Handler C5M4
    private void HandleChapter5Mission4Changed()
    {
        if  (C5M4 != null)
        {
            if (storyManager.chapter5Mission3 && !storyManager.chapter5Mission4)
            {
                if (!C5M4.activeSelf)
                    C5M4.SetActive(true);
                    RachelTombstoneTrigger.SetActive(false);
            }
        }
    }
    //Event Handler FInished
    private void HandleChapter5Mission4True()
    {
        if (RachelTombstoneTrigger != null)
        {
            if (storyManager.chapter5Mission4)
                C5M4.SetActive(false);
                RachelTombstoneTrigger.SetActive(true);
                Doll.SetActive(true);
        }
    }

    //Load Scene using Coroutine Animation
    public void OnGoToHarmonyHills()
    {
        LoadScene("Harmony Hills City");
    }
    public void OnGoToHillsGladeResidence()
    {
        LoadScene("Hills Glade Residence");
    }

    //Save Last Location
    public void SaveLastLocationHGHHC()
    {
        GameHandler.SaveLocation("posHGHHC", "Hills Glade", "isHHCRWC",
        "isHHCHG",
        false, true,
        sceneHHC.firstSceneTwoSide, sceneHHC.secondSceneTwoSide,
        sceneHG.posASceneTwoSide, mainCharacter.transform.position);
    }
    public void SaveLastLocationHGHGR()
    {
        GameHandler.SaveLocation("posHGHGR", "Hills Glade", "isHGRHG",
        "isHGRApart", true, false,
        sceneHGR.firstSceneTwoSide, sceneHGR.secondSceneTwoSide,
        sceneHG.posBSceneTwoSide, mainCharacter.transform.position);
    }

    //Get Last Location Data
    private void GetLastLocation()
    {
        GameHandler.GetLastLocation("isHGHHC", "isHGHGR",
        "posHGHHC","posHGHGR", mainCharacter.transform, spawn);
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