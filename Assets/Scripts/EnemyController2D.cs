using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Animator))]
public class EnemyController2D : PhysicsObject {

	public float minDistanceToTarget = 3f;
	public float viewDistance = 5f;

    private Animator animator;

    void Awake () 
    {
        animator = GetComponent<Animator> ();
    }
	
	void Update ()
	{
		Vector2 move = Vector2.zero;

		Transform enemy = GetEnemyInDistance();

        targetVelocity = move;
	}

	Transform GetEnemyInDistance()
	{
		Transform enemy = null;

		RaycastHit2D rightHit = Physics2D.Raycast(this.transform.position, this.transform.right, LayerMask.GetMask("Player"));
		RaycastHit2D leftHit = Physics2D.Raycast(this.transform.position, this.transform.right, LayerMask.GetMask("Player"));

		print(rightHit.transform.gameObject.name);
		print(leftHit.transform.gameObject.name);

		Debug.DrawRay(this.transform.position, this.transform.right * -1 * viewDistance, Color.red);
		Debug.DrawRay(this.transform.position, this.transform.right * viewDistance, Color.green);


		return enemy;
	}
}
