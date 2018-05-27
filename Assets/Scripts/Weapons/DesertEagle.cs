using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertEagle : Weapon
{

    private void Awake()
    {
        this.magazineSize = 12;
        this.shootCooldown = .5f;
        this.reloadTime = 1f;

        this.projectileDamage = 10;
        this.projectileSpeed = 10;
        this.projectileLifetime = 10;
    }
    protected override void Shoot ()
	{
		var bulletInstance = Instantiate(this.projectilePrefab, this.transform.Find("Bullet Spawn Point").transform.position, this.transform.rotation);
		var projectile = bulletInstance.GetComponent<Projectile>();
		projectile.Initialize(this.transform.root.gameObject, this.projectileDamage, this.projectileSpeed);
		Destroy(bulletInstance, this.projectileLifetime);
	}
}
