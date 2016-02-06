using UnityEngine;
using System.Collections;


// TODO: Add text on the block


public class Counter : MonoBehaviour 
{
	public int counter = 1;
	private SpriteRenderer sr;
	private Color color3 = new Color(1,0,0);
	private Color color2 = new Color(1,0.5f,0);
	private Color color1 = new Color(1,1,0);
	private Color color0 = new Color(0,1,0);


	// Use this for initialization
	void Start () 
	{
		sr = GetComponent<SpriteRenderer> ();
		changeColor ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	// Change the counter and color on collision.
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.collider.gameObject.tag == "Player") 
		{
			if (counter > 0) counter -= 1;
			changeColor ();
		}
	}

	// Change color according to counter.
	void changeColor ()
	{
		if (counter == 0) 
		{
			sr.color = color0;
		}
		if (counter == 1) 
		{
			sr.color = color1;
		} 
		else if (counter == 2) 
		{
			sr.color = color2;
		}
		else if (counter == 3) 
		{
			sr.color = color3;
		}
	}
}
