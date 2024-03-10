using System;

[Serializable]
public class DataEnemy
{
    public EnemyStats Enemy1;
    public EnemyStats Enemy2;
    public EnemyStats Enemy3;
    public EnemyStats Enemy4;
    public EnemyStats Enemy5;
    public EnemyStats Enemy6;
    public EnemyStats Enemy7;
    public EnemyStats Enemy8;
    public EnemyStats Enemy9;
    public EnemyStats Enemy10;
    public EnemyStats Enemy11;
    public EnemyStats Enemy12;
    public EnemyStats Enemy13;
    public EnemyStats Enemy14;
}

[Serializable]
public class EnemyStats
{
    public string Id;
    public string Name;
    public string Element1;
    public string Element2;
    public int Hp;
    public int ElementalSkill1;
    public int ElementalSkill2;
}
