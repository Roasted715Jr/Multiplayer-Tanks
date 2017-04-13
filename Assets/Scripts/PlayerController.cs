using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float turnSpeed;
    public float shellSpeed;
    public string color;
    //Find a way to index variables to make the index referencing below accurate
    public Sprite[] sprites;
    public GameObject barrel;
    public GameObject shellPrefab;
    public GameObject barrelEnd;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer barrelSpriteRenderer;
    private SpriteRenderer shellSpriteRenderer;
    //Movement and rotation need to be defined up here or else they will only be accessible in the "if/else" statements
    private float movement;
    private float rotation;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        barrelSpriteRenderer = barrel.GetComponent<SpriteRenderer>();
        shellSpriteRenderer = shellPrefab.GetComponent<SpriteRenderer>();
        
        
        if (color == "Red")
        {
            spriteRenderer.sprite = sprites[0];
            barrelSpriteRenderer.sprite = sprites[1];
            shellSpriteRenderer.sprite = sprites[2];
        }
        else if (color == "Blue")
        {
            spriteRenderer.sprite = sprites[3];
            barrelSpriteRenderer.sprite = sprites[4];
            shellSpriteRenderer.sprite = sprites[5];
        }
	}
	
	void Update () {
        if (color == "Red")
        {
            movement = Input.GetAxisRaw("P1 Move");
            rotation = Input.GetAxisRaw("P1 Turn");
        }
        else if (color == "Blue")
        {
            movement = Input.GetAxisRaw("P2 Move");
            rotation = Input.GetAxisRaw("P2 Turn");
        }

        transform.Rotate(Vector3.forward * rotation * -turnSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * movement * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && color == "Red" || Input.GetKeyDown(KeyCode.Return) && color == "Blue")
            Shoot();
    }

    public void Shoot()
    {
        GameObject newShell = Instantiate(shellPrefab, barrelEnd.transform.position, transform.rotation);
        newShell.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * shellSpeed * Time.deltaTime);
    }
}
