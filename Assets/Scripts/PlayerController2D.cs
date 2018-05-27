using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Animator))]
public class PlayerController2D : PhysicsObject {

	[Header ("Movement")]
	[Range (1, 20), Tooltip ("Maximum movement speed")]
    public float maximumSpeed = 7;
	[Range (1, 20), Tooltip ("Start speed when jumping")]
    public float jumpTakeOffSpeed = 7;
    [Range (0, 1)]
    public float horizontalJumpIntensity = 0.7f;

    public List<GameObject> weaponPrefabs;

    public List<Weapon> weaponList;

    private int activeWeaponIndex = 0;

    private Animator animator;  

    void Awake () 
    {
        animator = GetComponent<Animator> ();
        createWeapons();
    }

    public void createWeapons()
    {
        for (int i = 0; i < weaponPrefabs.Count;i++)
        {
            if (weaponPrefabs[i] != null)
            {
                GameObject weaponInstance = Instantiate(weaponPrefabs[i], this.transform.Find("WeaponAnchor").position, this.transform.Find("WeaponAnchor").rotation);
                weaponInstance.transform.parent = this.transform;
                weaponList.Add(weaponInstance.GetComponent<Weapon>());
                if (i != 0)
                {
                    weaponInstance.SetActive(false);
                }
            }
        }
        activeWeaponIndex = 0;
    }

    private void switchWeapon(int weaponIdx)
    {
        if (weaponIdx < weaponList.Count)
        {
            getActiveWeapon().gameObject.SetActive(false);
            activeWeaponIndex = weaponIdx;
            getActiveWeapon().gameObject.SetActive(true);
        }

    }

    protected override void additionalUpdate()
    {
        base.additionalUpdate();
        //Select Weapon 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            switchWeapon(0);
        }
        //Select Weapon 2
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            switchWeapon(1);
        }
        //Select Weapon 3
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            switchWeapon(2);
        }
    }


    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");

        if (!grounded)
        {
            move.x = move.x * horizontalJumpIntensity;
        }

        if (Input.GetButtonDown ("Jump") && grounded)
		{
            velocity.y = jumpTakeOffSpeed;
        }
		else if (Input.GetButtonUp ("Jump")) 
        {            
            if (velocity.y > 0)
			{
                velocity.y = velocity.y * 0.5f;
            }
        }        

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (transform.position.x < mousePos.x && this.transform.rotation.eulerAngles.y == 0)
        {
            this.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }
        else if (transform.position.x > mousePos.x && this.transform.rotation.eulerAngles.y == 180)
        {
            this.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }

        animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maximumSpeed);

        targetVelocity = move * maximumSpeed;
    }

    public Weapon getActiveWeapon()
    {
        return weaponList[activeWeaponIndex];
    }
}