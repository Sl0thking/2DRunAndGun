using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotProjectile : MonoBehaviour {

    public GameObject projectile;
    GameObject projectileGO;
    public Vector2 velocity;
    bool canShot = true;
    public Vector2 offset = new Vector2(0.4f,0.1f);
    public EnemyBasicBehavior enemyBehavior;
    public float cooldown = 4f;
    float direction = 1;
    public float bulletSpeed = 5;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(enemyBehavior.checkCollision() && canShot){
            if (enemyBehavior.viewingDirection == ViewingDirectionEnum.LEFT){
                direction = -1;
            } else if (enemyBehavior.viewingDirection == ViewingDirectionEnum.RIGHT){
                direction = 1;
            }
            print("[SHOT PROJECTILE] " + transform.localScale.x + " - " + enemyBehavior.viewingDirection);
            projectileGO = (GameObject) Instantiate(projectile, (Vector2) transform.position + offset * direction, Quaternion.identity);
            projectileGO.GetComponent<Rigidbody2D>().velocity = new Vector2(direction * bulletSpeed, velocity.y);
            StartCoroutine(canShoot());
        }
		
	}

    IEnumerator canShoot(){
        canShot = false;
        yield return new WaitForSeconds(cooldown);
        canShot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("________________________ENTER_______________________");
    }
}
