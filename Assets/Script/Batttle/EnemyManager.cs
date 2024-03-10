using DG.Tweening;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyBattle actionEnemy;
    [SerializeField] string chooseAttack;

    public EnemyBattle ActionEnemy { get => actionEnemy; }
    public string ChooseAttack { get => chooseAttack; }
    
    public void EnemyTakeDamage()
    {
        actionEnemy.ChangeHp();
        var spriteRend = actionEnemy.GetComponent<SpriteRenderer>();

        if (actionEnemy.CurrentHp == 0)
        {
            spriteRend.color = Color.red;
        }
        else
        {
            spriteRend.DOColor(Color.red, 0.1f).SetLoops(2, LoopType.Yoyo);
        }
    }

    public void EnemyAttack()
    {
        int randomIndex = Random.Range(1, 3);
        if (randomIndex == 1)
        {
            chooseAttack = "Ep1";
        }
        else if (randomIndex == 2)
        {
            chooseAttack = "Ep2";
        }
    }
}