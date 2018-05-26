using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertEagle : Weapon {

	public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			var bullet_instance = Instantiate(bulletPrefab, this.transform.Find("SpawnPoint").transform.position, this.transform.rotation);
			Destroy(bullet_instance, 10f);
		}
	}
}
