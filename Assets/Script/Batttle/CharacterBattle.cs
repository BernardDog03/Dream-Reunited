using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBattle : MonoBehaviour
{
    [SerializeField] TextAsset dataCharacterJson;
    [SerializeField] string characterId;
    [SerializeField] string element;
    [SerializeField] string type;
    [SerializeField] string animationAtt;

    [Space]
    [SerializeField] int currentHp;
    [SerializeField] int maxHp;
    [SerializeField] int attackPoint;
    [SerializeField] int elementPoint1;
    [SerializeField] int elementPoint2;
    [SerializeField] int elementSp;
    [SerializeField] int spPointCurrent;
    [SerializeField] int spPointMax;
    [SerializeField] Image healthBar;
    [Space]
    [SerializeField] TMP_Text characterHpText;
    [SerializeField] TMP_Text characterNameText;
    [SerializeField] TMP_Text attPointText;
    [SerializeField] TMP_Text spPointText;
    [Space]
    [SerializeField] Button basicAttButton;
    [SerializeField] Button elementalSkillButton;
    [Space]
    [SerializeField] List<Sprite> avatarList;
    [SerializeField] List<Sprite> buttonList;
    [SerializeField] Image avatar;
    [SerializeField] Animator animatorCharacter;
    [SerializeField] Animator animatorAtt;

    public Button BasicAttButton { get => basicAttButton; }
    public Button ElementalSkillButton { get => elementalSkillButton; }
    public string CharacterId { get => characterId; set => characterId = value; }
    public string Element { get => element; }
    public string Type { get => type; }
    public string AnimationAtt { get => animationAtt; }
    public int ElementalPoint1 { get => elementPoint1; set => elementPoint1 = value; }
    public int ElementalPoint2 { get => elementPoint2; }
    public int SpPointCurrent { get => spPointCurrent; set => spPointCurrent = value; }
    public int ElementSp { get => elementSp; set => elementSp = value; }
    public int CurrentHp { get => currentHp; set => currentHp = value; }
    public int AttackPoint { get => attackPoint; set => attackPoint = value; }

    public void GetDataCharacter()
    {
        DataCharacter dataCharacter = JsonUtility.FromJson<DataCharacter>(dataCharacterJson.text);
        if (characterId == "C1")
        {
            AttackPoint = dataCharacter.C1.BasicAtt;
            elementPoint1 = dataCharacter.C1.ElementalSkill;
            elementPoint2 = 0;

            elementSp = dataCharacter.C1.ElementalSp;
            SpPointCurrent = dataCharacter.C1.SpStart;
            element = dataCharacter.C1.Element;
            type = dataCharacter.C1.Type;

            maxHp = dataCharacter.C1.HP;
            currentHp = dataCharacter.C1.HP;
            characterHpText.text = currentHp.ToString().Trim();

            characterNameText.text = dataCharacter.C1.Name;
            attPointText.text = elementPoint1.ToString().Trim();
            spPointText.text = SpPointCurrent.ToString().Trim();

            avatar.sprite = avatarList[0];
            animatorCharacter.SetTrigger("C1");
            animationAtt = "Wind";
            elementalSkillButton.image.sprite = buttonList[4];

        }
        else if (characterId == "C2")
        {
            AttackPoint = dataCharacter.C2.BasicAtt;
            elementPoint1 = dataCharacter.C2.ElementalSkill;
            elementPoint2 = 0;
            
            SpPointCurrent = dataCharacter.C2.SpStart;
            elementSp = dataCharacter.C1.ElementalSp;
            element = dataCharacter.C2.Element;
            type = dataCharacter.C2.Type;

            maxHp = dataCharacter.C2.HP;
            currentHp = dataCharacter.C2.HP;
            characterHpText.text = currentHp.ToString().Trim();

            characterNameText.text = dataCharacter.C2.Name;
            attPointText.text = elementPoint1.ToString().Trim();
            spPointText.text = SpPointCurrent.ToString().Trim();

            avatar.sprite = avatarList[1];
            animatorCharacter.SetTrigger("C2");
            animationAtt = "Hydro";
            elementalSkillButton.image.sprite = buttonList[1];
        }
        else if (characterId == "C3")
        {
            AttackPoint = dataCharacter.C3.BasicAtt;
            elementPoint1 = dataCharacter.C3.ElementalSkill;
            elementPoint2 = 0;
            
            SpPointCurrent = dataCharacter.C3.SpStart;
            element = dataCharacter.C3.Element;
            elementSp = dataCharacter.C1.ElementalSp;
            type = dataCharacter.C3.Type;
            
            maxHp = dataCharacter.C3.HP;
            currentHp = dataCharacter.C3.HP;
            characterHpText.text = currentHp.ToString().Trim();

            characterNameText.text = dataCharacter.C3.Name;
            attPointText.text = elementPoint1.ToString().Trim();
            spPointText.text = SpPointCurrent.ToString().Trim();

            avatar.sprite = avatarList[2];
            animatorCharacter.SetTrigger("C3");
            animationAtt = "Ice";
            elementalSkillButton.image.sprite = buttonList[5];
        }
        else if (characterId == "C4")
        {
            AttackPoint = dataCharacter.C4.BasicAtt;
            elementPoint1 = dataCharacter.C4.ElementalSkill;
            elementPoint2 = 0;

            SpPointCurrent = dataCharacter.C4.SpStart;
            element = dataCharacter.C4.Element;
            elementSp = dataCharacter.C1.ElementalSp;
            type = dataCharacter.C4.Type;
            
            maxHp = dataCharacter.C4.HP;
            currentHp = dataCharacter.C4.HP;
            characterHpText.text = currentHp.ToString().Trim();

            characterNameText.text = dataCharacter.C4.Name;
            attPointText.text = elementPoint1.ToString().Trim();
            spPointText.text = SpPointCurrent.ToString().Trim();

            avatar.sprite = avatarList[3];
            animatorCharacter.SetTrigger("C4");
            animationAtt = "F3";
            elementalSkillButton.image.sprite = buttonList[0];
        }
        else if (characterId == "C5")
        {
            AttackPoint = dataCharacter.C5.BasicAtt;
            elementPoint1 = dataCharacter.C5.ElementalSkill1;
            elementPoint2 = dataCharacter.C5.ElementalSkill2;

            SpPointCurrent = dataCharacter.C5.SpStart;
            elementSp = dataCharacter.C1.ElementalSp;
            element = dataCharacter.C5.Element;
            type = dataCharacter.C5.Type;
            
            maxHp = dataCharacter.C5.HP;
            currentHp = dataCharacter.C5.HP;
            characterHpText.text = currentHp.ToString().Trim();

            characterNameText.text = dataCharacter.C6.Name;
            attPointText.text = AttackPoint.ToString().Trim();
            spPointText.text = SpPointCurrent.ToString().Trim();

            avatar.sprite = avatarList[4];
            animatorCharacter.SetTrigger("C5");
            animationAtt = "Smoke";
            elementalSkillButton.image.sprite = buttonList[3];
        }
        else if (characterId == "C6")
        {
            AttackPoint = dataCharacter.C6.BasicAtt;
            elementPoint1 = dataCharacter.C6.ElementalSkill1;
            elementPoint2 = dataCharacter.C6.ElementalSkill2;
            
            SpPointCurrent = dataCharacter.C6.SpStart;
            elementSp = dataCharacter.C1.ElementalSp;
            element = dataCharacter.C6.Element;
            type = dataCharacter.C6.Type;
            
            maxHp = dataCharacter.C6.HP;
            currentHp = dataCharacter.C6.HP;
            characterHpText.text = currentHp.ToString().Trim();

            characterNameText.text = dataCharacter.C6.Name;
            attPointText.text = AttackPoint.ToString().Trim();
            spPointText.text = SpPointCurrent.ToString().Trim();

            avatar.sprite = avatarList[5];
            animatorCharacter.SetTrigger("C6");
            animationAtt = "L5";
            elementalSkillButton.image.sprite = buttonList[2];
        }
        else if (characterId == "C7")
        {
            AttackPoint = dataCharacter.C7.BasicAtt;
            elementPoint1 = dataCharacter.C7.ElementalSkill1;
            elementPoint2 = dataCharacter.C7.ElementalSkill2;
            SpPointCurrent = dataCharacter.C7.SpStart;

            element = dataCharacter.C7.Element;
            elementSp = dataCharacter.C1.ElementalSp;
            type = dataCharacter.C7.Type;
            
            maxHp = dataCharacter.C7.HP;
            currentHp = dataCharacter.C7.HP;
            characterHpText.text = currentHp.ToString().Trim();

            characterNameText.text = dataCharacter.C7.Name;
            attPointText.text = AttackPoint.ToString().Trim();
            spPointText.text = SpPointCurrent.ToString().Trim();

            avatar.sprite = avatarList[6];
            animatorCharacter.SetTrigger("C7");
            animationAtt = "L1";
            elementalSkillButton.image.sprite = buttonList[6];
        }
        else if (characterId == "C8")
        {
            AttackPoint = dataCharacter.C8.BasicAtt;
            elementPoint1 = dataCharacter.C8.ElementalSkill1;
            elementPoint2 = dataCharacter.C8.ElementalSkill2;

            SpPointCurrent = dataCharacter.C8.SpStart;
            elementSp = dataCharacter.C1.ElementalSp;
            element = dataCharacter.C8.Element;
            type = dataCharacter.C8.Type;
            
            maxHp = dataCharacter.C8.HP;
            currentHp = dataCharacter.C8.HP;
            characterHpText.text = currentHp.ToString().Trim();

            characterNameText.text = dataCharacter.C8.Name;
            attPointText.text = AttackPoint.ToString().Trim();
            spPointText.text = SpPointCurrent.ToString().Trim();

            avatar.sprite = avatarList[7];
            animatorCharacter.SetTrigger("C8");
            animationAtt = "L1";
            elementalSkillButton.image.sprite = buttonList[6];
        }
    }
    public void ChangeHp()
    {
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        characterHpText.text = currentHp.ToString().Trim();
        UpdateHp();
    }

    public void ChangeSp()
    {
        spPointText.text = SpPointCurrent.ToString().Trim();
    }

    public void ChangeAtt()
    {
        attPointText.text = elementPoint1.ToString().Trim();
    }

    private void UpdateHp()
    {
        healthBar.fillAmount = (float) currentHp/ (float)maxHp;
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

    public void PlayAnimationOnPlayer(string triggerName)
    {
        animatorAtt.SetTrigger(triggerName);
    }
}