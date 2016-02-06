using UnityEngine;
using System.Collections;

public class DisappearingWall : MonoBehaviour 
{
	private Rigidbody2D playerRb;
	private Jumper jumper;
	private Vector2 targetVelocity = new Vector2(0,-3);
	
	// Initialize the playerRb and jumper variables.
	void Start () 
	{
		GameObject p = GameObject.FindGameObjectWithTag("Player");
		playerRb = p.GetComponent<Rigidbody2D>();
		jumper = p.GetComponent<Jumper>();
	}
	
	// Update is called once per frame.
	void Update () 
	{
		
	}
	
	// On collision enter, Change player's turnRight and isColliding accordingly.
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider.gameObject.tag=="Player")
		{
			jumper.isColliding(true);
			jumper.turnRight(transform.position.x < jumper.transform.position.x);
		}
	}
	
	// On collision exit, Resets Player's isColliding.
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.collider.gameObject.tag == "Player")
		{
			jumper.isColliding(false);
			Disappear ();
		}
	}

	// Make the wall disappear.
	void Disappear ()
	{
		Destroy (gameObject);
	}
	// Make sure that the player's Y-velocity doesn't increase to much when player is in contact with the wall.
	void OnCollisionStay2D(Collision2D col)
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
