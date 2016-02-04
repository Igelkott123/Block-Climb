using UnityEngine;
using System.Collections;

public class FollowPlayerY : MonoBehaviour
{
    public Transform player;
    private Vector3 playerPos = new Vector3();
	
	// Update position to follow the target object in Y-Axis.
	void Update ()
    {
        playerPos.Set(transform.position.x, player.position.y, transform.position.z);
        transform.position = playerPos;
	}
}
