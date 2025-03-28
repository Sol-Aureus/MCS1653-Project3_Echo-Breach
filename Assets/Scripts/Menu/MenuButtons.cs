using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject pauseMenu;

    [Header("References")]
    [SerializeField] private AudioClip[] soundFX;

    private bool isPaused = false;
    private bool otherMenu = false;

    // Opens the pause menu
    public void Pause()
    {
        // Play sound effect
        SoundFXManager.instance.PlaySound(soundFX[2], transform, 0.5f);

        // Checks if the pause menu is already open
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        // Pauses the game
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    // Returns to the main menu
    public void Home()
    {
        SceneManager.LoadScene(0);

        // Unpauses the game
        Time.timeScale = 1;
    }

    // Restarts the current level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Unpauses the game
        Time.timeScale = 1;
    }
}
