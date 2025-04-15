using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform movePos;
    [SerializeField] private GameObject echo;
    [SerializeField] private AudioClip sound;

    // Detects when the player collides
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(echo, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

            // Moves the player to the move position
            other.transform.position = movePos.position;

            // Play sound effect
            SoundFXManager.instance.PlaySound(sound, transform, 0.8f);
        }
    }
}
