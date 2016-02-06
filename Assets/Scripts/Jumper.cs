﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    public bool canJump = true;
    public bool isTurnedRight = true;
    private Rigidbody2D rb;
    public float JumpStrength = 1;
    public Vector2 JumpDirection = new Vector2(1,1);

    // Initialize the rb variable.
    void Start () 
	{
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame.
    // On a touch event, make the gameobject jump if it can.
    void Update () 
	{
        if (Input.GetMouseButtonDown(0) && canJump) Jump();
    }


    // Applies a fixed jump force to the player.
    public void Jump ()
    {
        if (isTurnedRight)
        {
            rb.velocity = JumpStrength * JumpDirection;
        }
        else
        {
            rb.velocity = JumpStrength * Vector2.Reflect(JumpDirection, Vector2.right);
        }
        canJump = false;
    }

	// If the player is colliding, make able to jump and change isTurnedRight.
    public void isColliding(bool b)
    {
        canJump = b;
        if (b) isTurnedRight = !isTurnedRight;
    }

	// Turn the player according to b.
    public void turnRight(bool b)
    {
        isTurnedRight = b;
    }

	// Check if the player has jumped.
    public bool hasJumped()
    {
        return !canJump;
    }
}
