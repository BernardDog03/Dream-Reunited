using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{   
    [SerializeField] TMP_Text sceneName;
    [SerializeField] GameObject panelSetting;
    [SerializeField] MainCharacterManager mainCharacterManager;

    [Header("Animation")]
    [SerializeField] Animator transition;
    [SerializeField] float transisitionTime = 1f;
    [SerializeField] GameObject popUpSave;
    [SerializeField] GameObject panelMap;
    [SerializeField] Image HGR;
    [SerializeField] Image HG;
    [SerializeField] Image HH;
    [SerializeField] Image RWC;
    [SerializeField] Image HomeTown;
    [SerializeField] GameObject map;
    [SerializeField] GameObject mapError;

    void Start()
    {
        GetActiveSceneName();
    }

    private void GetActiveSceneName()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        sceneName.SetText(currentScene);

        if (currentScene == "Apartemen" || currentScene == "Hills Glade Residence")
        {
            HGR.color = Color.red;
        }
        else if (currentScene == "Hills Glade")
        {
            HG.color = Color.red;
        }
        else if (currentScene == "Harmony Hills City")
        {
            HH.color = Color.red;
        }
        else if (currentScene == "River Wood City" || currentScene == "Laboratorium")
        {
            RWC.color = Color.red;
        }
        else if (currentScene == "Hometown")
        {
            HomeTown.color = Color.red;
        }
        else
        {
            map.SetActive(false);
            mapError.SetActive(true);
        }
    }

    public void ActiveSetting()
    {
        if (panelSetting != null)
        {
            if (!panelSetting.activeSelf)
            {
                panelSetting.SetActive(true);
                panelMap.SetActive(false);
                mainCharacterManager.SetCantMove();
            }
            else
            {
                panelSetting.SetActive(false);
                panelMap.SetActive(false);
                mainCharacterManager.SetCanMove();
            }
        }
    }

    public void ActiveMap()
    {
        if (panelMap != null)
        {
            if (!panelMap.activeSelf)
            {
                panelSetting.SetActive(false);
                panelMap.SetActive(true);
                mainCharacterManager.SetCantMove();
            }
            else
            {
                panelSetting.SetActive(false);
                panelMap.SetActive(false);
                mainCharacterManager.SetCanMove();
            }
        }
    }

    public void GoToMainMenu()
    {
        LoadScene("MainMenu");
    }
    private void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAnimation(sceneName));
    }
    IEnumerator LoadSceneAnimation(string sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transisitionTime);
        SceneManager.LoadScene(sceneName);
    }

    public void PlayPopUpSave()
    {
        panelSetting.SetActive(false);
        mainCharacterManager.SetCanMove();
        PlayPopUp(popUpSave);
    }
    private void PlayPopUp(GameObject gameObject)
    {
        StartCoroutine(PopUp(gameObject));
    }
    IEnumerator PopUp(GameObject gameObject)
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        gameObject.SetActive(false);
    }
}
