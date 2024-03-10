using System.Collections;
using TMPro;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField] TextAsset missionDataJson;

    [Header("Achievement")]
    [SerializeField] TMP_Text AchievementText;

    public void ActivePopUp(int achieve)
    {
        ChapterData chapterData = JsonUtility.FromJson<ChapterData>(missionDataJson.text);
        switch (achieve)
        {
            case 1:
                AchievementText.text = chapterData.Chapter1.ChapterTitle;
                break;
            case 2:
                AchievementText.text = chapterData.Chapter2.ChapterTitle;
                break;
            case 3:
                AchievementText.text = chapterData.Chapter3.ChapterTitle;
                break;
            case 4:
                AchievementText.text = chapterData.Chapter4.ChapterTitle;
                break;
            case 5 :
                AchievementText.text = chapterData.Chapter5.ChapterTitle;
                break;
        }
    }
}
