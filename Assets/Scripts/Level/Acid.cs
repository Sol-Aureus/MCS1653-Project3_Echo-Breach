using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    // Checks if the robot has entered the acid
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Acid");
        // Checks if the robot has entered the acid
        if (other.CompareTag("Player"))
        {
            // Restarts the level
            other.GetComponent<Robot>().KillRobot();
        }
    }
}
