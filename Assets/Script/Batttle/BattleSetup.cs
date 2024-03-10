using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BattleSetup : MonoBehaviour
{
    [SerializeField] GameObject mainCharacter;
    [SerializeField] Button continueButton;
    [SerializeField] Animator animator;
    [SerializeField] GameObject battleSetup;
    private List<string> characterIDs = new List<string>()
    {
        "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8"
    };
    [SerializeField] List<string> selectedCharacters = new List<string>();
    [SerializeField] List<Button> addCharacterButtons;
    [SerializeField] List<Button> removeCharacterButtons;
    [SerializeField] List<Sprite> listImage;
    [SerializeField] List<Image> characterImages;
    [SerializeField] Dictionary<string, Sprite> characterSpriteMap = new Dictionary<string, Sprite>();

    void Start()
    {
        for (int i = 0; i < characterIDs.Count && i < listImage.Count; i++)
        {
            characterSpriteMap.Add(characterIDs[i], listImage[i]);
        }

        foreach (Button addButton in addCharacterButtons)
        {
            addButton.onClick.AddListener(() => AddCharacter(addButton.name));
        }

        foreach (Button removeButton in removeCharacterButtons)
        {
            removeButton.onClick.AddListener(() => RemoveCharacter(removeButton.name));
        }
    }

    private void UpdateButtonsInteractable()
    {
        foreach (Button addbutton in addCharacterButtons)
        {
            string characterID = addbutton.name;
            addbutton.interactable = !selectedCharacters.Contains(characterID) && selectedCharacters.Count < 3;
        }

        foreach (Button removeButton in removeCharacterButtons)
        {
            string characterID = removeButton.name;
            removeButton.interactable = selectedCharacters.Contains(characterID);
        }

        continueButton.interactable = selectedCharacters.Count == 3;
    }

    public void AddCharacter(string characterID)
    {
        if (!selectedCharacters.Contains(characterID) && selectedCharacters.Count < 3)
        {
            selectedCharacters.Add(characterID);
            UpdateCharacterImage();
            Debug.Log("Character " + characterID + " ditambahkan kedalam daftar");
        }
        else
        {
            Debug.Log("Character " + characterID + " Tidak dapat ditambahkan");
        }

        UpdateButtonsInteractable();
    }

    public void RemoveCharacter(string characterID)
    {
        if (selectedCharacters.Contains(characterID))
        {
            selectedCharacters.Remove(characterID);
            UpdateCharacterImage();
            Debug.Log("Character " + characterID + " Berhasil dihapus");
        }
        else
        {
            Debug.Log("Character " + characterID + " tidak ada dalam daftar");
        }

        UpdateButtonsInteractable();
    }

    private void UpdateCharacterImage()
    {
        for (int i = 0; i < characterImages.Count; i++)
        {
            characterImages[i].sprite = null;
        }

        for (int i = 0; i < selectedCharacters.Count && i < characterImages.Count; i++)
        {
            string selectedCharactersID = selectedCharacters[i];

            if (characterSpriteMap.TryGetValue(selectedCharactersID, out Sprite characterSprite))
            {
                characterImages[i].sprite = characterSprite;
            }
        }
    }

    public void SaveSelectedCharacter()
    {
        string dock1 = selectedCharacters[0];
        string dock2 = selectedCharacters[1];
        string dock3 = selectedCharacters[2];
        string playerPosBattleString = JsonUtility.ToJson(mainCharacter.transform.position);
        string currentMap = SceneManager.GetActiveScene().name;

        PlayerPrefs.SetString("dock1", dock1);
        PlayerPrefs.SetString("dock2", dock2);
        PlayerPrefs.SetString("dock3", dock3);
        PlayerPrefs.SetString("lastPositionBattle", playerPosBattleString);
        PlayerPrefs.SetString("mapLocationBattle", currentMap);
        PlayerPrefs.Save();
        LoadScene("Battle Scene");
    }

    //Coroutine Load Scene Animation
    private void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAnimation(sceneName));
    }
    IEnumerator LoadSceneAnimation(string sceneName)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(2);
        battleSetup.SetActive(false);
        SceneManager.LoadScene(sceneName);
    }
}