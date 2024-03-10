using System.Collections;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrisonManager : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] GameObject mainCharacter;

    [Header("Animation")]
    [SerializeField] Animator transition;
    [SerializeField] float transisitionTime = 1f;

    [Header("Flowchart")]
    [SerializeField] Flowchart flowchart;

    [Header("Story Object")]
    [SerializeField] GameObject C4M4;
    [SerializeField] GameObject C4M5;
    [SerializeField] GameObject C4M6;
    [SerializeField] GameObject OfficerHudson;
    [SerializeField] GameObject Bed;

    private StoryManager storyManager;

    private delegate void chapter4Mission4Changed();
    private delegate void chapter4Mission4True();
    private delegate void chapter4Mission5True();
    private static event chapter4Mission4Changed OnChapter4Mission4Changed;
    private static event chapter4Mission4True OnChapter4Mission4True;
    private static event chapter4Mission5True OnChapter4Mission5True;

    void Start()
    {  
        storyManager = StoryManager.GetInstance();
        storyManager.LoadData();
        
        if (storyManager.chapter4Mission2 && !storyManager.chapter4Mission3)
        {
            flowchart.ExecuteBlock("C4M3");
            mainCharacter.transform.position = new Vector2(-32, -17);
            OfficerHudson.SetActive(false);
        }

        OnChapter4Mission4Changed += HandleChapter4Mission4Changed;
        OnChapter4Mission4True += HandleChapter4Mission4True;
        OnChapter4Mission5True += HandleChapter4Mission5True;
    }

    void Update()
    {
        if (storyManager.chapter4Mission3 && !storyManager.chapter4Mission4)
        {
            OnChapter4Mission4Changed.Invoke();
        }
        if (storyManager.chapter4Mission4)
        {
            OnChapter4Mission4True.Invoke();
        }
        if (storyManager.chapter4Mission5)
        {
            OnChapter4Mission5True.Invoke();
        }
    }

    //Event Handler
    //C4M4
    private void HandleChapter4Mission4Changed()
    {
        if (C4M4 != null)
        {
            if (storyManager.chapter4Mission3 && !storyManager.chapter4Mission4)
            {
                C4M4.SetActive(true);
                Bed.SetActive(false);
            }
        }
    }
    private void HandleChapter4Mission4True()
    {
        if (C4M4 != null)
        {
            if (storyManager.chapter4Mission4)
            {
                C4M4.SetActive(false);
                Bed.SetActive(true);
                C4M5.SetActive(true);
            }
        }
    }

    //C4M5
    private void HandleChapter4Mission5True()
    {
        if (C4M5 != null)
        {
            if (storyManager.chapter4Mission5)
            {
                C4M5.SetActive(false);
                C4M6.SetActive(true);
            }
        }
    }

    //Load Scene using Coroutine Animation
    public void OnGoToRachelLab()
    {
        LoadScene("Mysterious Lab");
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
