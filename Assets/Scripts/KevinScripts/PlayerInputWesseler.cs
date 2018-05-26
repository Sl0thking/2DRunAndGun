using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInputWesseler : MonoBehaviour {

    public float moveSpeed = 5f;
    public float jumpHeight = 10f;
    public bool grounded = false;
    public ViewingDirectionEnum viewingDirectionEnum;

    private KeyCode moveLeft = KeyCode.A;
    private KeyCode moveRight = KeyCode.D;
    private KeyCode jumpUp = KeyCode.Space;
    private ViewingDirectionEnum viewingDirection = ViewingDirectionEnum.LEFT;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        print("[PLAYER INPUT]");
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(jumpUp) == true && grounded) {
            grounded = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(
                GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            transform.Translate(Vector3.up * jumpHeight * Time.deltaTime);
        } else if (Input.GetKey(moveLeft) == true) {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            changeViewingDirection(moveLeft);
        } else if (Input.GetKey(moveRight) == true) {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            changeViewingDirection(moveRight);
        }
	}

    //check to see if charackter is grounde
    private void OnTriggerEnter2D(Collider2D other){
        grounded = true;
        if (other.tag == "Enemy")
        {
            print("[YOU GOT HIT]");
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        grounded = false;
    }

    private void OnTriggerStay2D(Collider2D other){
        if (other.tag == "Enemy")
        {
            print("[YOU GOT HIT]");
        }
    }

    private void changeViewingDirection(KeyCode keyCode){
        if (keyCode == moveRight){
            this.viewingDirection = ViewingDirectionEnum.RIGHT;
            spriteRenderer.flipX = true;
        } else {
            this.viewingDirection = ViewingDirectionEnum.LEFT;
            spriteRenderer.flipX = false;
        }
    }
}
