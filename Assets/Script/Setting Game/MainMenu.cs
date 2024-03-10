using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime = 1f;
    [SerializeField] Button buttonContinue;

    private StoryManager storyManager;
    private delegate void newGameChanged();
    private static event newGameChanged OnNewGameChanged;
    [SerializeField] Sprite[] images;
    [SerializeField] Image backgroundImage;
    void Start()
    {
        OnNewGameChanged += HandleNewGameChanged;
        storyManager = StoryManager.GetInstance();
        storyManager.LoadData();
        RandomImage();
    }

    void Update()
    {
        if (!storyManager.newGame)
        {
            OnNewGameChanged.Invoke();
        }
    }

    //Event Handler
    private void HandleNewGameChanged()
    {
        if (!storyManager.newGame)
        {
            buttonContinue.gameObject.SetActive(false);
        }
    }
    public void StartGame()
    {
        LoadScene("Apartemen");
    }
    public void Quit()
    {
        Application.Quit();
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

    public void Continue()
    {
        string path = Path.Combine(Application.persistentDataPath, "GameData.json");
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            GameData gameData = JsonUtility.FromJson<GameData>(jsonData);
            if (!string.IsNullOrEmpty(gameData.LastScene))
            {
                string sceneName = gameData.LastScene;
                if ((storyManager.chapter4Mission2 && !storyManager.chapter4Mission3) ||
                (storyManager.chapter4Mission3 && !storyManager.chapter4Mission4) ||
                (storyManager.chapter4Mission4 && !storyManager.chapter4Mission5) ||
                (storyManager.chapter4Mission5 && !storyManager.chapter4Mission6))
                {
                    StartCoroutine(LoadSceneAnimation("Prison"));
                }
                else
                {
                    StartCoroutine(LoadSceneAnimation(sceneName));
                }
            }
            else
            {
                Debug.Log("No Data");
            }
        }
    }

    private void RandomImage()
    {
        Sprite randomImages = images[Random.Range(0, images.Length)];
        backgroundImage.sprite = randomImages;
    }
}
