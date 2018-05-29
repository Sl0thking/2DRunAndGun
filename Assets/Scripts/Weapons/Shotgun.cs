using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon {

    [Header("Shotgun Specific")]
    public int ProjectileCount = 8;
    public float ShotSpread = 30f;

    protected override void Shoot()
    {
        for (int i = 0; i < ProjectileCount; i++)
        {

            float spreadRangeStart = ShotSpread / 2 * -1;
            float spaceBetweenProjectiles = ShotSpread / (ProjectileCount + 1);
            float zRotation = spreadRangeStart + ((i + 1) * spaceBetweenProjectiles);

            Quaternion rotation = this.transform.rotation;
            rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z + zRotation);

            var bulletInstance = Instantiate(this.projectilePrefab, this.transform.Find("Bullet Spawn Point").transform.position, rotation);
            var projectile = bulletInstance.GetComponent<Projectile>();
            projectile.Initialize(this.transform.root.gameObject, this.projectileDamage, this.projectileSpeed);
            Destroy(bulletInstance, this.projectileLifetime);
        }
    }

   
}
