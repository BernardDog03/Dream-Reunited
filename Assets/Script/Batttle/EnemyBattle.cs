using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBattle : MonoBehaviour
{
    [SerializeField] TextAsset dataEnemyJson;
    [Space]
    [SerializeField] string enemyId;
    [SerializeField] int currentHp;
    [SerializeField] int maxHp;
    [SerializeField] int attackPoint1;
    [SerializeField] int attackPoint2;
    [SerializeField] string element1;
    [SerializeField] string element2;
    [SerializeField] string animationAtt1;
    [SerializeField] string animationAtt2;
    [Space]
    [SerializeField] TMP_Text enemyNameText;
    [SerializeField] TMP_Text enemyHpText;
    [SerializeField] TMP_Text attPointText1;
    [SerializeField] TMP_Text attPointText2;
    [Space]
    [SerializeField] Button button;
    [SerializeField] Image healthBar;
    [Space]
    [SerializeField] List<Sprite> avatarList;
    [SerializeField] Image avatar;
    [SerializeField] Animator animatorCharacter;
    [SerializeField] Animator animatorAtt;

    public String Element1 { get => element1; }
    public string Element2 { get => element2; }
    public string EnemyId { get => enemyId; set => enemyId = value; }
    public int CurrentHp { get => currentHp; set => currentHp = value; }
    public int AttackPoint1 { get => attackPoint1; }
    public int AttackPoint2 { get => attackPoint2; }
    public string AnimationAtt1 { get => animationAtt1; }
    public string AnimationAtt2 { get => animationAtt2; }

    public void GetDataEnemy()
    {
        DataEnemy dataEnemy = JsonUtility.FromJson<DataEnemy>(dataEnemyJson.text);
        if (EnemyId == "E1")
        {
            enemyNameText.text = dataEnemy.Enemy1.Name;

            maxHp = dataEnemy.Enemy1.Hp;
            currentHp = dataEnemy.Enemy1.Hp;
            enemyHpText.text = currentHp.ToString().Trim();

            element1 = dataEnemy.Enemy1.Element1;
            element2 = dataEnemy.Enemy1.Element2;

            animationAtt1 = "Wind";
            animationAtt2 = "Hydro";

            attackPoint1 = dataEnemy.Enemy1.ElementalSkill1;
            attackPoint2 = dataEnemy.Enemy1.ElementalSkill2;

            attPointText1.text = attackPoint1.ToString().Trim();
            attPointText2.text = attackPoint2.ToString().Trim();

            avatar.sprite = avatarList[0];
            animatorCharacter.SetTrigger("E1");
        }
        else if (EnemyId == "E2")
        {
            enemyNameText.text = dataEnemy.Enemy2.Name;

            maxHp = dataEnemy.Enemy2.Hp;
            currentHp = dataEnemy.Enemy2.Hp;
            enemyHpText.text = currentHp.ToString().Trim();
            
            element1 = dataEnemy.Enemy2.Element1;
            element2 = dataEnemy.Enemy2.Element2;

            animationAtt1 = "Smoke";
            animationAtt2 = "L4";

            attackPoint1 = dataEnemy.Enemy2.ElementalSkill1;
            attackPoint2 = dataEnemy.Enemy2.ElementalSkill2;

            attPointText1.text = attackPoint1.ToString().Trim();
            attPointText2.text = attackPoint2.ToString().Trim();

            avatar.sprite = avatarList[1];
            animatorCharacter.SetTrigger("E2");
        }
        else if (EnemyId == "E3")
        {
            enemyNameText.text = dataEnemy.Enemy3.Name;

            maxHp = dataEnemy.Enemy3.Hp;
            currentHp = dataEnemy.Enemy3.Hp;
            enemyHpText.text = currentHp.ToString().Trim();

            element1 = dataEnemy.Enemy3.Element1;
            element2 = dataEnemy.Enemy3.Element2;

            animationAtt1 = "F2";
            animationAtt2 = "Wind";

            attackPoint1 = dataEnemy.Enemy3.ElementalSkill1;
            attackPoint2 = dataEnemy.Enemy3.ElementalSkill2;

            attPointText1.text = attackPoint1.ToString().Trim();
            attPointText2.text = attackPoint2.ToString().Trim();

            avatar.sprite = avatarList[2];
            animatorCharacter.SetTrigger("E3");
        }
        else if (EnemyId == "E4")
        {
            enemyNameText.text = dataEnemy.Enemy4.Name;

            maxHp = dataEnemy.Enemy4.Hp;
            currentHp = dataEnemy.Enemy4.Hp;
            enemyHpText.text = currentHp.ToString().Trim();

            element1 = dataEnemy.Enemy4.Element1;
            element2 = dataEnemy.Enemy4.Element2;

            animationAtt1 = "F1";
            animationAtt2 = "Smoke";

            attackPoint1 = dataEnemy.Enemy4.ElementalSkill1;
            attackPoint2 = dataEnemy.Enemy4.ElementalSkill2;

            attPointText1.text = attackPoint1.ToString().Trim();
            attPointText2.text = attackPoint2.ToString().Trim();

            avatar.sprite = avatarList[3];
            animatorCharacter.SetTrigger("E4");
        }
        else if (EnemyId == "E5")
        {
            enemyNameText.text = dataEnemy.Enemy5.Name;

            maxHp = dataEnemy.Enemy5.Hp;
            currentHp = dataEnemy.Enemy5.Hp;
            enemyHpText.text = currentHp.ToString().Trim();

            element1 = dataEnemy.Enemy5.Element1;
            element2 = dataEnemy.Enemy5.Element2;

            animationAtt1 = "Ice";
            animationAtt2 = "L3";

            attackPoint1 = dataEnemy.Enemy5.ElementalSkill1;
            attackPoint2 = dataEnemy.Enemy5.ElementalSkill2;

            attPointText1.text = attackPoint1.ToString().Trim();
            attPointText2.text = attackPoint2.ToString().Trim();

            avatar.sprite = avatarList[4];
            animatorCharacter.SetTrigger("E5");
        }
        else if (EnemyId == "E6")
        {
            enemyNameText.text = dataEnemy.Enemy6.Name;

            maxHp = dataEnemy.Enemy6.Hp;
            currentHp = dataEnemy.Enemy6.Hp;
            enemyHpText.text = currentHp.ToString().Trim();

            element1 = dataEnemy.Enemy6.Element1;
            element2 = dataEnemy.Enemy6.Element2;

            animationAtt1 = "Wind";
            animationAtt2 = "Ice";

            attackPoint1 = dataEnemy.Enemy6.ElementalSkill1;
            attackPoint2 = dataEnemy.Enemy6.ElementalSkill2;

            attPointText1.text = attackPoint1.ToString().Trim();
            attPointText2.text = attackPoint2.ToString().Trim();

            avatar.sprite = avatarList[5];
            animatorCharacter.SetTrigger("E6");
        }
        else if (EnemyId == "E7")
        {
            enemyNameText.text = dataEnemy.Enemy7.Name;

            maxHp = dataEnemy.Enemy7.Hp;
            currentHp = dataEnemy.Enemy7.Hp;
            enemyHpText.text = currentHp.ToString().Trim();

            element1 = dataEnemy.Enemy7.Element1;
            element2 = dataEnemy.Enemy7.Element2;

            animationAtt1 = "Hydro";
            animationAtt2 = "L5";

            attackPoint1 = dataEnemy.Enemy7.ElementalSkill1;
            attackPoint2 = dataEnemy.Enemy7.ElementalSkill2;

            attPointText1.text = attackPoint1.ToString().Trim();
            attPointText2.text = attackPoint2.ToString().Trim();

            avatar.sprite = avatarList[6];
            animatorCharacter.SetTrigger("E7");
        }
        else if (EnemyId == "E8")
        {
            enemyNameText.text = dataEnemy.Enemy8.Name;

            maxHp = dataEnemy.Enemy8.Hp;
            currentHp = dataEnemy.Enemy8.Hp;
            enemyHpText.text = currentHp.ToString().Trim();

            element1 = dataEnemy.Enemy8.Element1;
            element2 = dataEnemy.Enemy8.Element2;

            animationAtt1 = "Smoke";
            animationAtt2 = "F2";

            attackPoint1 = dataEnemy.Enemy8.ElementalSkill1;
            attackPoint2 = dataEnemy.Enemy8.ElementalSkill2;

            attPointText1.text = attackPoint1.ToString().Trim();
            attPointText2.text = attackPoint2.ToString().Trim();

            avatar.sprite = avatarList[7];
            animatorCharacter.SetTrigger("E8");
        }
        else if (EnemyId == "E9")
        {
            enemyNameText.text = dataEnemy.Enemy9.Name;

            maxHp = dataEnemy.Enemy9.Hp;
            currentHp = dataEnemy.Enemy9.Hp;
            enemyHpText.text = currentHp.ToString().Trim();

            element1 = dataEnemy.Enemy9.Element1;
            element2 = dataEnemy.Enemy9.Element2;

            animationAtt1 = "Hydro";
            animationAtt2 = "Wind";

            attackPoint1 = dataEnemy.Enemy9.ElementalSkill1;
            attackPoint2 = dataEnemy.Enemy9.ElementalSkill2;

            attPointText1.text = attackPoint1.ToString().Trim();
            attPointText2.text = attackPoint2.ToString().Trim();

            avatar.sprite = avatarList[8];
            animatorCharacter.SetTrigger("E9");
        }
        else if (EnemyId == "E10")
        {
            enemyNameText.text = dataEnemy.Enemy10.Name;

            maxHp = dataEnemy.Enemy10.Hp;
            currentHp = dataEnemy.Enemy10.Hp;
            enemyHpText.text = currentHp.ToString().Trim();

            element1 = dataEnemy.Enemy10.Element1;
            element2 = dataEnemy.Enemy10.Element2;

            animationAtt1 = "Ice";
            animationAtt2 = "Hydro";

            attackPoint1 = dataEnemy.Enemy10.ElementalSkill1;
            attackPoint2 = dataEnemy.Enemy10.ElementalSkill2;

            attPointText1.text = attackPoint1.ToString().Trim();
            attPointText2.text = attackPoint2.ToString().Trim();

            avatar.sprite = avatarList[9];
            animatorCharacter.SetTrigger("E10");
        }
        else if (EnemyId == "E11")
        {
            enemyNameText.text = dataEnemy.Enemy11.Name;
            
            maxHp = dataEnemy.Enemy11.Hp;
            currentHp = dataEnemy.Enemy11.Hp;
            enemyHpText.text = currentHp.ToString().Trim();

            element1 = dataEnemy.Enemy11.Element1;
            element2 = dataEnemy.Enemy11.Element2;

            animationAtt1 = "L3";
            animationAtt2 = "Smoke";

            attackPoint1 = dataEnemy.Enemy11.ElementalSkill1;
            attackPoint2 = dataEnemy.Enemy11.ElementalSkill2;

            attPointText1.text = attackPoint1.ToString().Trim();
            attPointText2.text = attackPoint2.ToString().Trim();

            avatar.sprite = avatarList[10];
            animatorCharacter.SetTrigger("E11");
        }
        else if (EnemyId == "E12")
        {
            enemyNameText.text = dataEnemy.Enemy12.Name;

            maxHp = dataEnemy.Enemy12.Hp;
            currentHp = dataEnemy.Enemy12.Hp;
            enemyHpText.text = currentHp.ToString().Trim();

            element1 = dataEnemy.Enemy12.Element1;
            element2 = dataEnemy.Enemy12.Element2;

            animationAtt1 = "F3";
            animationAtt2 = "L4";

            attackPoint1 = dataEnemy.Enemy12.ElementalSkill1;
            attackPoint2 = dataEnemy.Enemy12.ElementalSkill2;

            attPointText1.text = attackPoint1.ToString().Trim();
            attPointText2.text = attackPoint2.ToString().Trim();

            avatar.sprite = avatarList[11];
            animatorCharacter.SetTrigger("E12");
        }
        else if (EnemyId == "E13")
        {
            enemyNameText.text = dataEnemy.Enemy13.Name;

            maxHp = dataEnemy.Enemy13.Hp;
            currentHp = dataEnemy.Enemy13.Hp;
            enemyHpText.text = currentHp.ToString().Trim();

            element1 = dataEnemy.Enemy13.Element1;
            element2 = dataEnemy.Enemy13.Element2;

            animationAtt1 = "F3";
            animationAtt2 = "Smoke";

            attackPoint1 = dataEnemy.Enemy13.ElementalSkill1;
            attackPoint2 = dataEnemy.Enemy13.ElementalSkill2;

            attPointText1.text = attackPoint1.ToString().Trim();
            attPointText2.text = attackPoint2.ToString().Trim();

            avatar.sprite = avatarList[12];
            animatorCharacter.SetTrigger("E13");
        }
        else if (EnemyId == "E14")
        {
            enemyNameText.text = dataEnemy.Enemy14.Name;

            maxHp = dataEnemy.Enemy14.Hp;
            currentHp = dataEnemy.Enemy14.Hp;
            enemyHpText.text = currentHp.ToString().Trim();

            element1 = dataEnemy.Enemy14.Element1;
            element2 = dataEnemy.Enemy14.Element2;

            animationAtt1 = "L5";
            animationAtt2 = "Smoke";

            attackPoint1 = dataEnemy.Enemy14.ElementalSkill1;
            attackPoint2 = dataEnemy.Enemy14.ElementalSkill2;

            attPointText1.text = attackPoint1.ToString().Trim();
            attPointText2.text = attackPoint2.ToString().Trim();

            avatar.sprite = avatarList[13];
            animatorCharacter.SetTrigger("E14");
        }
    }
    
    public void ChangeHp()
    {
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        enemyHpText.text = currentHp.ToString().Trim();
        UpdateHp();
    }

    private void UpdateHp()
    {
        healthBar.fillAmount = (float) currentHp / (float) maxHp;
        if (currentHp <= (maxHp / 2))
        {
            healthBar.color = Color.yellow;
        }
        else if (currentHp <= 200)
        {
            healthBar.color = Color.red;
        }
        else
        {
            healthBar.color = Color.green;
        }
    }

    public void PlayAnimationOnEnemy(string triggerName)
    {
        animatorAtt.SetTrigger(triggerName);
    }
}
