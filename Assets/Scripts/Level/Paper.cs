using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioClip sound;

    // Detects when the player collides
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Play sound effect
            SoundFXManager.instance.PlaySound(sound, transform, 1);

            // Destroys the game object
            gameObject.SetActive(false);
        }
    }
}
