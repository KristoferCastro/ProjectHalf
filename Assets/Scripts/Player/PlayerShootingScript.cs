using UnityEngine;
using System.Collections;

public class PlayerShootingScript : MonoBehaviour {

	float shootForce;
	float shootForceChargeRate = 475f;
	
	bool disabled = false;
	
	bool charging = false;
	bool shooting = false;
	bool shootingClose = false;
	
	public GameObject projectile;
	public GameObject chargeEffect;
	public GameObject demonHand;
	
	public PlayerController player;
	
	GameObject chargeEffectClone;
	GameObject projectileClone;
	
	Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		
		if (demonHand == null)
			demonHand = GameObject.FindGameObjectWithTag("DemonHand");
	}
	
	public void HandleInput(){
		if (disabled) return;
		
		anim.SetBool ("charging", charging);
		anim.SetBool("shooting", shooting);
		anim.SetBool("shooting close", shootingClose);
		
		
		if (chargeEffectClone != null)
			chargeEffectClone.transform.position = demonHand.transform.position;
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (chargeEffectClone == null)
				chargeEffectClone = (GameObject) Instantiate (chargeEffect);
			else
				chargeEffectClone.SetActive(true);
			shootForce = 0f;
			charging = true;
		}
		
		if (Input.GetKey (KeyCode.Space) ){
			shootForce += shootForceChargeRate *Time.deltaTime;		
		}
		
		if (Input.GetKeyUp (KeyCode.Space)){
			charging = false;
			
			if (shootForce < 100){
				shootingClose = true;
				shootForce += 100;
			}else{
				shooting = true;
			}
			StartCoroutine("ShotDelay");
			if (chargeEffectClone != null)
				chargeEffectClone.SetActive(false);
			projectileClone = (GameObject) Instantiate (projectile, demonHand.transform.position, Quaternion.identity);
			
			if (player.facingRight){
				projectileClone.rigidbody2D.AddForce(Vector2.right*shootForce);
			}
			
			else{
				projectileClone.rigidbody2D.AddForce(Vector2.right*-shootForce);
			}	
		}
		
		//Debug.Log (shootForce);
	}
	 
	IEnumerator ShotDelay(){
		yield return new WaitForSeconds(0.75f);
		DisableShooting();
	}
	
	void DisableShooting(){
		shooting = false;
		shootingClose = false;
	}
	// Update is called once per frame
	void Update () {
		HandleInput ();
	}
}
