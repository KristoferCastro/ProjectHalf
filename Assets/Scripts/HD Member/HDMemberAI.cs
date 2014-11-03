using UnityEngine;
using System.Collections;

public class HDMemberAI : MonoBehaviour {

	protected float maxSpeed = -2;
	protected float speed = -2;
	protected Animator anim;
	
	public GameObject bulletPrefab;
	public GameObject shootingEffect;
	public Transform shootSource;
	public GameObject player;
	
	protected float fireRate = 0.25f;
	protected float fireSpeed = 4f;
	protected float fireWait = 2f;
	protected float bulletPerRound = 3;
	
	protected bool facingLeft = true;
	
	public bool shooting = false;
	public bool punching = false;
	public bool stunned = false;
	
	GameObject shootingEffectClone;
	
	public AudioClip shootSounds;
	
	// Use this for initialization
	protected void Start () {
		
		GameDirector.instance.IncreaseTotalMembers(1);
	
		if(player == null){
			player = GameObject.Find("Emmalyn") as GameObject;
		}
		
		if (shootSource == null){
			shootSource = player.transform;
		}
		
		anim = GetComponent<Animator>();
		anim.SetFloat("speed", speed);
		StopRunning ();
		shootingEffectClone = (GameObject) Instantiate(shootingEffect);
		shootingEffectClone.SetActive (false);
	
		//StartCoroutine("ShootBullets");
	}
	
	// Update is called once per frame
	protected void Update () {
		transform.rigidbody2D.velocity = Vector2.right*speed;
		UpdateAnimations();
		if (!shooting && (int) Time.time%3 == 0 ){// && Random.Range(0,100) < 50){
			StartCoroutine("ShootBullets");
		}
	}
	
	IEnumerator ShootBullets(){
		PlayShootSounds();
		shooting = true;
		punching = false;
		yield return new WaitForSeconds(fireRate);
		shootingEffectClone.SetActive(true);
		shootingEffectClone.transform.position = shootSource.position;	
		
		// flip the shooting thing too
		if (!facingLeft && fireSpeed < 0)
			shootingEffectClone.transform.RotateAround (Vector3.up, Mathf.PI);
				
		for(int i = 0; i < bulletPerRound; i++){
			GameObject bullet = (GameObject) Instantiate(bulletPrefab);
			bullet.transform.position =  new Vector2(shootSource.position.x, shootSource.position.y);
			
			// flip the bullet direction when necessary
			if (facingLeft && fireSpeed > 0 || !facingLeft && fireSpeed < 0)
				fireSpeed *=-1;
				
			bullet.rigidbody2D.velocity = Vector2.right * fireSpeed;
			
			yield return new WaitForSeconds(fireRate);
		}
		shooting = false;
		shootingEffectClone.SetActive(false);	
		yield return new WaitForSeconds(fireWait);	
	}
	
	void PlayShootSounds(){
		audio.Stop ();
		audio.clip = shootSounds;
		audio.Play ();
	}
	
	protected void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Wall"){
			Flip ();
		}
		
	}
	
	protected void Flip(){
		facingLeft = !facingLeft;
		// rotate 180 degrees
		gameObject.transform.RotateAround (Vector3.up, Mathf.PI);
		gameObject.GetComponentInChildren<HDMemberSearchRange>().gameObject.transform.RotateAround(Vector3.up, Mathf.PI);
		speed *= -1;
	}
	
	protected void Punch(bool enabled){
		punching = true;
		shooting = false;
	}
	
	protected void Shoot(bool enabled){
		shooting = true;
		punching = false;
	}
	
	protected void StopRunning(){
		speed = 0;
		anim.SetFloat ("speed", speed);
	}
	
	protected void UpdateAnimations(){
		anim.SetBool ("punching", punching);	
		anim.SetBool ("shooting", shooting);
		
	}
	public void StartRunning(){
		speed = -maxSpeed;
		if (punching){
			speed *= 1.75f;
		}
		if (facingLeft)
			speed*=-1;
	}
	
}
