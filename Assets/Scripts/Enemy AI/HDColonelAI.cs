using UnityEngine;
using System.Collections;

public class HDColonelAI : HDMemberAIIntro {
	
	// Use this for initialization
	void Start () {
		base.Start ();
		InvokeRepeating ("RandomShoot", 0, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		//base.Update();
		UpdateAnimations();
		if (health.health <= 0){
			anim.SetBool ("dying", true);
			punching = false;
			Invoke ("NextScene", 2.5f);
			return;
		}
		
		if (shooting){
			return;
		}
		if (speed != 0)
			punching = true;
			
		FacePlayerAllTimes();
		RunTowardsPlayer();
		transform.rigidbody2D.velocity = Vector2.right*speed;
		anim.SetFloat("speed", Mathf.Abs(speed));
		
	}
	
	public void RandomShoot(){
		float random = Random.Range (0, 10);
		
		if (random < 9){
			ShootWhenInRange ();
		}
	}
	
	void NextScene(){
		Application.LoadLevel("FriendsHouseScenePostTalking");
	}
}
