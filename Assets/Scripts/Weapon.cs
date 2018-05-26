using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	[Header ("Projectile")]
	public GameObject projectilePrefab;
	public int projectileDamage;
	public float projectileSpeed;
	public float projectileLifetime;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Shoot();
		}
	}

	protected virtual void Shoot () { }
}
