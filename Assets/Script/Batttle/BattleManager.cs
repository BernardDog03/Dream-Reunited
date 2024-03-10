using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField] Animator transitionLoadingWorld;
    [SerializeField] Flowchart flowchart;
    [SerializeField] State state;
    [SerializeField] PlayerManager playerChoose;
    [SerializeField] PlayerManager player1;
    [SerializeField] PlayerManager player2;
    [SerializeField] PlayerManager player3;
    [SerializeField] EnemyManager enemy;
    [SerializeField] Button buttonPrepare;

    [Space]
    [SerializeField] bool prepare;
    [SerializeField] bool isAttack;
    [SerializeField] bool isPlayerChoosen;

    enum State
    {
        Preparation,
        PC1Select,
        PC1AttackAnimation,
        PC1DamageAnimation,
        EnemySelect1,
        EnemyAttackAnimation1,
        EnemyDamageAnimation1,
        PC2Select,
        PC2AttackAnimation,
        PC2DamageAnimation,
        EnemySelect2,
        EnemyAttackAnimation2,
        EnemyDamageAnimation2,
        PC3Select,
        PC3AttackAnimation,
        PC3DamageAnimation,
        EnemySelect3,
        EnemyAttackAnimation3,
        EnemyDamageAnimation3,
        ReturnAnimation,
        BattleOver,
    }

    void Start()
    {
        player1.ActionCharacter.CharacterId = PlayerPrefs.GetString("dock1");
        player2.ActionCharacter.CharacterId = PlayerPrefs.GetString("dock2");
        player3.ActionCharacter.CharacterId = PlayerPrefs.GetString("dock3");
        enemy.ActionEnemy.EnemyId = PlayerPrefs.GetString("enemyId");

        player1.ActionCharacter.GetDataCharacter();
        player2.ActionCharacter.GetDataCharacter();
        player3.ActionCharacter.GetDataCharacter();
        enemy.ActionEnemy.GetDataEnemy();
    }

    void Update()
    {
        switch (state)
        {
            case State.Preparation:
                isAttack = false;
                if (!prepare)
                {
                    buttonPrepare.gameObject.SetActive(true);
                    Debug.Log(player1.ActionCharacter.ElementalPoint1);
                }
                else
                {
                    state = State.PC1Select;
                }
                break;
            //Player Character 1
            case State.PC1Select:
                if (player1.ActionCharacter.CurrentHp == 0)
                {
                    state = State.PC2Select;
                }
                else
                {
                    player1.AttackPosition();
                    flowchart.ExecuteBlock("Player 1");

                }
                break;
            case State.PC1AttackAnimation:
                player1.SetPlay(true);
                if (isAttack)
                {
                    state = State.PC1DamageAnimation;
                }
                break;
            case State.PC1DamageAnimation:
                player1.SetPlay(false);
                if (enemy.ActionEnemy.CurrentHp == 0)
                {
                    isAttack = false;
                    player1.ReturnPosition();
                    state = State.ReturnAnimation;
                }
                else
                {
                    isAttack = false;
                    player1.ReturnPosition();

                    WaitTime(1, State.EnemySelect1);
                }
                break;
            //Enemy
            case State.EnemySelect1:
                EnemySelectTarget();
                enemy.EnemyAttack();
                flowchart.ExecuteBlock("Enemy1");
                break;
            case State.EnemyAttackAnimation1:
                EnemyAttack();
                state = State.EnemyDamageAnimation1;
                break;
            case State.EnemyDamageAnimation1:
                EnemyWin();
                if (isAttack)
                    isAttack = false;
                isPlayerChoosen = false;
                WaitTime(1, State.PC2Select);
                break;
            //Player Character 2
            case State.PC2Select:
                if (player2.ActionCharacter.CurrentHp == 0)
                {
                    state = State.PC3Select;
                }
                else
                {
                    player2.AttackPosition();
                    flowchart.ExecuteBlock("Player 2");
                }
                break;
            case State.PC2AttackAnimation:
                player2.SetPlay(true);
                if (isAttack)
                {
                    state = State.PC2DamageAnimation;
                }
                break;
            case State.PC2DamageAnimation:
                player2.SetPlay(false);
                if (enemy.ActionEnemy.CurrentHp == 0)
                {
                    isAttack = false;
                    player2.ReturnPosition();
                    state = State.ReturnAnimation;
                }
                else
                {
                    isAttack = false;
                    player2.ReturnPosition();

                    WaitTime(1, State.EnemySelect2);
                }
                break;
            //Enemy
            case State.EnemySelect2:
                EnemySelectTarget();
                enemy.EnemyAttack();
                flowchart.ExecuteBlock("Enemy2");
                break;
            case State.EnemyAttackAnimation2:
                EnemyAttack();
                state = State.EnemyDamageAnimation2;
                break;
            case State.EnemyDamageAnimation2:
                EnemyWin();
                if (isAttack)
                    isAttack = false;
                isPlayerChoosen = false;
                WaitTime(1, State.PC3Select);
                break;
            //player Character 3
            case State.PC3Select:
                if (player3.ActionCharacter.CurrentHp == 0)
                {
                    state = State.ReturnAnimation;
                }
                else
                {
                    player3.AttackPosition();
                    flowchart.ExecuteBlock("Player 3");
                }
                break;
            case State.PC3AttackAnimation:
                player3.SetPlay(true);
                if (isAttack)
                {
                    state = State.PC3DamageAnimation;
                }
                break;
            case State.PC3DamageAnimation:
                player3.SetPlay(false);
                if (enemy.ActionEnemy.CurrentHp == 0)
                {
                    isAttack = false;
                    player3.ReturnPosition();
                    state = State.ReturnAnimation;
                }
                else
                {
                    isAttack = false;
                    player3.ReturnPosition();
                    state = State.EnemySelect3;
                }
                break;
            //Enemy
            case State.EnemySelect3:
                EnemySelectTarget();
                enemy.EnemyAttack();
                flowchart.ExecuteBlock("Enemy3");
                break;
            case State.EnemyAttackAnimation3:
                EnemyAttack();
                state = State.EnemyDamageAnimation3;
                break;
            case State.EnemyDamageAnimation3:
                EnemyWin();
                if (isAttack)
                    isAttack = false;
                isPlayerChoosen = false;
                WaitTime(1, State.ReturnAnimation);
                break;
            case State.ReturnAnimation:
                if (player1.ActionCharacter.CurrentHp == 0 && player2.ActionCharacter.CurrentHp == 0 && player3.ActionCharacter.CurrentHp == 0)
                {
                    flowchart.ExecuteBlock("Lose");
                    SaveBattleOverLose();
                    prepare = false;
                }
                else if (enemy.ActionEnemy.CurrentHp == 0)
                {
                    flowchart.ExecuteBlock("Win");
                    SaveBattleOverWin();
                    prepare = false;
                }
                else
                {
                    WaitTime(1, State.Preparation);
                }
                break;
            case State.BattleOver:
                LoadScene();
                break;
        }
    }

    public void BasicAttack(CharacterBattle activeCharacter)
    {
        enemy.ActionEnemy.PlayAnimationOnEnemy("Slash");
        enemy.ActionEnemy.CurrentHp -= activeCharacter.AttackPoint;
        isAttack = true;
        activeCharacter.SpPointCurrent += 1;
        activeCharacter.ChangeSp();
        enemy.EnemyTakeDamage();
    }

    public void SetPrepare()
    {
        prepare = true;
        buttonPrepare.gameObject.SetActive(false);
    }

    public void ElementalAttack(CharacterBattle activeCharacter)
    {
        string anemo = "Anemo";
        string pyro = "Pyro";
        string electro = "Electro";
        string cryo = "Cryo";
        string hydro = "Hydro";
        string geo = "Geo";

        string animation = activeCharacter.AnimationAtt;

        string element = activeCharacter.Element;
        int ep1 = activeCharacter.ElementalPoint1;
        int ep2 = activeCharacter.ElementalPoint2;

        int damage = ep1 / 10;
        int damageBufforNerf = ep1 / 7;
        int damageGeo = ep1 / 12;

        if (activeCharacter.Type == "DPS" || activeCharacter.Type == "Tank")
        {
            //Anemo
            if (element == anemo && enemy.ActionEnemy.Element1 == pyro)
            {
                int finalDamage = ep1 -= damageBufforNerf;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == anemo && enemy.ActionEnemy.Element1 == electro)
            {
                int finalDamage = ep1 += damage;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == anemo && enemy.ActionEnemy.Element1 == cryo)
            {
                int finalDamage = ep1 += damage;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == anemo && enemy.ActionEnemy.Element1 == hydro)
            {
                int finalDamage = ep1 += damageBufforNerf;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == anemo && enemy.ActionEnemy.Element1 == geo)
            {
                int finalDamage = ep1 += damage;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            //Pyro
            else if (element == pyro && enemy.ActionEnemy.Element1 == anemo)
            {
                int finalDamage = ep1 += damageBufforNerf;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == pyro && enemy.ActionEnemy.Element1 == electro)
            {
                int finalDamage = ep1 += damage;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == pyro && enemy.ActionEnemy.Element1 == cryo)
            {
                int finalDamage = ep1 += damageBufforNerf;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == pyro && enemy.ActionEnemy.Element1 == hydro)
            {
                int finalDamage = ep1 -= damageBufforNerf;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == pyro && enemy.ActionEnemy.Element1 == geo)
            {
                int finalDamage = ep1 += damage;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            //electro
            else if (element == electro && enemy.ActionEnemy.Element1 == anemo)
            {
                int finalDamage = ep1 += damage;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == electro && enemy.ActionEnemy.Element1 == pyro)
            {
                int finalDamage = ep1 += damage;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == electro && enemy.ActionEnemy.Element1 == cryo)
            {
                int finalDamage = ep1 -= damageBufforNerf;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == electro && enemy.ActionEnemy.Element1 == hydro)
            {
                int finalDamage = ep1 += damageBufforNerf;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == electro && enemy.ActionEnemy.Element1 == geo)
            {
                int finalDamage = ep1 += damageBufforNerf;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            //cryo
            else if (element == cryo && enemy.ActionEnemy.Element1 == anemo)
            {
                int finalDamage = ep1 += damage;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == cryo && enemy.ActionEnemy.Element1 == pyro)
            {
                int finalDamage = ep1 -= damageBufforNerf;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == cryo && enemy.ActionEnemy.Element1 == electro)
            {
                int finalDamage = ep1 += damageBufforNerf;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == cryo && enemy.ActionEnemy.Element1 == hydro)
            {
                int finalDamage = ep1 += damage;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == cryo && enemy.ActionEnemy.Element1 == geo)
            {
                int finalDamage = ep1 += damage;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            //Hydro
            else if (element == hydro && enemy.ActionEnemy.Element1 == anemo)
            {
                int finalDamage = ep1 -= damageBufforNerf;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == hydro && enemy.ActionEnemy.Element1 == pyro)
            {
                int finalDamage = ep1 += damageBufforNerf;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == hydro && enemy.ActionEnemy.Element1 == electro)
            {
                int finalDamage = ep1 -= damageBufforNerf;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == hydro && enemy.ActionEnemy.Element1 == cryo)
            {
                int finalDamage = ep1 += damage;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else if (element == hydro && enemy.ActionEnemy.Element1 == geo)
            {
                int finalDamage = ep1 += damage;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            //Geo
            else if (element == geo && (enemy.ActionEnemy.Element1 == anemo || enemy.ActionEnemy.Element1 == pyro || enemy.ActionEnemy.Element1 == electro ||
            enemy.ActionEnemy.Element1 == cryo || enemy.ActionEnemy.Element1 == hydro))
            {
                int finalDamage = ep1 += damageGeo;
                enemy.ActionEnemy.CurrentHp -= finalDamage;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            else
            {
                enemy.ActionEnemy.CurrentHp -= ep1;

                activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
                activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            }
            activeCharacter.ChangeSp();


            enemy.ActionEnemy.PlayAnimationOnEnemy(animation);
            enemy.EnemyTakeDamage();
        }
        else if (activeCharacter.Type == "Support")
        {
            if (activeCharacter == player1.ActionCharacter)
            {
                PlayerChangeStats(player2, ep1, ep2);
                PlayerChangeStats(player3, ep1, ep2);
            }
            else if (activeCharacter == player2.ActionCharacter)
            {
                PlayerChangeStats(player1, ep1, ep2);
                PlayerChangeStats(player3, ep1, ep2);
            }
            else if (activeCharacter == player3.ActionCharacter)
            {
                PlayerChangeStats(player1, ep1, ep2);
                PlayerChangeStats(player2, ep1, ep2);
            }

            activeCharacter.SpPointCurrent -= activeCharacter.ElementSp;
            activeCharacter.SpPointCurrent = Mathf.Clamp(activeCharacter.SpPointCurrent, 0, 10);
            activeCharacter.ChangeSp();

            activeCharacter.PlayAnimationOnPlayer(animation);
        }
        isAttack = true;
        player1.SetPlay(false);
        player2.SetPlay(false);
        player3.SetPlay(false);
    }

    private void PlayerChangeStats(PlayerManager player, int value1, int value2)
    {
        player.ActionCharacter.CurrentHp += value1;
        player.ActionCharacter.SpPointCurrent += value2;
        player.ActionCharacter.ChangeSp();
        player.ActionCharacter.ChangeHp();
    }

    private void EnemySelectTarget()
    {

        if (isPlayerChoosen)
        {
            return;
        }
        List<PlayerManager> playerTarget = new List<PlayerManager>();

        if (player1.ActionCharacter.CurrentHp > 0)
        {
            playerTarget.Add(player1);
        }
        if (player2.ActionCharacter.CurrentHp > 0)
        {
            playerTarget.Add(player2);
        }
        if (player3.ActionCharacter.CurrentHp > 0)
        {
            playerTarget.Add(player3);
        }

        if (playerTarget.Count > 0)
        {
            int randomIndex = Random.Range(0, playerTarget.Count);
            playerChoose = playerTarget[randomIndex];

            isPlayerChoosen = true;
        }
    }

    private void EnemyAttack()
    {
        if (enemy.ChooseAttack == "Ep1")
        {
            playerChoose.ActionCharacter.CurrentHp -= enemy.ActionEnemy.AttackPoint1;
            string enemyAnimationAttack = enemy.ActionEnemy.AnimationAtt1;
            playerChoose.ActionCharacter.PlayAnimationOnPlayer(enemyAnimationAttack);
        }
        else if (enemy.ChooseAttack == "Ep2")
        {
            playerChoose.ActionCharacter.CurrentHp -= enemy.ActionEnemy.AttackPoint2;
            string enemyAnimationAttack = enemy.ActionEnemy.AnimationAtt2;
            playerChoose.ActionCharacter.PlayAnimationOnPlayer(enemyAnimationAttack);
        }

        playerChoose.CharacterTakeDamage();

        isAttack = true;
    }
    private void EnemyWin()
    {
        
        if (playerChoose.ActionCharacter.CurrentHp == 0)
            playerChoose.RemoveDeathPlayer();
    }

    private void WaitTime(float time, State nextState)
    {
        StartCoroutine(DelayTime(time, nextState));
    }
    IEnumerator DelayTime(float time, State nextState)
    {
        yield return new WaitForSeconds(time);
        state = nextState;
    }

    public void SetStateActivePlayer1()
    {
        state = State.PC1AttackAnimation;
    }
    public void SetStateActivePlayer2()
    {
        state = State.PC2AttackAnimation;
    }
    public void SetStateActivePlayer3()
    {
        state = State.PC3AttackAnimation;
    }
    public void SetStateActiveEnemy1()
    {
        state = State.EnemyAttackAnimation1;
    }
    public void SetStateActiveEnemy2()
    {
        state = State.EnemyAttackAnimation2;
    }
    public void SetStateActiveEnemy3()
    {
        state = State.EnemyAttackAnimation3;
    }
    public void SetStateBattleOver()
    {
        state = State.BattleOver;
    }

    private void LoadScene()
    {
        StartCoroutine(LoadSceneAnimation());
    }
    IEnumerator LoadSceneAnimation()
    {
        string mapLocation = PlayerPrefs.GetString("mapLocationBattle");
        transitionLoadingWorld.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(mapLocation);
    }

    private void SaveBattleOverLose()
    {
        if (enemy.ActionEnemy.EnemyId == "E1")
        {
            PlayerPrefs.SetInt("isChallenger1", 0);
        }
        else if (enemy.ActionEnemy.EnemyId == "E2")
        {
            PlayerPrefs.SetInt("isChallenger2", 0);
        }
        else if (enemy.ActionEnemy.EnemyId == "E3")
        {
            PlayerPrefs.SetInt("isChallenger3", 0);
        }
        else if (enemy.ActionEnemy.EnemyId == "E4")
        {
            PlayerPrefs.SetInt("isChallenger4", 0);
        }
        else if (enemy.ActionEnemy.EnemyId == "E5")
        {
            PlayerPrefs.SetInt("isChallenger5", 0);
        }
        else if (enemy.ActionEnemy.EnemyId == "E6")
        {
            PlayerPrefs.SetInt("isChallenger6", 0);
        }
        else if (enemy.ActionEnemy.EnemyId == "E7")
        {
            PlayerPrefs.SetInt("isChallenger7", 0);
        }
        else if (enemy.ActionEnemy.EnemyId == "E8")
        {
            PlayerPrefs.SetInt("isChallenger8", 0);
        }
        else if (enemy.ActionEnemy.EnemyId == "E9")
        {
            PlayerPrefs.SetInt("isChallenger9", 0);
        }
        else if (enemy.ActionEnemy.EnemyId == "E10")
        {
            PlayerPrefs.SetInt("isChallenger10", 0);
        }
        else if (enemy.ActionEnemy.EnemyId == "E11")
        {
            PlayerPrefs.SetInt("isChallenger11", 0);
        }
        else if (enemy.ActionEnemy.EnemyId == "E12")
        {
            PlayerPrefs.SetInt("isChallenger12", 0);
        }
        else if (enemy.ActionEnemy.EnemyId == "E13")
        {
            PlayerPrefs.SetInt("isChallenger13", 0);
        }
        else if (enemy.ActionEnemy.EnemyId == "E14")
        {
            PlayerPrefs.SetInt("isChallenger14", 0);
        }

        string locString = JsonUtility.ToJson(new Vector3(x: 0, y: 0, z: 0));

        PlayerPrefs.SetString("lastPositionBattle", locString);
        PlayerPrefs.Save();
    }
    private void SaveBattleOverWin()
    {
        if (enemy.ActionEnemy.EnemyId == "E1")
        {
            PlayerPrefs.SetInt("isChallenger1", 1);
        }
        else if (enemy.ActionEnemy.EnemyId == "E2")
        {
            PlayerPrefs.SetInt("isChallenger2", 1);
        }
        else if (enemy.ActionEnemy.EnemyId == "E3")
        {
            PlayerPrefs.SetInt("isChallenger3", 1);
        }
        else if (enemy.ActionEnemy.EnemyId == "E4")
        {
            PlayerPrefs.SetInt("isChallenger4", 1);
        }
        else if (enemy.ActionEnemy.EnemyId == "E5")
        {
            PlayerPrefs.SetInt("isChallenger5", 1);
        }
        else if (enemy.ActionEnemy.EnemyId == "E6")
        {
            PlayerPrefs.SetInt("isChallenger6", 1);
        }
        else if (enemy.ActionEnemy.EnemyId == "E7")
        {
            PlayerPrefs.SetInt("isChallenger7", 1);
        }
        else if (enemy.ActionEnemy.EnemyId == "E8")
        {
            PlayerPrefs.SetInt("isChallenger8", 1);
        }
        else if (enemy.ActionEnemy.EnemyId == "E9")
        {
            PlayerPrefs.SetInt("isChallenger9", 1);
        }
        else if (enemy.ActionEnemy.EnemyId == "E10")
        {
            PlayerPrefs.SetInt("isChallenger10", 1);
        }
        else if (enemy.ActionEnemy.EnemyId == "E11")
        {
            PlayerPrefs.SetInt("isChallenger11", 1);
        }
        else if (enemy.ActionEnemy.EnemyId == "E12")
        {
            PlayerPrefs.SetInt("isChallenger12", 1);
        }
        else if (enemy.ActionEnemy.EnemyId == "E13")
        {
            PlayerPrefs.SetInt("isChallenger13", 1);
        }
        else if (enemy.ActionEnemy.EnemyId == "E14")
        {
            PlayerPrefs.SetInt("isChallenger14", 1);
        }
        PlayerPrefs.Save();
    }
}