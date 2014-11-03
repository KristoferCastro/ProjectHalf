using UnityEngine;
using System.Collections;

public class BossScientistTakingDamage : MonoBehaviour {
	
	Animator anim;
	BossScientistHealth bossHealth;

	// Use this for initialization
	void Start () {
		anim = GetComponentInParent<Animator>();
		bossHealth = gameObject.GetComponentInParent<BossScientistHealth>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
	
		if (other.gameObject.name == "demon2 summon" || other.gameObject.name == "GoodDemonProjectile(Clone)"){
			anim.SetBool ("getting hit", true);
			Invoke ("StopGettingHit", 1.5f);
			//Debug.Log ("hitting boss");
			if (other.name == "demon2 summon")
				bossHealth.health -= 3;
			if (other.name == "GoodDemonProjectile(Clone)")
				bossHealth.health -= 1;
		}
		
		// this one stuns or damage depending on goodness
		if (other.gameObject.name == "DemonChargeEffect(Clone)"){
			// stun boss?
		}
	}
	
	void StopGettingHit(){
		anim.SetBool ("getting hit", false);
	}
	
	
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name == "demon2 summon" || other.gameObject.name == "GoodDemonProjectile(Clone)")
			anim.SetBool ("getting hit", false);

		// this one stuns or damage depending on goodness
		if (other.gameObject.name == "DemonChargeEffect(Clone)"){
			// stun boss?
		}
	}
}
