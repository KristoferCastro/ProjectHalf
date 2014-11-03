using UnityEngine;
using System.Collections;

public class HDMemberAIIntro : HDMemberAI {

	
	public GameObject searchRadar;
	public HDMemberSearchRange searchRadarScript;
	public HDMemberHealth health;
	// Use this for initialization
	protected void Start () {
		base.Start ();	
		searchRadarScript = searchRadar.GetComponent<HDMemberSearchRange>();
		health = GetComponent<HDMemberHealth>();
		health.health = 12;
	}

	
	// Update is called once per frame
	protected void Update () {
		UpdateAnimations();
		if (health.health <= 0){
			anim.SetBool ("dying", true);
			return;
		}
		
		FacePlayerAllTimes();
		RunTowardsPlayer();
		transform.rigidbody2D.velocity = Vector2.right*speed;
		anim.SetFloat("speed", Mathf.Abs(speed));
		
		ShootWhenInRange();		
	}

	
	protected void FacePlayerAllTimes(){
		if (player.transform.position.x > gameObject.transform.position.x){
			// player on the right side
			if (facingLeft){
				Flip ();
			}	
		}
		
		if (player.transform.position.x < gameObject.transform.position.x){
			// player on the left side
			if (!facingLeft){
				Flip ();
			}
		}
	}
	
	// Run towards player if not in range, stop when in range
	protected void RunTowardsPlayer(){
		if (!searchRadarScript.foundPlayer && !stunned && !shooting){
			StartRunning();
		}else{
			StopRunning();
		}
	}
	
	protected void ShootWhenInRange(){
		if (!shooting && !stunned && speed == 0 && searchRadarScript.foundPlayer){
			StartCoroutine("ShootBullets");
		}
	}
}
