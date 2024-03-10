using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloatopiaManager : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] GameObject mainCharacter;
    [SerializeField] GameObject spawn;

    [Header("Scriptable Object")]
    [SerializeField] SceneTwoSide sceneFloat;
    [SerializeField] SceneTwoSide sceneDR;

    [Header("Animation")]
    [SerializeField] Animator transition;
    [SerializeField] Animator transitionLoadBattle;
    [SerializeField] float transisitionTime = 1f;

    [Header("Story Object")]
    [SerializeField] GameObject C2M8;
    [SerializeField] GameObject C3M1;
    [SerializeField] GameObject C3M2;
    [SerializeField] GameObject C3M3;
    [SerializeField] GameObject C3M4;
    [SerializeField] GameObject C3M5;
    [SerializeField] GameObject OfficerSteele;
    [SerializeField] GameObject XavierReed;
    [SerializeField] GameObject AmeliaClark;
    [SerializeField] GameObject DustRealm;
    [SerializeField] GameObject EthanCross;

    [Header("Challenger")]
    [SerializeField] int isChallenger4;
    [SerializeField] int isChallenger5;
    [SerializeField] int isChallenger6;
    [SerializeField] int isChallenger7;
    [SerializeField] int isChallenger8;
    [SerializeField] int isChallenger9;
    [SerializeField] GameObject challengerObject4;
    [SerializeField] GameObject challengerloseObject4;
    [SerializeField] GameObject challengerObject5;
    [SerializeField] GameObject challengerloseObject5;
    [SerializeField] GameObject challengerObject6;
    [SerializeField] GameObject challengerloseObject6;
    [SerializeField] GameObject challengerObject7;
    [SerializeField] GameObject challengerloseObject7;
    [SerializeField] GameObject challengerObject8;
    [SerializeField] GameObject challengerloseObject8;
    [SerializeField] GameObject challengerObject9;
    [SerializeField] GameObject challengerloseObject9;

    private StoryManager storyManager;
    private delegate void chapter2Mission8Changed();
    private delegate void chapter2Mission8True();
    private delegate void chapter3Mission1Changed();
    private delegate void chapter3Mission2Changed();
    private delegate void chapter3Mission2True();
    private delegate void chapter3Mission3Changed();
    private delegate void chapter3Mission3True();
    private delegate void chapter3Mission4Changed();
    private delegate void chapter3Mission4True();
    private delegate void chapter3Mission5Changed();
    private delegate void chapter3Mission5True();
    private static event chapter2Mission8Changed OnChapter2Mission8Changed;
    private static event chapter2Mission8True OnChapter2Mission8True;
    private static event chapter3Mission1Changed OnChapter3Mission1Changed;
    private static event chapter3Mission2Changed OnChapter3Mission2Changed;
    private static event chapter3Mission2True OnChapter3Mission2True;
    private static event chapter3Mission3Changed OnChapter3Mission3Changed;
    private static event chapter3Mission3True OnChapter3Mission3True;
    private static event chapter3Mission4Changed OnChapter3Mission4Changed;
    private static event chapter3Mission4True OnChapter3Mission4True;
    private static event chapter3Mission5Changed OnChapter3Mission5Changed;
    private static event chapter3Mission5True OnChapter3Mission5True;

    void Start()
    {
        GetDataChallenger();
        ChallengerSetActive();
        storyManager = StoryManager.GetInstance();
        storyManager.LoadData();

        GetLastLocation();

        OnChapter2Mission8Changed += HandleChapter2Mission8Changed;
        OnChapter2Mission8True += HandleChapter2Mission8True;
        OnChapter3Mission1Changed += HandleChapter3Mission1Changed;
        OnChapter3Mission2Changed += HandleChapter3Mission2Changed;
        OnChapter3Mission2True += HandleChapter3Mission2True;
        OnChapter3Mission3Changed += HandleChapter3Mission3Changed;
        OnChapter3Mission3True += HandleChapter3Mission3True;
        OnChapter3Mission4Changed += HandleChapter3Mission4Changed;
        OnChapter3Mission4True += HandleChapter3Mission4True;
        OnChapter3Mission5Changed += HandleChapter3Mission5Changed;
        OnChapter3Mission5True += HandleChapter3Mission5True;
    }

    void Update()
    {
        if (storyManager.chapter2Mission7 && !storyManager.chapter2Mission8)
        {
            OnChapter2Mission8Changed.Invoke();
        }
        if (storyManager.chapter2Mission8)
        {
            OnChapter2Mission8True.Invoke();
        }
        if (storyManager.chapter2Mission8 && !storyManager.chapter3Mission1)
        {
            OnChapter3Mission1Changed.Invoke();
        }
        if (storyManager.chapter3Mission1 && !storyManager.chapter3Mission2)
        {
            OnChapter3Mission2Changed.Invoke();
        }
        if (storyManager.chapter3Mission2)
        {
            OnChapter3Mission2True.Invoke();
        }
        if (storyManager.chapter3Mission2 && !storyManager.chapter3Mission3)
        {
            OnChapter3Mission3Changed.Invoke();
        }
        if (storyManager.chapter3Mission3)
        {
            OnChapter3Mission3True.Invoke();
        }
        if (storyManager.chapter3Mission3 && !storyManager.chapter3Mission4)
        {
            OnChapter3Mission4Changed.Invoke();
        }
        if (storyManager.chapter3Mission4)
        {
            OnChapter3Mission4True.Invoke();
        }
        if (storyManager.chapter3Mission4 && !storyManager.chapter3Mission5)
        {
            OnChapter3Mission5Changed.Invoke();
        }
        if (storyManager.chapter3Mission5)
        {
            OnChapter3Mission5True.Invoke();
        }
    }

    //Event Handler
    //C2M8
    private void HandleChapter2Mission8Changed()
    {
        if (C2M8 != null)
        {
            if (storyManager.chapter2Mission7 && !storyManager.chapter2Mission8)
            {
                if (!C2M8.activeSelf)
                {
                    C2M8.SetActive(true);
                }
            }
            else if (storyManager.chapter2Mission8)
            {
                if (C2M8.activeSelf)
                {
                    C2M8.SetActive(false);
                }
            }
        }
    }
    private void HandleChapter2Mission8True()
    {
        if (EthanCross != null)
        {
            if (storyManager.chapter2Mission8)
            {
                EthanCross.transform.position = new Vector3(35, 34);
            }
        }
    }
    //C3M1
    private void HandleChapter3Mission1Changed()
    {
        if (C3M1 != null && OfficerSteele != null)
        {
            if (storyManager.chapter2Mission8 && !storyManager.chapter3Mission1)
            {
                if (!C3M1.activeSelf)
                {
                    C3M1.SetActive(true);
                    OfficerSteele.SetActive(false);
                }
            }
            else
            {
                if (C3M1.activeSelf)
                {
                    C3M1.SetActive(false);
                    OfficerSteele.SetActive(true);
                }
            }
        }
    }
    //C3M2
    private void HandleChapter3Mission2Changed()
    {
        if (C3M2 != null)
        {
            if (storyManager.chapter3Mission1 && !storyManager.chapter3Mission2)
            {
                if (!C3M2.activeSelf)
                {
                    C3M2.SetActive(true);
                    XavierReed.SetActive(false);
                }
            }
        }
    }
    private void HandleChapter3Mission2True()
    {
        if (C3M2 != null)
        {
            if (storyManager.chapter3Mission2)
            {
                C3M2.SetActive(false);
                XavierReed.SetActive(true);
            }
        }
    }

    //C3M3
    private void HandleChapter3Mission3Changed()
    {
        if (C3M3 != null)
        {
            if (storyManager.chapter3Mission2 && !storyManager.chapter3Mission3)
            {
                if (!C3M3.activeSelf)
                {
                    C3M3.SetActive(true);
                    AmeliaClark.SetActive(false);
                }
            }
        }
    }
    private void HandleChapter3Mission3True()
    {
        if (C3M3 != null)
        {
            if (storyManager.chapter3Mission3)
            {
                C3M3.SetActive(false);
                AmeliaClark.SetActive(true);
            }
        }
    }

    //C3M4
    private void HandleChapter3Mission4Changed()
    {
        if (C3M4 != null)
        {
            if (storyManager.chapter3Mission3 && !storyManager.chapter3Mission4)
            {
                C3M4.SetActive(true);
                XavierReed.SetActive(false);
            }
        }
    }
    private void HandleChapter3Mission4True()
    {
        if (C3M4 != null)
        {
            if (storyManager.chapter3Mission4)
            {
                C3M4.SetActive(false);
                XavierReed.SetActive(true);
                DustRealm.SetActive(false);
            }
        }
    }

    //C3M5
    private void HandleChapter3Mission5Changed()
    {

        if (C3M5 != null)
        {
            if (storyManager.chapter3Mission4 && !storyManager.chapter3Mission5)
            {
                C3M5.SetActive(true);
            }
        }
    }
    private void HandleChapter3Mission5True()
    {
        if (C3M5 != null)
        {
            if (storyManager.chapter3Mission5)
            {
                C3M5.SetActive(false);
                EthanCross.SetActive(false);
            }
        }
    }

    private void GetDataChallenger()
    {
        int challenger4 = PlayerPrefs.GetInt("isChallenger4");
        int challenger5 = PlayerPrefs.GetInt("isChallenger5");
        int challenger6 = PlayerPrefs.GetInt("isChallenger6");
        int challenger7 = PlayerPrefs.GetInt("isChallenger7");
        int challenger8 = PlayerPrefs.GetInt("isChallenger8");
        int challenger9 = PlayerPrefs.GetInt("isChallenger9");

        isChallenger4 = challenger4;
        isChallenger5 = challenger5;
        isChallenger6 = challenger6;
        isChallenger7 = challenger7;
        isChallenger8 = challenger8;
        isChallenger9 = challenger9;
    }
    private void ChallengerSetActive()
    {
        if (isChallenger4 == 1 || isChallenger4 == 2)
        {
            challengerObject4.SetActive(false);
            challengerloseObject4.SetActive(true);
        }
        if (isChallenger5 == 1 || isChallenger5 == 2)
        {
            challengerObject5.SetActive(false);
            challengerloseObject5.SetActive(true);
        }
        if (isChallenger6 == 1 || isChallenger6 == 2)
        {
            challengerObject6.SetActive(false);
            challengerloseObject6.SetActive(true);
        }
        if (isChallenger7 == 1 || isChallenger7 == 2)
        {
            challengerObject7.SetActive(false);
            challengerloseObject7.SetActive(true);
        }
        if (isChallenger8 == 1 || isChallenger8 == 2)
        {
            challengerObject8.SetActive(false);
            challengerloseObject8.SetActive(true);
        }
        if (isChallenger9 == 1 || isChallenger9 == 2)
        {
            challengerObject9.SetActive(false);
            challengerloseObject9.SetActive(true);
        }
    }

    //Save Last Location
    public void SaveLastPositionFloatDR()
    {
        GameHandler.SaveLocation("posFloatDR", "Floatopia",
        "isDRFloat", "isDRFC", true, false,
        sceneDR.firstSceneTwoSide, sceneDR.secondSceneTwoSide, sceneFloat.posBSceneTwoSide,
        mainCharacter.transform.position);
    }
    public void SaveLastPositionFloatWW()
    {
        GameHandler.SaveEndPointLocation("posFloatWW", sceneFloat.posASceneTwoSide,
        mainCharacter.transform.position);
    }

    //Get Last Location Data
    private void GetLastLocation()
    {
        string playerPosBattleString = PlayerPrefs.GetString("lastPositionBattle");
        Vector3 playerPos = JsonUtility.FromJson<Vector3>(playerPosBattleString);

        if (isChallenger4 == 1)
        {
            if (challengerObject4 != null)
                challengerObject4.SetActive(false);
            mainCharacter.transform.position = playerPos;
            isChallenger4 = 2;
        }
        else if (isChallenger5 == 1)
        {
            if (challengerObject5 != null)
                challengerObject5.SetActive(false);
            mainCharacter.transform.position = playerPos;
            isChallenger5 = 2;
        }
        else if (isChallenger6 == 1)
        {
            if (challengerObject6 != null)
                challengerObject6.SetActive(false);
            mainCharacter.transform.position = playerPos;
            isChallenger6 = 2;
        }
        else if (isChallenger7 == 1)
        {
            if (challengerObject7 != null)
                challengerObject7.SetActive(false);
            mainCharacter.transform.position = playerPos;
            isChallenger7 = 2;
        }
        else if (isChallenger8 == 1)
        {
            if (challengerObject8 != null)
                challengerObject8.SetActive(false);
            mainCharacter.transform.position = playerPos;
            isChallenger8 = 2;
        }
        else if (isChallenger9 == 1)
        {
            if (challengerObject9 != null)
                challengerObject9.SetActive(false);
            mainCharacter.transform.position = playerPos;
            isChallenger9 = 2;
        }
        else if (isChallenger4 == 2 && isChallenger6 == 2
                && isChallenger7 == 2 && isChallenger8 == 2
                && isChallenger9 == 2)
            GameHandler.GetLastLocation("isFloatWW", "isFloatDR", "posFloatWW", "posFloatDR",
            characterTransform: mainCharacter.transform, spawn);

        PlayerPrefs.SetInt("isChallenger4", isChallenger4);
        PlayerPrefs.SetInt("isChallenger5", isChallenger5);
        PlayerPrefs.SetInt("isChallenger6", isChallenger6);
        PlayerPrefs.SetInt("isChallenger7", isChallenger7);
        PlayerPrefs.SetInt("isChallenger8", isChallenger8);
        PlayerPrefs.SetInt("isChallenger9", isChallenger9);
        PlayerPrefs.Save();
    }

    //Load Scene Coroutine using Animation
    public void OnGoToWW()
    {
        LoadScene("Wild Wood");
    }
    public void OnGotoDustRealm()
    {
        LoadScene("Dale Realm");
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
