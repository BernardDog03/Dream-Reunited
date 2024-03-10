using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class HarmonyHillsManager : MonoBehaviour
{
    
    [Header("Game Object")]
    [SerializeField] GameObject mainCharacter;
    [SerializeField] GameObject spawn;

    [Header("Scriptable Object")]
    [SerializeField] SceneTwoSide sceneHHC;
    [SerializeField] SceneTwoSide sceneRWC;
    [SerializeField] SceneTwoSide sceneHG;

    [Space]
    public Animator transition;
    public float transitionTime = 1f;


    [Header("Story Object")]
    [SerializeField] GameObject C1M3;
    [SerializeField] GameObject officerMaverick;
    [SerializeField] GameObject officerMaverickAfter;

    [SerializeField] StoryManager storyManager;

    //Event
    private delegate void chapter1Mission3Changed();
    private delegate void chapter1Mission3True();
    private static event chapter1Mission3Changed OnChapter1Mission3Changed;
    private static event chapter1Mission3True OnChapter1Mission3True;


    void Start()
    {
        GetLastLocation();
        storyManager = StoryManager.GetInstance();
        storyManager.LoadData();
        OnChapter1Mission3Changed += HandleChapter1Mission3Changed;
        OnChapter1Mission3True += HandleChapter1Mission3True;
    }
        

    void Update()
    {
        if(storyManager.chapter1Mission2)
        {
            OnChapter1Mission3Changed.Invoke();
        }
        if(storyManager.chapter1Mission3)
        {
            OnChapter1Mission3True.Invoke();
        }
    }

    //Event Handler
    //Event Handler C1M3
    private void HandleChapter1Mission3Changed()
    {
        if (C1M3 != null && officerMaverick != null && officerMaverickAfter != null)
        {
            if(storyManager.chapter1Mission2 && !storyManager.chapter1Mission3)
            {
                if(!C1M3.activeSelf)
                {
                    C1M3.SetActive(true);
                    officerMaverick.SetActive(false);
                    officerMaverickAfter.SetActive(false);
                }
            }
            else
            {
                C1M3.SetActive(false);
                officerMaverick.SetActive(true);
                officerMaverickAfter.SetActive(true);
            }
        }
    }
    private void HandleChapter1Mission3True()
    {
        if (officerMaverickAfter != null)
        {
            if (storyManager.chapter1Mission3)
            {
                officerMaverick.SetActive(false);
                officerMaverickAfter.SetActive(true);
            }
        }
    }

    //Load Scene using Coroutine Animation
    public void OnGoToHillsGlade()
    {
        LoadScene("Hills Glade");
    }
    public void OnGoToRWC()
    {
        LoadScene("River Wood City");
    }

    //Save last Location
    public void SaveLastLocationHHCRWC()
    {
        GameHandler.SaveLocation("posHHCRWC", "Harmony Hills City", "isRWCH",
        "isRWCHHC", false, true, sceneRWC.firstSceneTwoSide,
        sceneRWC.secondSceneTwoSide, 
        sceneHHC.posASceneTwoSide, mainCharacter.transform.position);
        
    }
    public void SaveLastLocationHHCHG()
    {
        GameHandler.SaveLocation("posHHCHG", "Harmony Hills City", "isHGHHC",
        "isHGHGR", true, false,sceneHG.firstSceneTwoSide,
        sceneHG.secondSceneTwoSide, sceneHHC.posBSceneTwoSide, mainCharacter.transform.position);
    }

    //Get Last Loaction Data
    private void GetLastLocation()
    {
        GameHandler.GetLastLocation("isHHCRWC", "isHHCHG", 
        "posHHCRWC", "posHHCHG", mainCharacter.transform, spawn);
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
