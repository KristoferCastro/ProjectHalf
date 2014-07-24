using UnityEngine;
using System.Collections;

public class DemonSummonEvilAI : MonoBehaviour {

	public float speed = 1;
	public GameObject playerObject;
	bool facingRight = true;
	Player player;
	// Use this for initialization
	void Start () {
	
		playerObject = GameObject.Find("Emma");
		player = playerObject.GetComponent<Player>();
		
		if (!player.facingRight){
			speed *= -1;
		}
		
		rigidbody2D.velocity = new Vector3(speed, 0, 0);
	}
	
	
	
	// Update is called once per frame
	void Update () {
		FlipCheck();
	}
	
	
	void FlipCheck(){

		if ( (rigidbody2D.velocity.x > 0 && !facingRight)
		    || (rigidbody2D.velocity.x < 0 && facingRight) ){
			Flip ();
		}
	}
	
	void Flip(){
		facingRight = !facingRight;
		// rotate 180 degrees
		this.transform.RotateAround (Vector3.up, Mathf.PI);		
	}
}
