using UnityEngine;
using System.Collections;

public class BossScientistAI : MonoBehaviour {

	//speed summoning blocking

	float maxSpeed = 4f;
	float summonSpeed = 2f;
	bool facingRight;
	public float speed;
	
	public bool summoning;
	public bool blocking;
	Animator anim;
	
	readonly float CHANCE_TO_SUMMON = 60f;
	readonly float CHANGE_MOVEMENT_INTERVAL = 2f;
	readonly float CHARGE_CAST_TIME = 2.85f;
	readonly float SHOOT_FORCE = 400;
	public GameObject shield;
	// effects
	public GameObject demonicBlastPrefab;
	public GameObject bossDemonHand;
	GameObject demonicBlastClone;
	
	// Use this for initialization
	void Start () {
		facingRight = true;
		blocking = true;
		anim = GetComponent<Animator>();
		speed = maxSpeed;
		InvokeRepeating ("RandomMovement", 0,  CHANGE_MOVEMENT_INTERVAL); 
		InvokeRepeating ("SummonUnits", 3, 9);
	}
	
	// Update is called once per frame
	void Update () {
		UpdateDemonicBlastPosition ();
		UpdateAnimator ();	
		UpdateShield();
		CheckFlip ();	
	}

	void UpdateAnimator(){	
		gameObject.rigidbody2D.velocity = Vector2.right*speed;
		anim.SetBool("summoning", summoning);
		anim.SetBool("blocking", blocking);
		anim.SetFloat ("speed", Mathf.Abs(speed));
	}
	
	void UpdateDemonicBlastPosition(){
		if (demonicBlastClone != null && demonicBlastClone.GetComponent<ScientistDemonBall>().startExplosionTimer != true)
			demonicBlastClone.transform.position = bossDemonHand.transform.position;
	}
	
	void SummonUnits(){
		speed = summonSpeed;
		if (demonicBlastClone != null)
			return;
		// summon units
		// disable shield while summoning
		summoning = true;
		blocking = false;
		demonicBlastClone = Instantiate(demonicBlastPrefab) as GameObject;
		
		Invoke ("ShootRandomlyInTheAir", CHARGE_CAST_TIME);
	}
	
	void ShootRandomlyInTheAir(){
		demonicBlastClone.GetComponent<ScientistDemonBall>().startExplosionTimer = true;
		Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(-65, 65));
	   	Vector3 direction = rotation * Vector3.up * SHOOT_FORCE;
		demonicBlastClone.rigidbody2D.AddForce(direction);
		summoning = false;
		blocking = true;
	}
	
	void UpdateShield(){
		if(blocking){
			shield.SetActive(true);
		}else{
			shield.SetActive(false);
		}
	}
	
	void RandomMovement(){
		float randomNumber = Random.Range(0, 100);
		if (randomNumber < 75){
			
			// keep running
			JustRun ();
		}else{
			StopRunning();
		}
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Wall"){
			Flip ();
		}
	}
	
	void JustRun(){
		float flipCoin = Random.Range(0, 10);
		if (flipCoin <= 5) {
			if (summoning)
				speed = summonSpeed;
			else
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
