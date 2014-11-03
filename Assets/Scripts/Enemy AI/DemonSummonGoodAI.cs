using UnityEngine;
using System.Collections;

public class DemonSummonGoodAI : MonoBehaviour {

	public GameObject projectile;
	float speed;
	float fireRate = 0.5f;
	float fireVelocity = 5f;
	
	PlayerController player;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating ("FireShots", 0, fireRate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FireShots(){
		GameObject shot = (GameObject) Instantiate(projectile);
		shot.transform.position = new Vector2(transform.position.x, transform.position.y + 0.25f);
		shot.rigidbody2D.velocity = Vector2.right*fireVelocity;
	}
	
	public void Flip(){
		// rotate 180 degrees
		this.transform.RotateAround (Vector3.up, Mathf.PI);	
		fireVelocity *= -1;	
	}
}
