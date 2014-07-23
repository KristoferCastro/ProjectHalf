using UnityEngine;
using System.Collections;

public class DemonicProjectile : MonoBehaviour {

	public GameObject demonSummon;
	
	public LayerMask whatIsGround;
	
	public GameObject summonEffect;
	
	GameObject summonEffectClone;
	
	// Use this for initialization
	void Start () {
		summonEffectClone = null;
	}
	
	void OnCollisionEnter2D(Collision2D other){
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "Ground"){
		
			GameObject existingSummon = GameObject.Find ("Demon Summon Evil(Clone)");
			if (existingSummon != null){
				Destroy (existingSummon);
			}
			
			GameObject summonEffectExist = GameObject.Find("Summon Effect(Clone)");
			if (summonEffectExist){
				Destroy (summonEffectExist);
			}
			summonEffectClone = (GameObject) Instantiate (summonEffect, transform.position, Quaternion.identity);
			Instantiate(demonSummon, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
			Destroy(this.gameObject);	
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
