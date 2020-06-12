using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour {
    
    public Rigidbody2D rb;
    public float jumpPower; // jump power of player
	public float speed; // speed of player
	private float xAxis; // move right when 1 move left when -1
	private float yAxis; // move up when 1 move down when -1
    private bool facingRight = true; // player facing right

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D> ();
		rb.bodyType = RigidbodyType2D.Dynamic; 
		//rb.gravityScale = 1;
	}

	// Update is called once per frame
	void Update () {
        playerMove();
	}
    
    void playerMove() {
        xAxis = Input.GetAxis ("Horizontal"); // handle direction for A/D/left/right key presses
        yAxis = 0; // idk wots going on rn but no jump yet
        
        if (Input.GetButtonDown("Jump")) {
            jump();
        }
        
        if (xAxis < 0 && facingRight == false) {
            flipPlayer();
        } else if (xAxis > 0 && facingRight == true) {
            flipPlayer();
        }
        
		transform.Translate (new Vector2 (xAxis, yAxis) * Time.deltaTime * speed);  // moves player
    }
    
    void jump() {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
    }
    
    void flipPlayer() {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

}
