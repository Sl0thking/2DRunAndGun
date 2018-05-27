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

		print("debug.drawray");


        targetVelocity = move;
	}

	Transform GetEnemyInDistance()
	{
		Transform enemy = null;

		
		Debug.DrawRay(this.transform.position, this.transform.right * -1 * viewDistance, Color.red);
		Debug.DrawRay(this.transform.position, this.transform.right * viewDistance, Color.red);


		return enemy;
	}
}
