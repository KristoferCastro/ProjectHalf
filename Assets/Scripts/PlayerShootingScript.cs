using UnityEngine;
using System.Collections;

public class PlayerShootingScript : MonoBehaviour {


	float shootForce;
	float shootForceChargeRate = 300f;
	float maxCharge = 5f;
	
	bool disabled = false;
	
	bool charging = false;
	
	public GameObject projectile;
	
	Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	public void HandleInput(){
		if (disabled) return;
		
		anim.SetBool ("charging", charging);
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			shootForce = 0f;
			charging = true;
		}
		
		if (Input.GetKey (KeyCode.Space) ){
			shootForce += shootForceChargeRate *Time.deltaTime;		
		}
		
		if (Input.GetKeyUp (KeyCode.Space)){
			charging = false;
			projectile = (GameObject) Instantiate (projectile);
			projectile.transform.position = GameObject.Find("player hand R").transform.position;
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
