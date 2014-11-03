using UnityEngine;
using System.Collections;

public class ScientistSummonAI : MonoBehaviour {

	public Transform target;
	public Transform source;
	public GameObject projectilePrefab;
	
	readonly float SHOOT_FORCE = 200;
	readonly float SHOOT_VELOCITY = 2.5f;
	readonly float SUMMON_LIFE_TIME = 2.5f;
	
	Animator anim;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating ("ShootProjectile", 0, 2);
		anim = GetComponent<Animator>();
		if (target == null ){
			target = GameObject.Find ("Emmalyn").transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void ShootProjectile(){
		float posX = transform.position.x - target.position.x;
		float posY = transform.position.y - target.position.y;
		
		float shotAngle = Mathf.Atan (posY/posX);
		
		GameObject projectile = Instantiate (projectilePrefab) as GameObject;
		projectile.transform.position = source.position;
		
		projectile.rigidbody2D.velocity = (target.position - source.position).normalized * SHOOT_VELOCITY;
		
		Invoke ("DestroySummon", SUMMON_LIFE_TIME);
	}
	
	void DestroySummon(){
		anim.SetBool("dying", true);
		Destroy (gameObject, 1f);
		
	}
}
