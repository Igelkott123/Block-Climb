using UnityEngine;
using System.Collections;

public class FollowPlayerY : MonoBehaviour
{
    public Transform player;
    private Vector2 playerPos = new Vector2();
	
	// Update position to follow the target object in Y-Axis.
	void Update ()
    {
        playerPos.Set(transform.position.x, player.position.y);
        transform.position = playerPos;
	}
}
