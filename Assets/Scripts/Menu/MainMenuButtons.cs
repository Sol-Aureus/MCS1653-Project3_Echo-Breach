using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject levelSelect;
    [SerializeField] private AudioClip[] soundFX;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        optionsMenu.SetActive(false);
    }

    // PlayGame opens the level select menu
    public void PlayGame()
    {
        //SoundFX.instance.PlaySound(soundFX[0], transform, 0.5f);
        levelSelect.SetActive(true);
    }

    // Options opens the options menu
    public void Options()
    {
        //SoundFX.instance.PlaySound(soundFX[0], transform, 0.5f);
        optionsMenu.SetActive(true);
    }

    // Back closes the options and level select menus
    public void Back()
    {
        //SoundFX.instance.PlaySound(soundFX[0], transform, 0.5f);
        optionsMenu.SetActive(false);
        levelSelect.SetActive(false);
    }


    // QuitGame quits the application
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    // LoadLevel loads the level
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene("Level (" + levelIndex.ToString() + ")");
    }
}
