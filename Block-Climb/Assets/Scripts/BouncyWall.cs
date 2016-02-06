using UnityEngine;
using System.Collections;

public class BouncyWall : MonoBehaviour {
	
	private Rigidbody2D playerRb;
	private Jumper jumper;
	private Vector2 targetVelocity = new Vector3(0,-3);
	
	// Use this for initialization
	void Start () {
		
		GameObject p = GameObject.FindGameObjectWithTag("Player");
		playerRb = p.GetComponent<Rigidbody2D>();
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
			jumper.turnRight(transform.position.x < jumper.transform.position.x);
			jumper.Jump();
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

}
