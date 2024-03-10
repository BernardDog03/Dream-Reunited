using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DaleRealmManager : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] GameObject mainCharacter;
    [SerializeField] GameObject spawn;

    [Header("Scriptable Object")]
    [SerializeField] SceneTwoSide sceneDR;
    [SerializeField] SceneTwoSide sceneFloat;
    [SerializeField] SceneEndPointLocation sceneLI;

    [Header("Animation")]
    [SerializeField] Animator transition;
    [SerializeField] Animator transitionLoadBattle;
    [SerializeField] float transisitionTime = 1f;

    [Header("Story Object")]
    [SerializeField] GameObject EthanCross;
    [SerializeField] GameObject C3M6;
    [SerializeField] GameObject C3M7;
    [SerializeField] GameObject C3M8;
    [SerializeField] GameObject Border;

    [Header("Challenger State")]
    [SerializeField] int isChallenger10;
    [SerializeField] int isChallenger11;
    [SerializeField] int isChallenger12;
    [SerializeField] int isChallenger13;
    [SerializeField] GameObject challengerObject10;
    [SerializeField] GameObject challengerLoseObject10;
    [SerializeField] GameObject challengerObject11;
    [SerializeField] GameObject challengerLoseObject11;
    [SerializeField] GameObject challengerObject12;
    [SerializeField] GameObject challengerLoseObject12;
    [SerializeField] GameObject challengerObject13;
    [SerializeField] GameObject challengerLoseObject13;

    private StoryManager storyManager;

    //Event
    private delegate void chapter3Mission6Changed();
    private delegate void chapter3Mission7Changed();
    private delegate void chapter3Mission8Changed();
    private static event chapter3Mission6Changed OnChapter3Mission6Changed;
    private static event chapter3Mission7Changed OnChapter3Mission7Changed;
    private static event chapter3Mission8Changed OnChapter3Mission8Changed;

    void Start()
    {
        GetDataChallenger();
        ChallengerSetActive();
        storyManager = StoryManager.GetInstance();
        storyManager.LoadData();
        GetLastPosition();

        OnChapter3Mission6Changed += HandleChapter3Mission6Changed;
        OnChapter3Mission7Changed += HandleChapter3Mission7Changed;
        OnChapter3Mission8Changed += HandleChapter3Mission8Changed;
    }

    void Update()
    {
        if (storyManager.chapter3Mission5)
        {
            OnChapter3Mission6Changed.Invoke();
        }
        if (storyManager.chapter3Mission6)
        {
            OnChapter3Mission7Changed.Invoke();
        }
        if (storyManager.chapter3Mission7)
        {
            OnChapter3Mission8Changed.Invoke();
        }
    }

    //Event Handler
    //C3M6
    private void HandleChapter3Mission6Changed()
    {
        if (C3M6 != null)
        {
            if (storyManager.chapter3Mission5 && !storyManager.chapter3Mission6)
            {
                if (!C3M6.activeSelf)
                {
                    C3M6.SetActive(true);
                }
            }
            else
            {
                C3M6.SetActive(false);
            }
        }
    }
    //C3M7
    private void HandleChapter3Mission7Changed()
    {
        if (C3M7 != null)
        {
            if (storyManager.chapter3Mission6 && !storyManager.chapter3Mission7)
            {
                if (!C3M7.activeSelf)
                {
                    C3M7.SetActive(true);
                    Border.SetActive(true);
                }
            }
            else
            {
                C3M7.SetActive(false);
                Border.SetActive(false);
            }
        }
    }
    //C3M8
    private void HandleChapter3Mission8Changed()
    {
        if (C3M8 != null)
        {
            if (storyManager.chapter3Mission7 && !storyManager.chapter3Mission8)
            {
                if (!C3M8.activeSelf)
                {
                    C3M8.SetActive(true);
                }
            }
            else if (storyManager.chapter3Mission8)
            {
                if (C3M8.activeSelf)
                {
                    C3M8.SetActive(false);
                }
            }
        }
    }

    //Save Last Position
    public void SaveLastPositionDRFloat()
    {
        GameHandler.SaveLocation("posDRFloat", "Dust Realm",
        "isFloatWW", "isFloatDR", false, true,
        sceneFloat.firstSceneTwoSide, sceneFloat.secondSceneTwoSide,
        sceneDR.posASceneTwoSide, mainCharacter.transform.position);
    }
    public void SaveLastPositionDRLI()
    {
        GameHandler.SaveEndPointLocation("posDRLI", sceneDR.posBSceneTwoSide,
        mainCharacter.transform.position);
    }

    private void GetDataChallenger()
    {
        int challenger10 = PlayerPrefs.GetInt("isChallenger10");
        int challenger11 = PlayerPrefs.GetInt("isChallenger11");
        int challenger12 = PlayerPrefs.GetInt("isChallenger12");
        int challenger13 = PlayerPrefs.GetInt("isChallenger13");

        isChallenger10 = challenger10;
        isChallenger11 = challenger11;
        isChallenger12 = challenger12;
        isChallenger13 = challenger13;
    }
    private void ChallengerSetActive()
    {
        if (isChallenger10 == 1 || isChallenger10 == 2)
        {
            challengerObject10.SetActive(false);
            challengerLoseObject10.SetActive(true);
        }
        if (isChallenger11 == 1 || isChallenger11 == 2)
        {
            challengerObject11.SetActive(false);
            challengerLoseObject11.SetActive(true);
        }
        if (isChallenger12 == 1 || isChallenger12 == 2)
        {
            challengerObject12.SetActive(false);
            challengerLoseObject12.SetActive(true);
        }
        if (isChallenger13 == 1 || isChallenger13 == 2)
        {
            challengerObject13.SetActive(false);
            challengerLoseObject13.SetActive(true);
        }
    }

    //Get Last Position
    private void GetLastPosition()
    {
        string playerPosBattleString = PlayerPrefs.GetString("lastPositionBattle");
        Vector3 playerPos = JsonUtility.FromJson<Vector3>(playerPosBattleString);

        if (isChallenger10 == 1)
        {
            if (challengerObject10 != null)
                challengerObject10.SetActive(false);
            mainCharacter.transform.position = playerPos;
            isChallenger10 = 2;
            Debug.Log("10");
        }
        else if (isChallenger11 == 1)
        {
            if (challengerObject11 != null)
                challengerObject11.SetActive(false);
            mainCharacter.transform.position = playerPos;
            isChallenger11 = 2;
            Debug.Log("11");
        }
        else if (isChallenger12 == 1)
        {
            if (challengerObject12 != null)
                challengerObject12.SetActive(false);
            mainCharacter.transform.position = playerPos;
            isChallenger12 = 2;
            Debug.Log("12");
        }
        else if (isChallenger13 == 1)
        {
            if (challengerObject13 != null)
                challengerObject13.SetActive(false);
            mainCharacter.transform.position = playerPos;
            isChallenger13 = 2;
            Debug.Log("13");
        }
        else if ((isChallenger10 == 0 && isChallenger11 == 0 && isChallenger12 == 0 && isChallenger13 == 0) || 
        (isChallenger10 == 2 && isChallenger11 == 2 && isChallenger12 == 2 && isChallenger13 == 2))
        {
            GameHandler.GetLastLocation("isDRFloat", "isDRFC", "posDRFloat", "posDRLI",
            mainCharacter.transform, spawn);
            Debug.Log("json");
        }

        PlayerPrefs.SetInt("isChallenger10", isChallenger10);
        PlayerPrefs.SetInt("isChallenger11", isChallenger11);
        PlayerPrefs.SetInt("isChallenger12", isChallenger12);
        PlayerPrefs.SetInt("isChallenger13", isChallenger13);
        PlayerPrefs.Save();
    }

    //Load Scene Coroutine using Animation
    public void OnGoToFloatopia()
    {
        LoadScene("Floatopia");
    }
    public void OnGoToLI()
    {
        LoadScene("Lone Island");
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

    private void LoadBattleScene()
    {
        StartCoroutine(LoadBattleSceneAnimation());
    }

    IEnumerator LoadBattleSceneAnimation()
    {
        transitionLoadBattle.SetTrigger("Start");
        yield return new WaitForSeconds(2);
    }
}
