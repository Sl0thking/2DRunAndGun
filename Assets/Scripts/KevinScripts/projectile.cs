using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    public Rigidbody2D rigidbody;
    public Vector2 velocity;
    float direction = 1;
    float speed = 5;
    public float damage = 10;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        print("EB: " + this.GetComponentInParent<EnemyBasicBehavior>());
	}

    // Update is called once per frame
    void Update()
    {
        //velocity = new Vector2(direction * speed, rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.collider.tag != "Player"){
            print("COLLISION WITH SOMETHING != PLAYER");
            rigidbody.velocity = new Vector2(-velocity.x, velocity.y);
        } else {
            PlayerController2D playerContr = (PlayerController2D) collision.gameObject.GetComponent<PlayerController2D>();
            try{
                //playerContr.takeDamage(damage);
                //if (playerContr.getHealth() >= 0){
                    Destroy(collision.gameObject);
                //}
            } catch(UnityException){}
            Explode();
        }
    }

    void Explode(){
        print("DESTROY");
        Destroy(this.gameObject);
    }
}
