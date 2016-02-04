using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Jumper : MonoBehaviour {

    public bool canJump = true;
    public bool isTurnedRight = true;
    private Rigidbody rb;
    public float JumpStrength = 1;
    public Vector3 JumpDirection = new Vector3(1,1,0);

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    // On a touch event, make the gameobject jump if it can.
    void Update () {
        if (Input.GetMouseButtonDown(0) && canJump) Jump();
    }


    // Applies a fixed jump force to the player.
    void Jump ()
    {
        if (isTurnedRight)
        {
            rb.velocity = JumpStrength * JumpDirection;
        }
        else
        {
            rb.velocity = JumpStrength * Vector3.Reflect(JumpDirection, Vector3.right);
        }
        canJump = false;
    }

    public void isColliding(bool b)
    {
        canJump = b;
        if (b) isTurnedRight = !isTurnedRight;
    }

    public void turnRight(bool b)
    {
        isTurnedRight = b;
    }

    public bool hasJumped()
    {
        return !canJump;
    }
}
