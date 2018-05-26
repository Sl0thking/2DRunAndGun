using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (SpriteRenderer))]
public class PlayerController2D : PhysicsObject {

	[Header ("Movement")]
	[Range (1, 20), Tooltip ("Maximum movement speed")]
    public float maximumSpeed = 7;
	[Range (1, 20), Tooltip ("Start speed when jumping")]
    public float jumpTakeOffSpeed = 7;
    [Range (0, 1)]
    public float horizontalJumpIntensity = 0.7f;

    public GameObject weapon;
    private SpriteRenderer weaponRenderer;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake () 
    {
        spriteRenderer = GetComponent<SpriteRenderer> (); 
        animator = GetComponent<Animator> ();
        weaponRenderer = weapon.GetComponent<SpriteRenderer>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");

        if (!grounded)
        {
            move.x = move.x * horizontalJumpIntensity;
        }

        if (Input.GetButtonDown ("Jump") && grounded)
		{
            velocity.y = jumpTakeOffSpeed;
        }
		else if (Input.GetButtonUp ("Jump")) 
        {            
            if (velocity.y > 0)
			{
                velocity.y = velocity.y * 0.5f;
            }
        }        

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (transform.position.x < mousePos.x && this.transform.rotation.eulerAngles.y == 0)
        {
            this.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }
        else if (transform.position.x > mousePos.x && this.transform.rotation.eulerAngles.y == 180)
        {
            this.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }


        // bool flipSprite = (spriteRenderer.flipX ? (transform.position.x > mousePos.x) : (transform.position.x < mousePos.x));
        // if (flipSprite) 
        // {
        //     spriteRenderer.flipX = !spriteRenderer.flipX;
        //     weaponRenderer.flipY = !weaponRenderer.flipY;
        // }

        // animator.SetBool ("grounded", grounded);
        animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maximumSpeed);

        targetVelocity = move * maximumSpeed;
    }
}