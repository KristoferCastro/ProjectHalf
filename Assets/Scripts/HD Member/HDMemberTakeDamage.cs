using UnityEngine;
using System.Collections;

public class HDMemberTakeDamage : MonoBehaviour {
	
	Animator anim;
	HDMemberHealth healthScript;
	// Use this for initialization
	void Start () {
		anim = GetComponentInParent<Animator>();
		healthScript = GetComponentInParent<HDMemberHealth>();
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "demon2 summon" || other.name == "GoodDemonProjectile(Clone)"){
			anim.SetBool ("getting hit", true);
			
			if (other.name == "demon2 summon")
				healthScript.health -= 1;
			else
				healthScript.health -= 1;
		}
		
		// this one stuns or damage depending on goodness
		if (other.name == "DemonChargeEffect(Clone)"){
			anim.SetBool ("stunned", true);
			gameObject.GetComponentInParent <HDMemberAI>().stunned = true;
			Destroy (other.gameObject);
			Invoke ("StopStun", 4f);
		}
	}
	
	void StopStun(){
		anim.SetBool ("stunned", false);
		gameObject.GetComponentInParent <HDMemberAI>().stunned = false;
		
	}
	
	void OnTriggerExit2D(Collider2D other){
		if (other.name == "demon2 summon" || other.name == "GoodDemonProjectile(Clone)" ){
			anim.SetBool ("getting hit", false);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
