using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    private Rigidbody playerRb;
    private Jumper jumper;
    private Vector3 targetVelocity = new Vector3(0,-3,0);

	// Use this for initialization
	void Start () {

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        playerRb = p.GetComponent<Rigidbody>();
        jumper = p.GetComponent<Jumper>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Resets Player's jump.
    void OnCollisionEnter(Collision col)
    {
        if(col.collider.gameObject.tag=="Player")
        {
            jumper.isColliding(true);
            jumper.turnRight(transform.position.x < jumper.transform.position.x);
        }
    }

    // Resets Player's jump.
    void OnCollisionExit(Collision col)
    {
        if (col.collider.gameObject.tag == "Player")
        {
            jumper.isColliding(false);
        }
    }
    
    // Make sure that the player's Y-velocity doesn't increase to much when player is in contact with the wall.
    void OnCollisionStay(Collision col)
    {
        if (col.collider.gameObject.tag == "Player")
        {
            if (playerRb.velocity.y < targetVelocity.y && !jumper.hasJumped())
            {
                playerRb.AddForce(10*(targetVelocity - playerRb.velocity));
            }
        }
    }
}
