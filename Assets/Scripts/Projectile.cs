using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Projectile : MonoBehaviour
{

	private int damage = 10;
	private float travelSpeed = 10f;

	private GameObject instantiator;
	private Rigidbody2D rigidBody;

	private bool initialized = false;

	void Start ()
	{
		rigidBody = this.GetComponent<Rigidbody2D>();
	}

	public void Initialize (GameObject instantiator, int damage, float travelSpeed)
	{
		this.instantiator = instantiator;
		this.damage = damage;
		this.travelSpeed = travelSpeed;
		this.initialized = true;
	}
	
	void Update ()
	{
		if (initialized)
		{
			this.rigidBody.velocity = this.transform.right * -1 * travelSpeed;
		}			
	}

	void OnTriggerEnter2D (Collider2D other)
    {
		if (this.instantiator != other.gameObject && other.gameObject.GetComponent<Projectile>() == null)
		{
			var health = other.gameObject.GetComponent<Health>();
			if (health != null)
			{
				int newHealth = health.currentHealth - this.damage;
				health.currentHealth = newHealth < 0 ? 0 : newHealth;
			}

			Destroy(this.gameObject);
		}
    }
}
