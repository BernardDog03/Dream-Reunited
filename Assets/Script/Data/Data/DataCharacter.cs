using System;

[Serializable]
public class DataCharacter
{
    public CharacterStatsAtt C1;
    public CharacterStatsAtt C2;
    public CharacterStatsAtt C3;
    public CharacterStatsAtt C4;
    public CharacterStatsSupport C5;
    public CharacterStatsSupport C6;
    public CharacterStatsSupport C7;
    public CharacterStatsSupport C8;
}

[Serializable]
public class CharacterStatsAtt
{
    public string Id;
    public string Type;
    public string Name;
    public string Element;
    public int HP;
    public int BasicAtt;
    public int ElementalSkill;
    public int ElementalSp;
    public int SpMax;
    public int SpStart;
}

[Serializable]
public class CharacterStatsSupport
{
    public string Id;
    public string Type;
    public string Name;
    public string Element;
    public int HP;
    public int BasicAtt;
    public int ElementalSkill1;
    public int ElementalSkill2;
    public int ElementalSp;
    public int SpMax;
    public int SpStart;
}