using System;

[Serializable]
public class MissionData
{
    public string ChapterTitle;
    public string Achievement;
    public string Mission1;
    public string Mission2;
    public string Mission3;
    public string Mission4;
    public string Mission5;
    public string Mission6;
    public string Mission7;
    public string Mission8;
    public string Mission9;
    public string Mission10;
}

[Serializable]
public class FinaleData
{
    public string ChapterTitle;
    public string Achievement;
    public string Mission1;
    public string Mission2;
    public string Mission3;
    public string Mission4;
}

[Serializable]
public class ChapterData
{
    public MissionData Chapter1;
    public MissionData Chapter2;
    public MissionData Chapter3;
    public MissionData Chapter4;
    public FinaleData Chapter5;
}