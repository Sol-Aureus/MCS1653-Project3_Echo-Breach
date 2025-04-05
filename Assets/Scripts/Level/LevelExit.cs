using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject[] paper;

    private bool allCollected = false;

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject p in paper)
        {
            // Checks if the paper is collected
            if (p.activeSelf)
            {
                allCollected = false;
                break;
            }
            else
            {
                allCollected = true;
            }
        }
    }


    // Detects when the player collides
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && allCollected)
        {
            // Opens the win menu
            levelManager.Win();
        }
    }
}
