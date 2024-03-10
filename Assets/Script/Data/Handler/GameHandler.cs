using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    //Save Last Location /for 2 Location in 1 Scene
    public static void SaveLocation(string positionKey, string sceneName, 
    string firstSceneKey, string seconSceneKey,
    bool firstSceneBool, bool secondSceneBool, bool sceneFirstTwoSide,
    bool sceneSecondTwoSide, Vector2 posSceneTwoSide, Vector2 position)
    {
        posSceneTwoSide = position;
        string currentScene = SceneManager.GetActiveScene().name;
        string playerPosString = JsonUtility.ToJson(posSceneTwoSide);

        if (currentScene == sceneName)
        {
            sceneFirstTwoSide = firstSceneBool;
            sceneSecondTwoSide = secondSceneBool;
        } 

        string sceneFirstTwoSideString = sceneFirstTwoSide.ToString().Trim();
        string sceneSecondTwoSideString = sceneSecondTwoSide.ToString().Trim();

        PlayerPrefs.SetString(positionKey, playerPosString);
        PlayerPrefs.SetString(firstSceneKey, sceneFirstTwoSideString);
        PlayerPrefs.SetString(seconSceneKey, sceneSecondTwoSideString);
        PlayerPrefs.Save();
    }

    //Save Last Location only 1 Location in 1 Scene
    public static void SaveEndPointLocation(String positionKey, Vector2 posEndPoint, 
    Vector2 position)
    {
        posEndPoint = position;
        string playerPosString = JsonUtility.ToJson(posEndPoint);

        PlayerPrefs.SetString(positionKey, playerPosString);
        PlayerPrefs.Save();
    }

    //Get Last Location for 2 Location in 1 Scene
    public static void GetLastLocation(string isGetSceneA, string isGetSceneB,
    string getPosSceneA, string getPosSceneB, Transform characterTransform, GameObject spawn)
    {
        bool isSceneA = GetBoolPlayerPref(isGetSceneA);
        bool isSceneB = GetBoolPlayerPref(isGetSceneB);

        if(isSceneA)
        {
            GetLastPosition(getPosSceneA, characterTransform, spawn);
        }
        else if(isSceneB)
        {
            GetLastPosition(getPosSceneB, characterTransform, spawn);
        }
    }

    //Get Last Location only 1 Location in 1 Scene
    public static void GetLastPosition(string positionKey, Transform characterTransform, GameObject spawn)
    {
        string playerPosString = PlayerPrefs.GetString(positionKey);
        
        if(string.IsNullOrEmpty(playerPosString) && !PlayerPrefs.HasKey(positionKey))
        {
            characterTransform.position = spawn.transform.position;
        }
        else{
            Vector2 playerPos = JsonUtility.FromJson<Vector2>(playerPosString);
            characterTransform.position = playerPos;
        }
    }

    //Get BoolPlayerPref data, parse to String
    private static bool GetBoolPlayerPref(string key)
    {
        string isGetString = PlayerPrefs.GetString(key).Trim();
        bool result;

        if (bool.TryParse(isGetString, out result))
            return result;
        else
        {
            Debug.LogError("Error parsing PlayerPref value to Boolean");
            return false;
        }
    }
}
