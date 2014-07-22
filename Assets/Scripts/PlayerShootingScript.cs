using UnityEngine;
using System.Collections;

public class PlayerShootingScript : MonoBehaviour {


	float shootForce;
	float shootForceChargeRate = 300f;
	float maxCharge = 5f;
	
	bool disabled = false;
	
	bool charging = false;
	
	public GameObject projectile;
	public GameObject chargeEffect;
	public GameObject demonHand;
	
	GameObject chargeEffectClone;
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
			chargeEffectClone.SetActive(false);
			projectile = (GameObject) Instantiate (projectile);
			projectile.transform.position = demonHand.transform.position;
			projectile.rigidbody2D.AddForce(Vector2.right*shootForce);
			// release
			Debug.Log (shootForce);
		}
		
		//Debug.Log (shootForce);
	} 
	
	// Update is called once per frame
	void Update () {
		HandleInput ();
	}
}
