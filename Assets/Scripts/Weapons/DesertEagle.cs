using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertEagle : Weapon
{
    protected override void Shoot ()
	{
		var bulletInstance = Instantiate(this.projectilePrefab, this.transform.Find("Bullet Spawn Point").transform.position, this.transform.rotation);
		var projectile = bulletInstance.GetComponent<Projectile>();
		projectile.Initialize(this.transform.root.gameObject, this.projectileDamage, this.projectileSpeed);
		Destroy(bulletInstance, this.projectileLifetime);
	}
}
