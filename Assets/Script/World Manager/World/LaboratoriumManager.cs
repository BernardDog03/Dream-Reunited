using System.Collections;
using Fungus;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaboratoriumManager : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] GameObject mainCharacter;
    [SerializeField] GameObject spawnLv1;
    [SerializeField] GameObject spawnLvUG;
    [SerializeField] GameObject level1;
    [SerializeField] GameObject levelUG;
    [SerializeField] Flowchart flowchart;

    [Header("Animation")]
    [SerializeField] Animator transition;
    [SerializeField] Animator transitionDream;

    public float transitionTime = 1f;

    [Header("NPC")]
    [SerializeField] GameObject ProfW;
    [SerializeField] bool isInsideLab;

    [Header("Story Object")]
    [SerializeField] GameObject C2M3;
    [SerializeField] GameObject C2M4;

    [SerializeField] StoryManager storyManager;

    private delegate void chapter2Mission3Changed();
    private static event chapter2Mission3Changed OnChapter2Mission3Changed;

    void Start()
    {
        OnChapter2Mission3Changed += HandleChapter2Mission3Changed;
        storyManager = StoryManager.GetInstance();
        storyManager.LoadData();
        if (storyManager.chapter4Mission8 && !storyManager.chapter5Mission1)
        {
            levelUG.SetActive(true);
            level1.SetActive(false);
            flowchart.ExecuteBlock("C5M1");
        }
        else
        {
            level1.SetActive(true);
            mainCharacter.transform.position = spawnLv1.transform.position;
        }

        InsideLab();
    }

    void Update()
    {
        if (storyManager.chapter2Mission2)
        {
            OnChapter2Mission3Changed.Invoke();
        }
    }

    //Event Handler
    private void HandleChapter2Mission3Changed()
    {
        if (C2M3 != null && C2M4 != null)
        {
            if (storyManager.chapter2Mission2 && !storyManager.chapter2Mission3)
            {
                if (!C2M3.activeSelf)
                {
                    C2M3.SetActive(true);
                    ProfW.SetActive(false);
                }
            }
            else if (storyManager.chapter2Mission3 && !storyManager.chapter2Mission4)
            {
                if (!C2M4.activeSelf)
                {
                    C2M3.SetActive(false);
                    C2M4.SetActive(true);
                }
            }
            else if (storyManager.chapter2Mission4)
            {
                if (C2M4.activeSelf)
                {
                    C2M4.SetActive(false);
                    ProfW.SetActive(true);
                }
            }
        }
    }

    public void OnGoToRiverWoodCity()
    {
        LoadScene("River Wood City");
    }
    public void OnGoToWildWood()
    {
        LoadSceneDream();
    }

    private void InsideLab()
    {
        isInsideLab = true;
        string OnInside = isInsideLab.ToString().Trim();
        PlayerPrefs.SetString("OnInsideLab", OnInside);
        PlayerPrefs.Save();
    }

    public void OnGoToUnderGroundLevel()
    {
        if (level1.activeSelf && !levelUG.activeSelf)
        {
            level1.SetActive(false);
            levelUG.SetActive(true);
            mainCharacter.transform.position = spawnLvUG.transform.position;
        }
    }
    public void OnGoToFirstLevel()
    {
        if (!level1.activeSelf && levelUG.activeSelf)
        {
            level1.SetActive(true);
            levelUG.SetActive(false);
            mainCharacter.transform.position = spawnLv1.transform.position;
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

    private void LoadSceneDream()
    {
        StartCoroutine(LoadSceneDreamAnimation());
    }
    IEnumerator LoadSceneDreamAnimation()
    {
        transitionDream.SetTrigger("Start");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Wild Wood");
    }
}