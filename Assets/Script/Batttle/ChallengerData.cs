using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChallengerData : MonoBehaviour
{
    [SerializeField] EnemyScriptableObject challengerSO; 
    [SerializeField] Image enemyImage;
    [SerializeField] Image elementImage;
    [SerializeField] TMP_Text elementAdvantageText;
    [SerializeField] List<Sprite> imageList;
    [SerializeField] List<Sprite> elementList;
    [SerializeField] List<String> elementTextList;

    private Dictionary<string, Sprite> challengerDataDictionary = new Dictionary<string, Sprite>();
    private Dictionary<string, Sprite> challengerElementDictionary = new Dictionary<string, Sprite>();
    private Dictionary<string, string> challengerElementTextDictionary = new Dictionary<string, string>();

    void Start ()
    {
        CheckChallenger();
        CheckElementChallenger();
        CheckElementTextChallenger();
    }

    public void CheckChallengerData()
    {
        if (challengerDataDictionary.TryGetValue(challengerSO.EnemyID, out Sprite enemySprite ) &&
        challengerElementDictionary.TryGetValue(challengerSO.EnemyID, out Sprite enemyElementSprite) &&
        challengerElementTextDictionary.TryGetValue(challengerSO.EnemyID, out string elementString))
        {
            enemyImage.sprite = enemySprite;
            elementImage.sprite = enemyElementSprite;
            elementAdvantageText.text = elementString;
        }
        else
        {
            Debug.LogWarning("Data Enemy tidak ditemukan");
        }

        PlayerPrefs.SetString("enemyId", challengerSO.EnemyID);
        PlayerPrefs.Save();
    }

    private void CheckElementChallenger()
    {
        challengerElementDictionary.Add("E1", elementList[4]);
        challengerElementDictionary.Add("E2", elementList[3]);
        challengerElementDictionary.Add("E3", elementList[0]);

        challengerElementDictionary.Add("E4", elementList[0]);
        challengerElementDictionary.Add("E5", elementList[5]);
        challengerElementDictionary.Add("E6", elementList[4]);
        
        challengerElementDictionary.Add("E7", elementList[1]);
        challengerElementDictionary.Add("E8", elementList[3]);
        challengerElementDictionary.Add("E9", elementList[1]);
        
        challengerElementDictionary.Add("E10", elementList[5]);
        challengerElementDictionary.Add("E11", elementList[2]);
        challengerElementDictionary.Add("E12", elementList[0]);
        
        challengerElementDictionary.Add("E13", elementList[0]);
        challengerElementDictionary.Add("E14", elementList[2]);
    }

    private void CheckChallenger()
    {
        challengerDataDictionary.Add("E1", imageList[0]);
        challengerDataDictionary.Add("E2", imageList[1]);
        challengerDataDictionary.Add("E3", imageList[2]);

        challengerDataDictionary.Add("E4", imageList[3]);
        challengerDataDictionary.Add("E5", imageList[4]);
        challengerDataDictionary.Add("E6", imageList[5]);
        
        challengerDataDictionary.Add("E7", imageList[6]);
        challengerDataDictionary.Add("E8", imageList[7]);
        challengerDataDictionary.Add("E9", imageList[8]);
        
        challengerDataDictionary.Add("E10", imageList[9]);
        challengerDataDictionary.Add("E11", imageList[10]);
        challengerDataDictionary.Add("E12", imageList[11]);
        
        challengerDataDictionary.Add("E13", imageList[12]);
        challengerDataDictionary.Add("E14", imageList[13]);
    }

    private void CheckElementTextChallenger()
    {
        challengerElementTextDictionary.Add("E1", elementTextList[4]);
        challengerElementTextDictionary.Add("E2", elementTextList[3]);
        challengerElementTextDictionary.Add("E3", elementTextList[0]);

        challengerElementTextDictionary.Add("E4", elementTextList[0]);
        challengerElementTextDictionary.Add("E5", elementTextList[5]);
        challengerElementTextDictionary.Add("E6", elementTextList[4]);
        
        challengerElementTextDictionary.Add("E7", elementTextList[1]);
        challengerElementTextDictionary.Add("E8", elementTextList[3]);
        challengerElementTextDictionary.Add("E9", elementTextList[1]);
        
        challengerElementTextDictionary.Add("E10", elementTextList[5]);
        challengerElementTextDictionary.Add("E11", elementTextList[2]);
        challengerElementTextDictionary.Add("E12", elementTextList[0]);
        
        challengerElementTextDictionary.Add("E13", elementTextList[0]);
        challengerElementTextDictionary.Add("E14", elementTextList[2]);
    }
}
