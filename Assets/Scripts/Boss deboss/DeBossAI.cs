using UnityEngine;
using System.Collections;

public class DeBossAI : MonoBehaviour {


	//speed summoning blocking
	
	float maxSpeed = 4f;
	bool facingRight;
	
	public float speed;	
	public bool blocking;
	public bool attacking;
	Animator anim;
	
	readonly float CHANCE_TO_SUMMON = 60f;
	readonly float CHANGE_MOVEMENT_INTERVAL = 2f;
	readonly float CHARGE_CAST_TIME = 2.85f;
	readonly float SHOOT_FORCE = 400;
	readonly float ATTACK_TIME = 3f;
	readonly float CHECK_JUMP_INTERVAL = 2f;
	bool onGround = false;

	public GameObject shield;
	
	// effects
	public GameObject demonicBlastPrefab;

	
	
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		InvokeRepeating ("RandomMovement", 0,  CHANGE_MOVEMENT_INTERVAL); 
		InvokeRepeating ("ShootRandomlyInTheAir", 0, 0.2f);
		InvokeRepeating ("RandomlyEnableAttack", 3f, 5f);
	}

	
	// Update is called once per frame
	void Update () {
		UpdateAnimator();
		CheckFlip ();
		UpdateShield();
	}
	
	void UpdateShield(){
		if (!blocking){
			shield.SetActive(true);
		}else{
			shield.SetActive(false);
		}
	}
	
	void RandomJump(){
		rigidbody2D.AddForce (Vector2.up*1000);
	}
	
	void ShootRandomlyInTheAir(){
		if (attacking){
			blocking = false;
			GameObject demonicBlastClone = Instantiate(demonicBlastPrefab) as GameObject;
			demonicBlastClone.transform.position = gameObject.transform.position;
			Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(-120, 120));
			Vector3 direction = rotation * Vector3.up * SHOOT_FORCE;
			demonicBlastClone.rigidbody2D.AddForce(direction);
		}
	}
	
	void RandomlyEnableAttack(){
		attacking = true;
		StopRunning();
		Invoke ("DisableAttacking", ATTACK_TIME);	
	}
	
	void DisableAttacking(){
		attacking = false;
		blocking = true;
		JustRun();
	}
	
	void UpdateAnimator(){	
		gameObject.rigidbody2D.velocity = Vector2.right*speed;
		anim.SetBool("blocking", blocking);
		anim.SetFloat ("speed", Mathf.Abs(speed));
	}
	
	void RandomMovement(){
		if (attacking)
			return;
		JustRun ();
		/*
		float randomNumber = Random.Range(0, 100);
		if (randomNumber < 75){		
			// keep running
			JustRun ();
		}else{
			StopRunning();
		}*/
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Wall"){
			Flip ();
		}
	}
	
	void JustRun(){
		float flipCoin = Random.Range(0, 10);
		blocking = true;
		if (flipCoin <= 5) {
				speed = maxSpeed;
			Flip();
		}
	}
	
	void StopRunning(){
		speed = 0;		
	}
	
	void CheckFlip(){
		if (!facingRight && speed > 0 || facingRight && speed < 0)
			speed *= -1;
	}
	
	void Flip(){
		facingRight = !facingRight;
		// rotate 180 degrees
		this.transform.RotateAround (Vector3.up, Mathf.PI);
	}
}
