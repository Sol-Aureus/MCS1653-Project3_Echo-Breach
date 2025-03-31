using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LevelManager levelManager;

    [Header("Attributes")]
    [SerializeField] private float offset;

    private bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the player is allowed to move
        if (canMove)
        {
            // Allows the player to move the robot
            if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
            {
                // Check if there is a wall in front of the robot
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, offset * 2, wallLayer);
                if (hit)
                {
                    // Rotate the robot to face up
                    transform.rotation = Quaternion.Euler(0, 0, 0);

                    return;
                }

                // Add the move to the list of moves
                levelManager.AddMove();

                // Rotate the robot to face up
                transform.rotation = Quaternion.Euler(0, 0, 0);

                // Move the robot if there is no wall
                transform.position = new Vector3(transform.position.x, transform.position.y + (offset * 2), transform.position.z);
            }
            else if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
            {
                // Check if there is a wall in front of the robot
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, offset * 2, wallLayer);
                if (hit)
                {
                    // Rotate the robot to face down
                    transform.rotation = Quaternion.Euler(0, 0, 180);

                    return;
                }

                // Add the move to the list of moves
                levelManager.AddMove();

                // Rotate the robot to face down
                transform.rotation = Quaternion.Euler(0, 0, 180);

                // Move the robot if there is no wall
                transform.position = new Vector3(transform.position.x, transform.position.y - (offset * 2), transform.position.z);
            }
            else if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
            {
                // Check if there is a wall in front of the robot
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, offset * 2, wallLayer);
                if (hit)
                {
                    // Rotate the robot to face left
                    transform.rotation = Quaternion.Euler(0, 0, 90);

                    return;
                }

                // Add the move to the list of moves
                levelManager.AddMove();

                // Rotate the robot to face left
                transform.rotation = Quaternion.Euler(0, 0, 90);

                // Move the robot if there is no wall
                transform.position = new Vector3(transform.position.x - (offset * 2), transform.position.y, transform.position.z);
            }
            else if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
            {
                // Check if there is a wall in front of the robot
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, offset * 2, wallLayer);
                if (hit)
                {
                    // Rotate the robot to face right
                    transform.rotation = Quaternion.Euler(0, 0, 270);

                    return;
                }

                // Add the move to the list of moves
                levelManager.AddMove();

                // Rotate the robot to face right
                transform.rotation = Quaternion.Euler(0, 0, 270);

                // Move the robot if there is no wall
                transform.position = new Vector3(transform.position.x + (offset * 2), transform.position.y, transform.position.z);
            }
        }
        

        // Allow the player to undo the last move
        if (Input.GetKeyDown("r"))
        {
            levelManager.UndoMove();
            canMove = true;
        }
    }

    // Kills the robot
    public void KillRobot()
    {
        // Play sound effect
        //menuSoundsManager.instance.PlaySound(menuSounds[1], transform, 0.5f);
        // Restart the level
        canMove = false;
    }
}