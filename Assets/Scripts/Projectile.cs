using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Projectile : MonoBehaviour {

	[Range (1, 100)]
	public int damage = 10;
	[Range (1, 10)]
	public float travelSpeed = 1f;

	private Rigidbody2D rigidBody;

	void Start () {
		rigidBody = this.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		this.rigidBody.velocity = this.transform.right * -1 * travelSpeed;
	}
}
