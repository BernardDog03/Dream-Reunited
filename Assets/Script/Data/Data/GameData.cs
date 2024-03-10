using System;

[Serializable]
public class GameData
{
    public string LastScene;
    public bool IsNewGame;
    public MissionStatus Chapter1;
    public MissionStatus Chapter2;
    public MissionStatus Chapter3;
    public MissionStatus Chapter4;
    public FinaleStatus Chapter5;
}

[Serializable]
public class AchievementData
{
    public AchievementStatus Achievement;
}
[Serializable]
public class AchievementStatus
{
    public bool Achievement1;
    public bool Achievement2;
    public bool Achievement3;
    public bool Achievement4;
    public bool Achievement5;
}

[Serializable]
public class MissionStatus
{
    public bool Mission1;
    public bool Mission2;
    public bool Mission3;
    public bool Mission4;
    public bool Mission5;
    public bool Mission6;
    public bool Mission7;
    public bool Mission8;
}
[Serializable]
public class FinaleStatus

{
    public bool Finale1;
    public bool Finale2;
    public bool Finale3;
    public bool Finale4;
    public bool Finale5;
}