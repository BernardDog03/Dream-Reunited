using System.Collections;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RachelLabManager : MonoBehaviour
{
    [SerializeField] Flowchart flowchart;
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime = 1f;
    private StoryManager storyManager;

    void Start()
    {
        storyManager = StoryManager.GetInstance();
        storyManager.LoadData();
        if (storyManager.chapter4Mission6 && !storyManager.chapter4Mission7)
        {
            flowchart.ExecuteBlock("Start");
        }
    }

    public void OnGoToLaboratorium()
    {
        LoadScene("Laboratorium");
    }

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
