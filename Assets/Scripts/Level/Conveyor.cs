using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform movePos;

    // Detects when the player collides
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Moves the player to the move position
            other.transform.position = movePos.position;
        }
    }
}
