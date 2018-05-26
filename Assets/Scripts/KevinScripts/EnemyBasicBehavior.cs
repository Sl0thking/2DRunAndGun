using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicBehavior : MonoBehaviour {
    
    public float keepMinDistance = 3f;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;


    public float enemySpeed = 5f;
    Animator enemyAnimator; // needed to change animation states

    // viewing
    public Transform enemyTransform;
    private ViewingDirectionEnum viewingDirectionEnum;
    public bool canFlip = true;
    public ViewingDirectionEnum viewingDirection = ViewingDirectionEnum.LEFT;
    float flipTime = 5f;
    float nextFlipChange = 0f;

    //attacking
    public float chargeTime;
    float startChargeTime;
    bool charging;
    Rigidbody2D enemyRigidbody;
    SpriteRenderer enemySpriteRendere;
    public float playerDistance = 10f;


    Vector3 negativeStartCast;
    Vector3 positveStartCast;
    Vector3 negativeEndCast;
    Vector3 positveEndCast;
    RaycastHit2D hit;


	// Use this for initialization
	void Start () {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemySpriteRendere = GetComponent<SpriteRenderer>();
        enemyTransform = GetComponent<Transform>();

        playerDistance = 10f;
        enemySpeed = 5f;
        keepMinDistance = 3f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        negativeStartCast = enemyTransform.position;
        negativeStartCast.x -= 0.4f;
        positveStartCast = enemyTransform.position;
        positveStartCast.x += 0.4f;
        negativeEndCast = enemyTransform.position;
        negativeEndCast.x -= playerDistance;
        positveEndCast = enemyTransform.position;
        positveEndCast.x += playerDistance;

        Debug.DrawLine (positveStartCast, positveEndCast, Color.yellow);
        Debug.DrawLine (negativeStartCast, negativeEndCast, Color.yellow);

        this.hit = checkRaycastHit();
        if (this.hit.collider != null && this.hit.collider.tag == "Player"){
            checkCollision();
        } else if (isPlayerInSight()){
            print("PLAYER INSIGHT");
        } else {
            if (Time.time > nextFlipChange) {
                if (Random.Range(0, 10) >= 5){
                    flipFacing();
                }
                nextFlipChange = Time.time + flipTime;
            }
        }
	}

    public RaycastHit2D checkRaycastHit(){
        if (viewingDirection == ViewingDirectionEnum.LEFT)
        {
            this.hit = Physics2D.Linecast(negativeStartCast, negativeEndCast);
        }
        else
        {
            this.hit = Physics2D.Linecast(positveStartCast, positveEndCast);
        }
        return this.hit;
    }

    public bool checkCollision()
    {
        this.hit = checkRaycastHit();
        //print("COlIDER: " + hit.collider + " - " + Time.deltaTime + " - " + hit.point.x + " <=> "+enemyTransform.position.x);
        if ((this.hit.point.x < enemyTransform.position.x) && ((enemyTransform.position.x - this.hit.point.x) > keepMinDistance))
        {
            float newX = enemySpeed * -1;
            print("move backward - " + newX);
            enemyRigidbody.velocity = new Vector2(newX, enemyRigidbody.velocity.y);
        }
        else if ((this.hit.point.x > enemyTransform.position.x) && ((this.hit.point.x - enemyTransform.position.x) > keepMinDistance))
        {
            float newX = enemySpeed;
            print("move forward - " + newX);
            enemyRigidbody.velocity = new Vector2(newX, enemyRigidbody.velocity.y);
        }
        if (Mathf.Floor(Mathf.Abs(enemyTransform.position.x - this.hit.point.x)) <= Mathf.Floor(keepMinDistance))
        {
            print("[IN SHOT DISTACE]");
            attack();
            return true;
        }
        return false;
    }

    bool isPlayerInSight(){
        print("CHECK FOR PLAYER IN SIGHT - BOTH DIRECTIONS");
        if (checkDirection(ViewingDirectionEnum.LEFT)){
            flipViewingDirection();
            //viewingDirection = ViewingDirectionEnum.LEFT;
            return true;
        } else if (checkDirection(ViewingDirectionEnum.RIGHT)) {
            flipViewingDirection();
            //viewingDirection = ViewingDirectionEnum.RIGHT;
            return true;
        }
        return false;
    }

    bool checkDirection(ViewingDirectionEnum direction) {
        if (direction == ViewingDirectionEnum.LEFT){
            RaycastHit2D currenthit = Physics2D.Linecast(negativeStartCast, negativeEndCast);
            if (currenthit.collider != null && currenthit.collider.tag == "Player"){
                return true;
            }
        } else if (direction == ViewingDirectionEnum.RIGHT) {
            RaycastHit2D currenthit = Physics2D.Linecast(positveStartCast, positveEndCast);
            if (currenthit.collider != null && currenthit.collider.tag == "Player"){
                return true;
            }
        }
        return false;
    }

    private void flipFacing(){
        if(canFlip){
            flipViewingDirection();
        } else {
            return;
        }
    }

    private void flipViewingDirection(){
        float facingX = enemyTransform.localScale.x;
        facingX *= -1f;
        enemySpriteRendere.flipX = !enemySpriteRendere.flipX;
        if (viewingDirection == ViewingDirectionEnum.LEFT){
            this.viewingDirection = ViewingDirectionEnum.RIGHT;
        }
        else{
            this.viewingDirection = ViewingDirectionEnum.LEFT;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player"){
            print("PLAYER");
            if (this.viewingDirection == ViewingDirectionEnum.RIGHT && 
                other.transform.position.x < enemyTransform.position.x){
                flipFacing();
            } else if(this.viewingDirection == ViewingDirectionEnum.LEFT &&
                      other.transform.position.x > enemyTransform.position.x){
                flipFacing();
            }
            canFlip = false;
            charging = true;
            startChargeTime = Time.time + chargeTime;
        }
    }

    private void OnTriggerStay2D(Collider2D other){
        if (other.tag == "Player"){
            print("PLAYER - HIT");
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        canFlip = true;
    }

    void attack(){
        print("[SHOT]");
    }
}
