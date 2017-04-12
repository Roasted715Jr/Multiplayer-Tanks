using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        rb2d.velocity = new Vector2(0, Input.GetAxisRaw("P1 Move") * moveSpeed);

        float playerOneRotation = Input.GetAxisRaw("P1 Turn");

        Quaternion target = Quaternion.FromToRotation(Quaternion.identity, transform.rotation + playerOneRotation);
        rb2d.transform.rotation = target;
    }
}
