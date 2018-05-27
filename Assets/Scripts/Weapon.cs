using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour
{
	[Header ("Weapon")]
	public int magazineSize;
	public float shootCooldown;
	public float reloadTime;

	[Header ("Projectile")]
	public GameObject projectilePrefab;
	public int projectileDamage;
	public float projectileSpeed;
	public float projectileLifetime;

	[HideInInspector]
	public int ammunitionCount;
	
	private float shootTimer;
	private float reloadTimer;

	void Start()
	{
		ammunitionCount = magazineSize;
		shootTimer = 0;
		reloadTimer = 0;
	}

	void Update ()
	{
		// Handle shootCooldown and reloadTime
		if (shootTimer > 0)
		{
			shootTimer -= Time.deltaTime;
		}
		if (reloadTimer > 0)
		{
			reloadTimer -= Time.deltaTime;
		}

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			if (ammunitionCount > 0)
			{
				if (shootTimer <= 0)
				{
					Shoot();
					ammunitionCount--;
					shootTimer = shootCooldown;					

					// EDIT: notify UI "bullet shot"
					// notify UI


					if (ammunitionCount == 0)
					{
						reloadTimer = reloadTime;
					}
				}			
			}
			else
			{
				if (reloadTimer <= 0)
				{
					ammunitionCount = magazineSize;
				}
			}
		}
	}

	protected virtual void Shoot () { }
}