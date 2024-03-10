using System.Collections;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WildWoodManager : MonoBehaviour
{
    [Header("game Object")]
    [SerializeField] GameObject mainCharacter;
    [SerializeField] GameObject spawn;

    [Header("Animation")]
    [SerializeField] Animator transitionLoadingWorld;
    [SerializeField] Animator transitionLoadBattle;
    [SerializeField] float transitionTime = 1f;

    [Header("Scriptable Object")]
    [SerializeField] SceneEndPointLocation sceneWW;
    [SerializeField] SceneTwoSide sceneFloat;

    [Header("FlowChart")]
    [SerializeField] Flowchart flowchart;

    [Header("Story Obejct")]
    [SerializeField] GameObject C2M5;
    [SerializeField] GameObject C2M6;
    [SerializeField] GameObject C2M7;
    [SerializeField] GameObject officerSeraphine;
    [SerializeField] GameObject infoBoard;
    [SerializeField] GameObject border;

    [Header("Challenger State")]
    [SerializeField] int isChallenger1;
    [SerializeField] int isChallenger2;
    [SerializeField] int isChallenger3;
    [SerializeField] GameObject challengerObject1;
    [SerializeField] GameObject challengerObject2;
    [SerializeField] GameObject challengerObject3;
    [SerializeField] GameObject challengerlose1;
    [SerializeField] GameObject challengerlose2;
    [SerializeField] GameObject challengerlose3;

    private StoryManager storyManager;

    //Event
    private delegate void chapter2Mission6Changed();
    private delegate void chapter2Mission7Changed();
    private static event chapter2Mission6Changed OnChapter2Mission6Changed;
    private static event chapter2Mission7Changed OnChapter2Mission7Changed;


    void Start()
    {
        GetDataChallenger();
        ChallengerSetActive();
        storyManager = StoryManager.GetInstance();
        storyManager.LoadData();

        if (storyManager.chapter2Mission4 && !storyManager.chapter2Mission5)
        {
            mainCharacter.transform.position = C2M5.transform.position;
            flowchart.ExecuteBlock("C2M5");
        }
        else if ((storyManager.chapter2Mission5 && !storyManager.chapter2Mission6) ||
        (storyManager.chapter2Mission6 && !storyManager.chapter2Mission7))
        {
            mainCharacter.transform.position = C2M5.transform.position;
        }
        else
        {
            GetLastPosition();
        }

        OnChapter2Mission6Changed += HandleChapter2Mission6Changed;
        OnChapter2Mission7Changed += HandleChapter2Mission7Changed;
    }

    void Update()
    {
        if (storyManager.chapter2Mission5)
        {
            OnChapter2Mission6Changed.Invoke();
        }
        if (storyManager.chapter2Mission7)
        {
            OnChapter2Mission7Changed.Invoke();
        }
    }

    //Event Handler
    //Event C2M6
    private void HandleChapter2Mission6Changed()
    {
        if (C2M6 != null && border != null)
        {
            if (storyManager.chapter2Mission5 && !storyManager.chapter2Mission6)
            {
                if (!C2M6.activeSelf)
                {
                    C2M6.SetActive(true);
                    infoBoard.SetActive(false);
                }
            }
            else if (storyManager.chapter2Mission6)
            {
                if (C2M6.activeSelf)
                {
                    C2M6.SetActive(false);
                    infoBoard.SetActive(true);
                }
                border.SetActive(false);
            }
        }
    }
    //Event C2M7
    private void HandleChapter2Mission7Changed()
    {
        if (C2M7 != null)
        {
            if (storyManager.chapter2Mission7)
            {
                C2M7.SetActive(false);
                officerSeraphine.SetActive(true);
            }
        }
    }

    public void SaveLastPositionWW()
    {
        GameHandler.SaveLocation("posWWFloat", "Wild Wood", "isFloatWW", "isFloatDR",
        true, false,
        sceneFloat.firstSceneTwoSide, sceneFloat.secondSceneTwoSide,
        sceneWW.posEndPointLocation, mainCharacter.transform.position);
    }

    private void GetLastPosition()
    {
        string playerPosBattleString = PlayerPrefs.GetString("lastPositionBattle");
        Vector3 playerPos = JsonUtility.FromJson<Vector3>(playerPosBattleString);

        if (isChallenger1 == 1)
        {
            if (challengerObject1 != null)
                challengerObject1.SetActive(false);
            mainCharacter.transform.position = playerPos;
            isChallenger1 = 2;
            PlayerPrefs.SetInt("isChallenger1", isChallenger1);
            PlayerPrefs.Save();
        }
        else if (isChallenger2 == 1)
        {
            if (challengerObject2 != null)
                challengerObject2.SetActive(false);
            mainCharacter.transform.position = playerPos;
            isChallenger2 = 2;
            PlayerPrefs.SetInt("isChallenger1", isChallenger2);
            PlayerPrefs.Save();
        }
        else if (isChallenger3 == 1)
        {
            if (challengerObject3 != null)
                challengerObject3.SetActive(false);
            mainCharacter.transform.position = playerPos;
            isChallenger3 = 2;
            PlayerPrefs.SetInt("isChallenger1", isChallenger3);
            PlayerPrefs.Save();
        }
        else if (isChallenger1 == 2 && isChallenger2 == 2 && isChallenger3 == 2)
            GameHandler.GetLastPosition("posWWFloat", mainCharacter.transform, spawn);
    }
    private void GetDataChallenger()
    {
        int challenger1 = PlayerPrefs.GetInt("isChallenger1");
        int challenger2 = PlayerPrefs.GetInt("isChallenger2");
        int challenger3 = PlayerPrefs.GetInt("isChallenger3");

        isChallenger1 = challenger1;
        isChallenger2 = challenger2;
        isChallenger3 = challenger3;
    }

    private void ChallengerSetActive()
    {
        if (isChallenger1 == 1 || isChallenger1 == 2)
        {
            challengerObject1.SetActive(false);
            challengerlose1.SetActive(true);
        }
        if (isChallenger2 == 1 || isChallenger2 == 2)
        {
            challengerObject2.SetActive(false);
            challengerlose2.SetActive(true);
        }
        if (isChallenger3 == 1 || isChallenger3 == 2)
        {
            challengerObject3.SetActive(false);
            challengerlose3.SetActive(true);
        }
    }

    //Load scene using Coroutine Animation
    public void OnGoToFloatopia()
    {
        LoadScene("Floatopia");
    }

    //Coroutine Load Scene Animation
    private void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAnimation(sceneName));
    }
    IEnumerator LoadSceneAnimation(string sceneName)
    {
        transitionLoadingWorld.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }

    //Coroutine Load Battle Scene
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
