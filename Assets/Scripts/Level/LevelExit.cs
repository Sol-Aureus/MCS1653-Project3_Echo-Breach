using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelManager levelManager;

    // Detects when the player collides
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Opens the win menu
            levelManager.Win();
        }
    }
}
