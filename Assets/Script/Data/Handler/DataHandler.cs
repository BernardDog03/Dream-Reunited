using UnityEngine;
using System.IO;
using System;
using System.Collections;
using Unity.VisualScripting;

public class DataHandler : MonoBehaviour
{
    public static void SaveGameProgress(string scenename, bool newGame,
    bool c1m1, bool c1m2, bool c1m3, bool c1m4, bool c1m5, bool c1m6, bool c1m7, bool c1m8,
    bool c2m1, bool c2m2, bool c2m3, bool c2m4, bool c2m5, bool c2m6, bool c2m7, bool c2m8,
    bool c3m1, bool c3m2, bool c3m3, bool c3m4, bool c3m5, bool c3m6, bool c3m7, bool c3m8,
    bool c4m1, bool c4m2, bool c4m3, bool c4m4, bool c4m5, bool c4m6, bool c4m7, bool c4m8,
    bool c5m1, bool c5m2, bool c5m3, bool c5m4)
    {
        GameData gameData = new GameData();

        gameData.LastScene = scenename;
        gameData.IsNewGame = newGame;

        gameData.Chapter1 = new MissionStatus(); gameData.Chapter1.Mission1 = c1m1;
        gameData.Chapter1.Mission2 = c1m2;
        gameData.Chapter1.Mission3 = c1m3;
        gameData.Chapter1.Mission4 = c1m4;
        gameData.Chapter1.Mission5 = c1m5;
        gameData.Chapter1.Mission6 = c1m6;
        gameData.Chapter1.Mission7 = c1m7;
        gameData.Chapter1.Mission8 = c1m8;

        gameData.Chapter2 = new MissionStatus();
        gameData.Chapter2.Mission1 = c2m1;
        gameData.Chapter2.Mission2 = c2m2;
        gameData.Chapter2.Mission3 = c2m3;
        gameData.Chapter2.Mission4 = c2m4;
        gameData.Chapter2.Mission5 = c2m5;
        gameData.Chapter2.Mission6 = c2m6;
        gameData.Chapter2.Mission7 = c2m7;
        gameData.Chapter2.Mission8 = c2m8;

        gameData.Chapter3 = new MissionStatus();
        gameData.Chapter3.Mission1 = c3m1;
        gameData.Chapter3.Mission2 = c3m2;
        gameData.Chapter3.Mission3 = c3m3;
        gameData.Chapter3.Mission4 = c3m4;
        gameData.Chapter3.Mission5 = c3m5;
        gameData.Chapter3.Mission6 = c3m6;
        gameData.Chapter3.Mission7 = c3m7;
        gameData.Chapter3.Mission8 = c3m8;

        gameData.Chapter4 = new MissionStatus();
        gameData.Chapter4.Mission1 = c4m1;
        gameData.Chapter4.Mission2 = c4m2;
        gameData.Chapter4.Mission3 = c4m3;
        gameData.Chapter4.Mission4 = c4m4;
        gameData.Chapter4.Mission5 = c4m5;
        gameData.Chapter4.Mission6 = c4m6;
        gameData.Chapter4.Mission7 = c4m7;
        gameData.Chapter4.Mission8 = c4m8;

        gameData.Chapter5 = new FinaleStatus();
        gameData.Chapter5.Finale1 = c5m1;
        gameData.Chapter5.Finale2 = c5m2;
        gameData.Chapter5.Finale3 = c5m3;
        gameData.Chapter5.Finale4 = c5m4;

        try
        {
            string path = Path.Combine(Application.persistentDataPath, "GameData.json");
            string jsonData = JsonUtility.ToJson(gameData, true);
            File.WriteAllText(path, jsonData);
            Debug.Log("Game data successfully saved! at: " +path);
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving game data: " + e.Message);
            Debug.LogError("StackTrace: " + e.StackTrace);
        }
    }

    public static void SaveAchievementProgress(bool Achieve1, bool Achieve2, bool Achieve3, 
    bool Achieve4, bool Achieve5)
    {
        AchievementData achievementData = new AchievementData();

        achievementData.Achievement = new AchievementStatus();
        achievementData.Achievement.Achievement1 = Achieve1;
        achievementData.Achievement.Achievement2 = Achieve2;
        achievementData.Achievement.Achievement3 = Achieve3;
        achievementData.Achievement.Achievement4 = Achieve4;
        achievementData.Achievement.Achievement5 = Achieve5;

        try
        {
            string path = Path.Combine(Application.persistentDataPath, "Achievement.json");
            string jsonData = JsonUtility.ToJson(achievementData, true);
            File.WriteAllText(path, jsonData);
            Debug.Log("Achievement successfully saved! at " + path);
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving achievement data: " + e.Message);
            Debug.LogError("Stacktrace: " + e.StackTrace);
        }
    }
    public static void LoadAchievement(ref bool c1, ref bool c2, ref bool c3, ref bool c4, ref bool c5)
    {
        try
        {
            string path = Path.Combine(Application.persistentDataPath, "Achievement.json");
            if (File.Exists(path))
            {
                string jsonData = File.ReadAllText(path);
                AchievementData achievementData = JsonUtility.FromJson<AchievementData>(jsonData);
                if (achievementData != null)
                {
                    AchievementStatus achieve = achievementData.Achievement;
                    c1 = achieve.Achievement1;
                    c2 = achieve.Achievement2;
                    c3 = achieve.Achievement3;
                    c4 = achieve.Achievement4;
                    c5 = achieve.Achievement5;
                }
            }
            else 
            {
                Debug.LogError("json not found at: "+path);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error loading game data :" + e.Message);
            Debug.LogError("Stacktrace: " + e.StackTrace);
        }
    }

    public static void LoadGameProgress(ref bool newGame, 
    ref bool c1m1, ref bool c1m2, ref bool c1m3, ref bool c1m4, ref bool c1m5, ref bool c1m6, ref bool c1m7, ref bool c1m8,
    ref bool c2m1, ref bool c2m2, ref bool c2m3, ref bool c2m4, ref bool c2m5, ref bool c2m6, ref bool c2m7, ref bool c2m8,
    ref bool c3m1, ref bool c3m2, ref bool c3m3, ref bool c3m4, ref bool c3m5, ref bool c3m6, ref bool c3m7, ref bool c3m8,
    ref bool c4m1, ref bool c4m2, ref bool c4m3, ref bool c4m4, ref bool c4m5, ref bool c4m6, ref bool c4m7, ref bool c4m8,
    ref bool c5m1, ref bool c5m2, ref bool c5m3, ref bool c5m4)
    {
        try
        {
            string path = Path.Combine(Application.persistentDataPath, "GameData.json");
            if (File.Exists(path))
            {
                string jsonData = File.ReadAllText(path);
                GameData gameData = JsonUtility.FromJson<GameData>(jsonData);
                if (gameData != null)
                {
                    newGame = gameData.IsNewGame;
                    MissionStatus c1 = gameData.Chapter1;
                    c1m1 = c1.Mission1;
                    c1m2 = c1.Mission2;
                    c1m3 = c1.Mission3;
                    c1m4 = c1.Mission4;
                    c1m5 = c1.Mission5;
                    c1m6 = c1.Mission6;
                    c1m7 = c1.Mission7;
                    c1m8 = c1.Mission8;

                    MissionStatus c2 = gameData.Chapter2;
                    c2m1 = c2.Mission1;
                    c2m2 = c2.Mission2;
                    c2m3 = c2.Mission3;
                    c2m4 = c2.Mission4;
                    c2m5 = c2.Mission5;
                    c2m6 = c2.Mission6;
                    c2m7 = c2.Mission7;
                    c2m8 = c2.Mission8;

                    MissionStatus c3 = gameData.Chapter3;
                    c3m1 = c3.Mission1;
                    c3m2 = c3.Mission2;
                    c3m3 = c3.Mission3;
                    c3m4 = c3.Mission4;
                    c3m5 = c3.Mission5;
                    c3m6 = c3.Mission6;
                    c3m7 = c3.Mission7;
                    c3m8 = c3.Mission8;

                    MissionStatus c4 = gameData.Chapter4;
                    c4m1 = c4.Mission1;
                    c4m2 = c4.Mission2;
                    c4m3 = c4.Mission3;
                    c4m4 = c4.Mission4;
                    c4m5 = c4.Mission5;
                    c4m6 = c4.Mission6;
                    c4m7 = c4.Mission7;
                    c4m8 = c4.Mission8;

                    FinaleStatus c5 = gameData.Chapter5;
                    c5m1 = c5.Finale1;
                    c5m2 = c5.Finale2;
                    c5m3 = c5.Finale3;
                    c5m4 = c5.Finale4;
                }
                Debug.Log("LoadSuccess");
            }
            else
            {
                Debug.LogWarning("GameData.json not found at :" + path);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error loading game data :" + e.Message);
            Debug.LogError("Stacktrace: " + e.StackTrace);
        }
    }
}