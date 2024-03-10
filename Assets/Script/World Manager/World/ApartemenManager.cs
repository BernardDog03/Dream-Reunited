using System.Collections;
using Fungus;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApartemenManager : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] GameObject mainCharacter;
    [SerializeField] GameObject spawn;
    [SerializeField] GameObject spawnStory;

    [Header("Animator")]
    public Animator transition;

    [Header("Scriptable Object")]
    [SerializeField] SceneTwoSide sceneHGR;
    [SerializeField] SceneEndPointLocation sceneApart;

    [Header("FlowChart")]
    [SerializeField] Flowchart flowchart;

    [Space]
    public float transitionTime = 1f;
    [SerializeField] GameObject C1M8;
    [SerializeField] GameObject TriggerDoll;
    [SerializeField] GameObject Rachel;
    [SerializeField] GameObject C5M3;
    [SerializeField] GameObject dollBody;

    //Event
    private delegate void chapter1Mission8Changed();
    private static event chapter1Mission8Changed OnChapter1Mission8Changed;
    private delegate void chapter1Mission8True();
    private static event chapter1Mission8True OnChapter1Mission8True;
    private delegate void chapter5Mission3Changed();
    private static event chapter5Mission3Changed OnChapter5Mission3Changed;
    private delegate void chapter5Mission3True();
    private static event chapter5Mission3True OnChapter5Mission3True;

    private StoryManager storyManager;

    void Start()
    {
        storyManager = StoryManager.GetInstance();
        storyManager.LoadData();
        Debug.Log("Test " + storyManager.newGame);

        if (!storyManager.newGame)
        {
            Rachel.SetActive(true);
            mainCharacter.transform.position = spawnStory.transform.position;
            flowchart.ExecuteBlock("New Game");
        }
        else
        {
            GetLastPosition();
        }

        OnChapter1Mission8Changed += HandleChapter1Mission8Changed;
        OnChapter1Mission8True += HandleChapter1Mission8True;
        OnChapter5Mission3Changed += HandleChapter5Mission3Changed;
        OnChapter5Mission3True += HandleChapter5Mission3True;
    }

    void Update()
    {
        if (storyManager.chapter1Mission7 && !storyManager.chapter1Mission8)
        {
            OnChapter1Mission8Changed.Invoke();
        }
        if (storyManager.chapter1Mission8)
        {
            OnChapter1Mission8True.Invoke();
        }
        if (storyManager.chapter5Mission2 && !storyManager.chapter5Mission3)
        {
            OnChapter5Mission3Changed.Invoke();
        }
        if (storyManager.chapter5Mission3)
        {
            OnChapter5Mission3True.Invoke();
        }
    }

    //Event Handler
    //Event Handler C1M8
    private void HandleChapter1Mission8Changed()
    {
        if (C1M8 != null)
        {
            if (storyManager.chapter1Mission7 && !storyManager.chapter1Mission8)
            {
                if (!C1M8.activeSelf)
                    C1M8.SetActive(true);
            }
        }
    }
    private void HandleChapter1Mission8True()
    {
        if (C1M8 != null)
        {
            if (storyManager.chapter1Mission8)
            {
                if (!TriggerDoll.activeSelf)
                    TriggerDoll.SetActive(true);
                    C1M8.SetActive(false);
                    dollBody.SetActive(true);
            }
        }
    }

    //Even Handler C5M3
    private void HandleChapter5Mission3Changed()
    {
        if (C5M3 != null)
        {
            if (storyManager.chapter5Mission2 && !storyManager.chapter5Mission3)
                C5M3.SetActive(true);
                TriggerDoll.SetActive(false);
        }
    }
    private void HandleChapter5Mission3True()
    {
        if (C5M3 != null)
        {
            if (storyManager.chapter5Mission3)
                dollBody.SetActive(false);
        }
    }

    //Save Last Location
    public void SavelLastPositionApart()
    {
        GameHandler.SaveLocation("posApartHGR", "Apartemen", "isHGRHG", "isHGRApart",
        false, true,
        sceneHGR.firstSceneTwoSide, sceneHGR.secondSceneTwoSide,
        sceneApart.posEndPointLocation, mainCharacter.transform.position);
    }

    //Get Last Location Data
    private void GetLastPosition()
    {
        GameHandler.GetLastPosition("posApartHGR", mainCharacter.transform, spawn);
    }

    //Load Scene using Coroutine Animation
    public void OnGoToHillsGladeResidence()
    {
        LoadScene("Hills Glade Residence");
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