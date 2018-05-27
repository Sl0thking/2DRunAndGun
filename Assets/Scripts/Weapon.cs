using UnityEngine;
using RunAndGun2D.CustomEvents;

[RequireComponent (typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
	[Header ("Events")]
	public UnityEventFloat ammunitionPercentageUpdate;

	[Header ("Weapon")]
	public int magazineSize;
	public float shootCooldown;
	public float reloadTime;
    public AudioClip weaponShotSound;
    public AudioClip weaponReloadSound;
    private AudioSource source;


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
        source = GetComponent<AudioSource>();
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

		if (reloadTimer <= 0 && ammunitionCount == 0)
		{
			ammunitionCount = magazineSize;
            source.PlayOneShot(weaponReloadSound, 1F);

            // Notify UI about change of ammunition percentage
            ammunitionPercentageUpdate.Invoke(GetAmmunitionPercentage());
		}

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			if (shootTimer <= 0 && ammunitionCount > 0)
			{
                source.PlayOneShot(weaponShotSound, 1F);
                Shoot();
                ammunitionCount--;
				shootTimer = shootCooldown;					

				// Notify UI about change of ammunition percentage
				ammunitionPercentageUpdate.Invoke(GetAmmunitionPercentage());

				if (ammunitionCount == 0)
				{
					reloadTimer = reloadTime;
				}			
			}
		}
	}

	protected virtual void Shoot() { }

	private float GetAmmunitionPercentage()
	{
		return (float) ammunitionCount / magazineSize;
	}
}