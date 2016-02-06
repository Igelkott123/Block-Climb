using UnityEngine;
using System.Collections;

public class BouncyWall : MonoBehaviour 
{
	private Jumper jumper;
	
	// Initialize thej umper variable.
	void Start () 
	{
		GameObject p = GameObject.FindGameObjectWithTag("Player");
		jumper = p.GetComponent<Jumper>();
	}
	
	// Update is called once per frame.
	void Update () 
	{
		
	}
	
	// On collision enter, Change player's turnRight accordingly and enforce an immediate Jump.
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider.gameObject.tag=="Player")
		{
			jumper.turnRight(transform.position.x < jumper.transform.position.x);
			jumper.Jump();
		}
	}
	
	// On collision exit, Resets Player's isColliding.
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.collider.gameObject.tag == "Player")
		{
			jumper.isColliding(false);
		}
	}

}
