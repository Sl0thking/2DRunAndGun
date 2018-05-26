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

    public float velomultiplier = 0.5f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private Health playerHealth;


    // Use this for initialization
    void Awake () 
    {
        spriteRenderer = GetComponent<SpriteRenderer> (); 
        animator = GetComponent<Animator> ();
        playerHealth = GetComponent<Health>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");

        if (!grounded)
        {
            move.x = move.x * velomultiplier;
            this.playerHealth.TakeDamage(1);
            
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

        bool flipSprite = (spriteRenderer.flipX ? (move.x < 0.01f) : (move.x > 0.01f));
        if (flipSprite) 
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool ("grounded", grounded);
        animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maximumSpeed);

        targetVelocity = move * maximumSpeed;
    }
}