using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeTownManager : MonoBehaviour
{
    public GameObject mainCharacter;
    public GameObject spawn;
    [SerializeField] SceneEndPointLocation sceneHome;
    [SerializeField] SceneTwoSide sceneRWC;
    public Animator transition;
    public float transitionTime = 1f;
    [SerializeField] StoryManager storyManager;

    void Start()
    {
        storyManager = StoryManager.GetInstance();
        storyManager.LoadData();
        GetLastLocation();
    }

    //Load Scene using Coroutine Animation
    public void OnGoToCity()
    {
        LoadScene("River Wood City");
    }

    //Save Last Location
    public void SaveLastLocationHRWC()
    {
        GameHandler.SaveLocation("posHRWC", "Hometown", "isRWCH", 
        "isRWCHHC",true, false, 
        sceneRWC.firstSceneTwoSide, sceneRWC.secondSceneTwoSide,
        sceneHome.posEndPointLocation, mainCharacter.transform.position);
    }

    //Get Last Location Data
    private void GetLastLocation()
    {
    GameHandler.GetLastPosition("posHRWC", mainCharacter.transform, spawn);
    }

    //Coroutine Load Scene Animation
    private void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAnimation(sceneName));
    }
    IEnumerator LoadSceneAnimation(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}