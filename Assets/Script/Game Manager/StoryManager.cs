using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance;
    [SerializeField] TextAsset missionDataJson;
    [SerializeField] StateStory stateStory;
    [SerializeField] StateMission stateMission;
    [SerializeField] TMP_Text currentMission;

    [Space]
    public bool newGame;

    [Header("Chapter 1")]
    public bool chapter1;
    public bool chapter1Mission1;
    public bool chapter1Mission2;
    public bool chapter1Mission3;
    public bool chapter1Mission4;
    public bool chapter1Mission5;
    public bool chapter1Mission6;
    public bool chapter1Mission7;
    public bool chapter1Mission8;

    [Header("Chapter 2")]
    public bool chapter2;
    public bool chapter2Mission1;
    public bool chapter2Mission2;
    public bool chapter2Mission3;
    public bool chapter2Mission4;
    public bool chapter2Mission5;
    public bool chapter2Mission6;
    public bool chapter2Mission7;
    public bool chapter2Mission8;

    [Header("Chapter 3")]
    public bool chapter3;
    public bool chapter3Mission1;
    public bool chapter3Mission2;
    public bool chapter3Mission3;
    public bool chapter3Mission4;
    public bool chapter3Mission5;
    public bool chapter3Mission6;
    public bool chapter3Mission7;
    public bool chapter3Mission8;

    [Header("Chapter 4")]
    public bool chapter4;
    public bool chapter4Mission1;
    public bool chapter4Mission2;
    public bool chapter4Mission3;
    public bool chapter4Mission4;
    public bool chapter4Mission5;
    public bool chapter4Mission6;
    public bool chapter4Mission7;
    public bool chapter4Mission8;

    [Header("Chapter 5")]
    public bool chapter5;
    public bool chapter5Mission1;
    public bool chapter5Mission2;
    public bool chapter5Mission3;
    public bool chapter5Mission4;

    enum StateStory
    {
        NewGame,
        Chapter1,
        Chapter2,
        Chapter3,
        Chapter4,
        Chapter5,
        Finished
    }

    enum StateMission
    {
        Mission1,
        Mission2,
        Mission3,
        Mission4,
        Mission5,
        Mission6,
        Mission7,
        Mission8
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static StoryManager GetInstance()
    {
        return Instance;
    }

    void Update()
    {
        ChapterData chapterData = JsonUtility.FromJson<ChapterData>(missionDataJson.text);
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            switch (stateStory)
            {
                case StateStory.NewGame:
                    stateStory = StateStory.Chapter1;
                    currentMission.text = chapterData.Chapter1.Mission1;
                    break;
                //Chapter 1
                case StateStory.Chapter1:
                    switch (stateMission)
                    {
                        //Mission 1
                        case StateMission.Mission1:
                            if (chapter1Mission1)
                            {
                                stateMission = StateMission.Mission2;
                                currentMission.text = chapterData.Chapter1.Mission2;
                            }
                            break;
                        //Mission 2
                        case StateMission.Mission2:
                            if (chapter1Mission2)
                            {
                                stateMission = StateMission.Mission3;
                                currentMission.text = chapterData.Chapter1.Mission3;
                            }
                            break;
                        //Mission3
                        case StateMission.Mission3:
                            if (chapter1Mission3)
                            {
                                stateMission = StateMission.Mission4;
                                currentMission.text = chapterData.Chapter1.Mission4;
                            }
                            break;
                        //Mission 4
                        case StateMission.Mission4:
                            if (chapter1Mission4)
                            {
                                stateMission = StateMission.Mission5;
                                currentMission.text = chapterData.Chapter1.Mission5;
                            }
                            break;
                        //Mission 5
                        case StateMission.Mission5:
                            if (chapter1Mission5)
                            {
                                stateMission = StateMission.Mission6;
                                currentMission.text = chapterData.Chapter1.Mission6;
                            }
                            break;
                        //Mission 6
                        case StateMission.Mission6:
                            if (chapter1Mission6)
                            {
                                stateMission = StateMission.Mission7;
                                currentMission.text = chapterData.Chapter1.Mission7;
                            }
                            break;
                        //Mission 7
                        case StateMission.Mission7:
                            if (chapter1Mission7)
                            {
                                stateMission = StateMission.Mission8;
                                currentMission.text = chapterData.Chapter1.Mission8;
                            }
                            break;
                        //Mission 8
                        case StateMission.Mission8:
                            if (chapter1Mission8)
                            {
                                stateMission = StateMission.Mission1;
                                stateStory = StateStory.Chapter2;
                                currentMission.text = chapterData.Chapter2.Mission1;
                                chapter1 = true;
                            }
                            break;
                    }
                    break;
                //Chapter 2
                case StateStory.Chapter2:
                    switch (stateMission)
                    {
                        //Mission 1
                        case StateMission.Mission1:
                            if (chapter2Mission1)
                            {
                                stateMission = StateMission.Mission2;
                                currentMission.text = chapterData.Chapter2.Mission2;
                            }
                            break;

                        //Mission 2
                        case StateMission.Mission2:
                            if (chapter2Mission2)
                            {
                                stateMission = StateMission.Mission3;
                                currentMission.text = chapterData.Chapter2.Mission3;
                            }
                            break;
                        //Mission 3
                        case StateMission.Mission3:
                            if (chapter2Mission3)
                            {
                                stateMission = StateMission.Mission4;
                                currentMission.text = chapterData.Chapter2.Mission4;
                            }
                            break;
                        //Mission 4
                        case StateMission.Mission4:
                            if (chapter2Mission4)
                            {
                                stateMission = StateMission.Mission5;
                                currentMission.text = chapterData.Chapter2.Mission5;
                            }
                            break;
                        //Mission 5
                        case StateMission.Mission5:
                            if (chapter2Mission5)
                            {
                                stateMission = StateMission.Mission6;
                                currentMission.text = chapterData.Chapter2.Mission6;
                            }
                            break;
                        //Mission 6
                        case StateMission.Mission6:
                            if (chapter2Mission6)
                            {
                                stateMission = StateMission.Mission7;
                                currentMission.text = chapterData.Chapter2.Mission7;
                            }
                            break;
                        //Mission 7
                        case StateMission.Mission7:
                            if (chapter2Mission7)
                            {
                                stateMission = StateMission.Mission8;
                                currentMission.text = chapterData.Chapter2.Mission8;
                            }
                            break;
                        //Mission 8
                        case StateMission.Mission8:
                            if (chapter2Mission8)
                            {
                                stateMission = StateMission.Mission1;
                                currentMission.text = chapterData.Chapter3.Mission1;
                                stateStory = StateStory.Chapter3;
                                chapter2 = true;
                            }
                            break;
                    }
                    break;
                //Chapter 3
                case StateStory.Chapter3:
                    switch (stateMission)
                    {
                        //Mission 1
                        case StateMission.Mission1:
                            if (chapter3Mission1)
                            {
                                stateMission = StateMission.Mission2;
                                currentMission.text = chapterData.Chapter3.Mission2;
                            }
                            break;
                        //Mission 2
                        case StateMission.Mission2:
                            if (chapter3Mission2)
                            {
                                stateMission = StateMission.Mission3;
                                currentMission.text = chapterData.Chapter3.Mission3;
                            }
                            break;
                        //Mission 3
                        case StateMission.Mission3:
                            if (chapter3Mission3)
                            {
                                stateMission = StateMission.Mission4;
                                currentMission.text = chapterData.Chapter3.Mission4;
                            }
                            break;
                        //Mission 4
                        case StateMission.Mission4:
                            if (chapter3Mission4)
                            {
                                stateMission = StateMission.Mission5;
                                currentMission.text = chapterData.Chapter3.Mission5;
                            }
                            break;
                        //Mission 5
                        case StateMission.Mission5:
                            if (chapter3Mission5)
                            {
                                stateMission = StateMission.Mission6;
                                currentMission.text = chapterData.Chapter3.Mission6;
                            }
                            break;
                        //Mission 6
                        case StateMission.Mission6:
                            if (chapter3Mission6)
                            {
                                stateMission = StateMission.Mission7;
                                currentMission.text = chapterData.Chapter3.Mission7;
                            }
                            break;
                        //Mission 7
                        case StateMission.Mission7:
                            if (chapter3Mission7)
                            {
                                stateMission = StateMission.Mission8;
                                currentMission.text = chapterData.Chapter3.Mission8;
                            }
                            break;
                        //Mission 8
                        case StateMission.Mission8:
                            if (chapter3Mission8)
                            {
                                stateMission = StateMission.Mission1;
                                currentMission.text = chapterData.Chapter4.Mission1;
                                stateStory = StateStory.Chapter4;
                                chapter3 = true;
                            }
                            break;
                    }
                    break;
                //Chappter 4
                case StateStory.Chapter4:
                    switch (stateMission)
                    {
                        //Mission 1
                        case StateMission.Mission1:
                            if (chapter4Mission1)
                            {
                                stateMission = StateMission.Mission2;
                                currentMission.text = chapterData.Chapter4.Mission2;
                            }
                            break;
                        //Mission 2
                        case StateMission.Mission2:
                            if (chapter4Mission2)
                            {
                                stateMission = StateMission.Mission3;
                                currentMission.text = chapterData.Chapter4.Mission3;
                            }
                            break;
                        //Mission 3
                        case StateMission.Mission3:
                            if (chapter4Mission3)
                            {
                                stateMission = StateMission.Mission4;
                                currentMission.text = chapterData.Chapter4.Mission4;
                            }
                            break;
                        //Mission 4
                        case StateMission.Mission4:
                            if (chapter4Mission4)
                            {
                                stateMission = StateMission.Mission5;
                                currentMission.text = chapterData.Chapter4.Mission5;
                            }
                            break;
                        //Mission 5
                        case StateMission.Mission5:
                            if (chapter4Mission5)
                            {
                                stateMission = StateMission.Mission6;
                                currentMission.text = chapterData.Chapter4.Mission6;
                            }
                            break;
                        //Mission 6
                        case StateMission.Mission6:
                            if (chapter4Mission6)
                            {
                                stateMission = StateMission.Mission7;
                                currentMission.text = chapterData.Chapter4.Mission7;
                            }
                            break;
                        //Mission 7
                        case StateMission.Mission7:
                            if (chapter4Mission7)
                            {
                                stateMission = StateMission.Mission8;
                                currentMission.text = chapterData.Chapter4.Mission8;
                            }
                            break;
                        //Mission 8
                        case StateMission.Mission8:
                            if (chapter4Mission8)
                            {
                                stateMission = StateMission.Mission1;
                                currentMission.text = chapterData.Chapter5.Mission1;
                                stateStory = StateStory.Chapter5;
                                chapter4 = true;
                            }
                            break;
                    }
                    break;
                //Chapter 5
                case StateStory.Chapter5:
                    switch (stateMission)
                    {
                        //Mission 1
                        case StateMission.Mission1:
                            if (chapter5Mission1)
                            {
                                stateMission = StateMission.Mission2;
                                currentMission.text = chapterData.Chapter5.Mission2;
                            }
                            break;
                        //Mission 2
                        case StateMission.Mission2:
                            if (chapter5Mission2)
                            {
                                stateMission = StateMission.Mission3;
                                currentMission.text = chapterData.Chapter5.Mission3;
                            }
                            break;
                        //Mission 3
                        case StateMission.Mission3:
                            if (chapter5Mission3)
                            {
                                stateMission = StateMission.Mission4;
                                currentMission.text = chapterData.Chapter5.Mission4;
                            }
                            break;
                        //Mission 5
                        case StateMission.Mission4:
                            if (chapter5Mission4)
                            {
                                stateStory = StateStory.Finished;
                                currentMission.text  = "Pengaturan";
                            }
                            break;
                    }
                    break;
            }
        }
        else
        {
            currentMission.SetText("Pengaturan");
        }
    }

    public void SetActiveMission(int chapter, int mission)
    {
        switch (chapter)
        {
            //New Game
            case 0:
                switch (mission)
                {
                    case 1:
                        newGame = true;
                        break;
                }
                break;

            //Chapter 1
            case 1:
                switch (mission)
                {
                    case 1:
                        chapter1Mission1 = true;
                        break;
                    case 2:
                        chapter1Mission2 = true;
                        break;
                    case 3:
                        chapter1Mission3 = true;
                        break;
                    case 4:
                        chapter1Mission4 = true;
                        break;
                    case 5:
                        chapter1Mission5 = true;
                        break;
                    case 6:
                        chapter1Mission6 = true;
                        break;
                    case 7:
                        chapter1Mission7 = true;
                        break;
                    case 8:
                        chapter1Mission8 = true;
                        chapter1 = true;
                        break;
                }
                break;
            //Chapter 2
            case 2:
                switch (mission)
                {
                    case 1:
                        chapter2Mission1 = true;
                        break;
                    case 2:
                        chapter2Mission2 = true;
                        break;
                    case 3:
                        chapter2Mission3 = true;
                        break;
                    case 4:
                        chapter2Mission4 = true;
                        break;
                    case 5:
                        chapter2Mission5 = true;
                        break;
                    case 6:
                        chapter2Mission6 = true;
                        break;
                    case 7:
                        chapter2Mission7 = true;
                        break;
                    case 8:
                        chapter2Mission8 = true;
                        chapter2 = true;
                        break;
                }
                break;
            //Chapter 3
            case 3:
                switch (mission)
                {
                    case 1:
                        chapter3Mission1 = true;
                        break;
                    case 2:
                        chapter3Mission2 = true;
                        break;
                    case 3:
                        chapter3Mission3 = true;
                        break;
                    case 4:
                        chapter3Mission4 = true;
                        break;
                    case 5:
                        chapter3Mission5 = true;
                        break;
                    case 6:
                        chapter3Mission6 = true;
                        break;
                    case 7:
                        chapter3Mission7 = true;
                        break;
                    case 8:
                        chapter3Mission8 = true;
                        chapter3 = true;
                        break;
                }
                break;

            case 4:
                switch (mission)
                {
                    case 1:
                        chapter4Mission1 = true;
                        break;
                    case 2:
                        chapter4Mission2 = true;
                        break;
                    case 3:
                        chapter4Mission3 = true;
                        break;
                    case 4:
                        chapter4Mission4 = true;
                        break;
                    case 5:
                        chapter4Mission5 = true;
                        break;
                    case 6:
                        chapter4Mission6 = true;
                        break;
                    case 7:
                        chapter4Mission7 = true;
                        break;
                    case 8:
                        chapter4Mission8 = true;
                        chapter4 = true;
                        break;
                }
                break;

            case 5:
                switch (mission)
                {
                    case 1:
                        chapter5Mission1 = true;
                        break;
                    case 2:
                        chapter5Mission2 = true;
                        break;
                    case 3:
                        chapter5Mission3 = true;
                        break;
                    case 4:
                        chapter5Mission4 = true;
                        break;
                }
                break;
        }
    }

    public void LoadData()
    {
        DataHandler.LoadGameProgress(ref newGame, ref chapter1Mission1, ref chapter1Mission2, ref chapter1Mission3, ref chapter1Mission4, ref chapter1Mission5, ref chapter1Mission6, ref chapter1Mission7, ref chapter1Mission8,
        ref chapter2Mission1, ref chapter2Mission2, ref chapter2Mission3, ref chapter2Mission4, ref chapter2Mission5, ref chapter2Mission6, ref chapter2Mission7, ref chapter2Mission8,
        ref chapter3Mission1, ref chapter3Mission2, ref chapter3Mission3, ref chapter3Mission4, ref chapter3Mission5, ref chapter3Mission6, ref chapter3Mission7, ref chapter3Mission8,
        ref chapter4Mission1, ref chapter4Mission2, ref chapter4Mission3, ref chapter4Mission4, ref chapter4Mission5, ref chapter4Mission6, ref chapter4Mission7, ref chapter4Mission8,
        ref chapter5Mission1, ref chapter5Mission2, ref chapter5Mission3, ref chapter5Mission4);
    }

    public void LoadAchievement()
    {
        DataHandler.LoadAchievement(ref chapter1, ref chapter2, ref chapter3, ref chapter4, ref chapter5);
    }
    public void SaveAchievementProgress()
    {
        DataHandler.SaveAchievementProgress(chapter1, chapter2, chapter3, chapter4, chapter5);
    }

    public void SaveGameProgress()
    {
        DataHandler.SaveGameProgress(SceneManager.GetActiveScene().name,
        newGame,
        chapter1Mission1,
        chapter1Mission2,
        chapter1Mission3,
        chapter1Mission4,
        chapter1Mission5,
        chapter1Mission6,
        chapter1Mission7,
        chapter1Mission8,

        chapter2Mission1,
        chapter2Mission2,
        chapter2Mission3,
        chapter2Mission4,
        chapter2Mission5,
        chapter2Mission5,
        chapter2Mission7,
        chapter2Mission8,

        chapter3Mission1,
        chapter3Mission2,
        chapter3Mission3,
        chapter3Mission4,
        chapter3Mission5,
        chapter3Mission6,
        chapter3Mission7,
        chapter3Mission8,

        chapter4Mission1,
        chapter4Mission2,
        chapter4Mission3,
        chapter4Mission4,
        chapter4Mission5,
        chapter4Mission5,
        chapter4Mission7,
        chapter4Mission8,

        chapter5Mission1,
        chapter5Mission2,
        chapter5Mission3,
        chapter5Mission4
        );
    }

    public void DeleteGameProgress()
    {
        newGame = false;
        chapter1Mission1 = false;
        chapter1Mission2 = false;
        chapter1Mission3 = false;
        chapter1Mission4 = false;
        chapter1Mission5 = false;
        chapter1Mission6 = false;
        chapter1Mission7 = false;
        chapter1Mission8 = false;

        chapter2Mission1 = false;
        chapter2Mission2 = false;
        chapter2Mission3 = false;
        chapter2Mission4 = false;
        chapter2Mission5 = false;
        chapter2Mission5 = false;
        chapter2Mission7 = false;
        chapter2Mission8 = false;

        chapter3Mission1 = false;
        chapter3Mission2 = false;
        chapter3Mission3 = false;
        chapter3Mission4 = false;
        chapter3Mission5 = false;
        chapter3Mission6 = false;
        chapter3Mission7 = false;
        chapter3Mission8 = false;

        chapter4Mission1 = false;
        chapter4Mission2 = false;
        chapter4Mission3 = false;
        chapter4Mission4 = false;
        chapter4Mission5 = false;
        chapter4Mission6 = false;
        chapter4Mission7 = false;
        chapter4Mission8 = false;

        chapter5Mission1 = false;
        chapter5Mission2 = false;
        chapter5Mission3 = false;
        chapter5Mission4 = false;

        PlayerPrefs.SetInt("isChallenger1", 0);
        PlayerPrefs.SetInt("isChallenger2", 0);
        PlayerPrefs.SetInt("isChallenger3", 0);
        PlayerPrefs.SetInt("isChallenger4", 0);
        PlayerPrefs.SetInt("isChallenger5", 0);
        PlayerPrefs.SetInt("isChallenger6", 0);
        PlayerPrefs.SetInt("isChallenger7", 0);
        PlayerPrefs.SetInt("isChallenger8", 0);
        PlayerPrefs.SetInt("isChallenger9", 0);
        PlayerPrefs.SetInt("isChallenger10", 0);
        PlayerPrefs.SetInt("isChallenger11", 0);
        PlayerPrefs.SetInt("isChallenger12", 0);
        PlayerPrefs.SetInt("isChallenger13", 0);
        PlayerPrefs.SetString("OnInsideLab", "False");
        PlayerPrefs.Save();
    }
}