using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] CharacterBattle actionCharacter;
    [SerializeField] List<CharacterBattle> actionCharacterList;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject returnPos;
    [SerializeField] GameObject characterObject;

    public CharacterBattle ActionCharacter { get => actionCharacter; }
    void Start()
    {
        actionCharacter.BasicAttButton.gameObject.SetActive(false);
        actionCharacter.ElementalSkillButton.gameObject.SetActive(false);

        actionCharacter.BasicAttButton.interactable = false;
        actionCharacter.ElementalSkillButton.interactable = false;
    }
    
    public void SetPlay(bool value)
    {
        actionCharacter.BasicAttButton.gameObject.SetActive(value);
        actionCharacter.ElementalSkillButton.gameObject.SetActive(value);

        actionCharacter.BasicAttButton.interactable = true;
        if (actionCharacter.SpPointCurrent < actionCharacter.ElementSp)
        {
            actionCharacter.ElementalSkillButton.interactable = false;
        }
        else
        {
            actionCharacter.ElementalSkillButton.interactable = true;
        }
    }

    public void AttackPosition()
    {
        actionCharacter.transform.DOMove(new Vector2(-3, -0.5f), 0.35f).SetEase(Ease.Linear);
    }

    public void ReturnPosition()
    {
        actionCharacter.transform.DOMove(returnPos.transform.position, 0.35f).SetEase(Ease.Linear);
    }

    public void RemoveDeathPlayer()
    {
        characterObject.SetActive(false);
        SetPlay(false);
    }

    public void CharacterTakeDamage()
    {
        actionCharacter.ChangeHp();
        var spriteRend = characterObject.GetComponent<SpriteRenderer>();
        
        spriteRend.DOColor(Color.red, 0.3f).SetLoops(2, LoopType.Yoyo);
    }
}
