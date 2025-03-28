using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header("Menus")]
    [SerializeField] private GameObject pauseMenu;

    [Header("References")]
    [SerializeField] private AudioClip[] menuSounds;

    private bool isPaused = false;
    private bool otherMenu = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Pauses the game if the player presses the escape key and no other menu is open
        if (Input.GetButtonDown("Cancel") && !otherMenu)
        {
            Pause();
        }
    }

    // Opens the pause menu
    public void Pause()
    {
        // Play sound effect
        //menuSoundsManager.instance.PlaySound(menuSounds[2], transform, 0.5f);

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
