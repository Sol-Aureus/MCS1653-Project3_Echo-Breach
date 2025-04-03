using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class LevelManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private AudioClip[] menuSounds;
    [SerializeField] private GameObject robot;
    [SerializeField] private TextMeshProUGUI moveText;

    public bool isPaused = false;
    private bool otherMenu = false;

    private List<Vector3> robotMoves = new List<Vector3>();
    private List<Quaternion> robotRotation = new List<Quaternion>();

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

    // Opens the win menu
    public void Win()
    {
        otherMenu = true;
        isPaused = true;
        winMenu.SetActive(true);
        Time.timeScale = 0;
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

    // Loads the next level
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // Unpauses the game
        Time.timeScale = 1;
    }

    // Adds the move to the list of moves
    public void AddMove()
    {
        robotMoves.Add(robot.transform.position);
        robotRotation.Add(robot.transform.rotation);
    }

    // Undoes the last move
    public void UndoMove()
    {
        // Checks if there are any moves to undo
        if (robotMoves.Count > 0)
        {
            // Moves the robot to the last position
            robot.transform.position = robotMoves[robotMoves.Count - 1];
            robot.transform.rotation = robotRotation[robotRotation.Count - 1];

            // Removes the last move from the list
            robotMoves.RemoveAt(robotMoves.Count - 1);
            robotRotation.RemoveAt(robotRotation.Count - 1);
        }
    }

    // Changes the gui when needed
    private void OnGUI()
    {
        // Tells the player how many moves they made
        moveText.text = "Moves: " + robotMoves.Count;
    }
}
