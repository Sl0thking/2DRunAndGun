using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    public Vector2 velocity;
    float direction = 1;
    float speed = 5;
    public int damage = 10;

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.collider.tag != "Player" && collision.collider.tag != "Enemy") {
            Explode();
        } else {
            PlayerController2D playerContr = (PlayerController2D) collision.gameObject.GetComponent<PlayerController2D>();
            try{
                Health health = playerContr.GetComponent<Health>();
                if (health != null){
                    health.TakeDamage(this.damage);
                }
                Destroy(this.gameObject);
            } catch(UnityException){}
            Explode();
        }
    }

    void Explode(){
        Destroy(this.gameObject);
    }
}
