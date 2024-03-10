using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    [SerializeField] TextAsset missionDataJson;
    [SerializeField] TMP_Text ChapterTitlle;
    [SerializeField] TMP_Text ChapterDetail;
    [SerializeField] Button buttonC1;
    [SerializeField] Button buttonC2;
    [SerializeField] Button buttonC3;
    [SerializeField] Button buttonC4;
    [SerializeField] Button buttonC5;
    private StoryManager storyManager;

    private delegate void chapter1Complete();
    private static event chapter1Complete OnChater1Complete;
    private delegate void chapter2Complete();
    private static event chapter2Complete OnChater2Complete;
    private delegate void chapter3Complete();
    private static event chapter3Complete OnChater3Complete;
    private delegate void chapter4Complete();
    private static event chapter4Complete OnChater4Complete;
    private delegate void chapter5Complete();
    private static event chapter1Complete OnChater5Complete;

    void Start()
    {
        storyManager = StoryManager.GetInstance();
        storyManager.LoadAchievement();
        OnChater1Complete += HandleC1Complete;
        OnChater2Complete += HandleC2Complete;
        OnChater3Complete += HandleC3Complete;
        OnChater4Complete += HandleC4Complete;
        OnChater5Complete += HandleC5Complete;
    }
    void Update()
    {
        if (storyManager.chapter1)
        {
            OnChater1Complete.Invoke();
        }
        if (storyManager.chapter2)
        {
            OnChater2Complete.Invoke();
        }
        if (storyManager.chapter3)
        {
            OnChater3Complete.Invoke();
        }
        if (storyManager.chapter4)
        {
            OnChater4Complete.Invoke();
        }
        if (storyManager.chapter5)
        {
            OnChater5Complete.Invoke();
        }
    }

    private void HandleC1Complete()
    {
        if (storyManager.chapter1)
        {
            buttonC1.gameObject.SetActive(true);
        }
    }
    private void HandleC2Complete()
    {
        if (storyManager.chapter2)
        {
            buttonC2.gameObject.SetActive(true);
        }
    }
    private void HandleC3Complete()
    {
        if (storyManager.chapter3)
        {
            buttonC3.gameObject.SetActive(true);
        }
    }
    private void HandleC4Complete()
    {
        if (storyManager.chapter4)
        {
            buttonC4.gameObject.SetActive(true);
        }
    }
    private void HandleC5Complete()
    {
        if (storyManager.chapter5)
        {
            buttonC5.gameObject.SetActive(true);
        }
    }

    public void Chapter1Complete()
    {
        ChapterData chapterData = JsonUtility.FromJson<ChapterData>(missionDataJson.text);
        ChapterTitlle.text = chapterData.Chapter1.ChapterTitle;
        ChapterDetail.text = chapterData.Chapter1.Achievement;
    }

    public void Chapter2Complete()
    {
        ChapterData chapterData = JsonUtility.FromJson<ChapterData>(missionDataJson.text);
        ChapterTitlle.text = chapterData.Chapter2.ChapterTitle;
        ChapterDetail.text = chapterData.Chapter2.Achievement;
    }

    public void Chapter3Complete()
    {
        ChapterData chapterData = JsonUtility.FromJson<ChapterData>(missionDataJson.text);
        ChapterTitlle.text = chapterData.Chapter3.ChapterTitle;
        ChapterDetail.text = chapterData.Chapter3.Achievement;
    }

    public void Chapter4Compplete()
    {
        ChapterData chapterData = JsonUtility.FromJson<ChapterData>(missionDataJson.text);
        ChapterTitlle.text = chapterData.Chapter4.ChapterTitle;
        ChapterDetail.text = chapterData.Chapter4.Achievement;
    }

    public void Chapter5Complete()
    {
        ChapterData chapterData = JsonUtility.FromJson<ChapterData>(missionDataJson.text);
        ChapterTitlle.text = chapterData.Chapter5.ChapterTitle;
        ChapterDetail.text = chapterData.Chapter5.Achievement;
    }
}
