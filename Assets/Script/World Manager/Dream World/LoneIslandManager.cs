using System.Collections;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoneIslandManager : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] GameObject mainCharacter;
    [SerializeField] GameObject spawn;
    
    [Header("Animation")]
    [SerializeField] Animator transition;
    [SerializeField] float transisitionTime = 1f;

    [Header("Scriptable Object")]
    [SerializeField] SceneTwoSide sceneDR;
    [SerializeField] SceneEndPointLocation sceneLI;

    [Header("Flowchart")]
    [SerializeField] Flowchart flowchart;

    [Header("Story Obejct")]
    [SerializeField] GameObject BorderC4M1;
    [SerializeField] GameObject OfficerCharles;
    [SerializeField] GameObject OfficerBorder1;
    [SerializeField] GameObject OfficerBorder2;
    [SerializeField] GameObject OfficerBorder3;

    private StoryManager storyManager;
    private delegate void chapter4Mission1Changed();
    private static event chapter4Mission1Changed OnChapter4Mission1Changed;

    void Start()
    {
        storyManager = StoryManager.GetInstance();
        storyManager.LoadData();
        if (storyManager.chapter4Mission1)
        {
            mainCharacter.transform.position = new Vector2(-0.85f, -8.7f);
            OfficerCharles.SetActive(false);
            OfficerBorder1.transform.position = new Vector2(-2.5f, -3.5f);
            OfficerBorder2.transform.position = new Vector2(0.5f, -3.5f);
            OfficerBorder3.transform.position = new Vector2(-1, -3.5f);
        }
        else
        {
            GetLastPosition();
        }

        OnChapter4Mission1Changed += HandleChapter4Mission1Changed;
    }

    void Update()
    {
        if (storyManager.chapter4Mission1)
        {
            OnChapter4Mission1Changed.Invoke();
        }
    }

    //Event Handler
    //C4M1
    private void HandleChapter4Mission1Changed()
    {
        if (BorderC4M1 != null)
        {
            if (storyManager.chapter4Mission1 && !storyManager.chapter4Mission2)
            {
                if (!BorderC4M1.activeSelf)
                {
                    BorderC4M1.SetActive(true);
                }
            }
            else 
            {
                BorderC4M1.SetActive(false);
            }
        }
    }

    //Save Last Location
    public void SaveLastPositionLIDR()
    {
        GameHandler.SaveLocation("posLIDR", "Lone Island", "isDRFloat", "isDRLI",
        false, true, 
        sceneDR.firstSceneTwoSide, sceneDR.secondSceneTwoSide, 
        sceneLI.posEndPointLocation, mainCharacter.transform.position);
    }

    //Get Last Location Data
    private void GetLastPosition()
    {
        GameHandler.GetLastPosition("posLIDR", mainCharacter.transform,spawn);
    }

    //Load Scene using Coroutine Animation
    public void OnGoToDustRealm()
    {
        LoadScene("Dale Realm");
    }
    public void GoInsidePoliceStation()
    {
        LoadScene("Prison");
        storyManager.SaveGameProgress();
    }

    //Coroutine Load Scene Animation
    private void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAnimation(sceneName));
    }
    IEnumerator LoadSceneAnimation(string sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transisitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
