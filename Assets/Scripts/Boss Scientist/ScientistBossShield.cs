using UnityEngine;
using System.Collections;

public class ScientistBossShield : MonoBehaviour {

	public GameObject deflectionEffect;	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "DemonChargeEffect(Clone)" 
		|| other.gameObject.name == "GoodDemonProjectile(Clone)"
		|| other.gameObject.name == "demon2 summon"
		|| other.gameObject.name == "DemonSummonGood(Clone)"){
			GameObject deflectionEffectClone = Instantiate(deflectionEffect) as GameObject;
			deflectionEffectClone.transform.position = other.transform.position;
			GameObject.Destroy(deflectionEffectClone, deflectionEffectClone.GetComponentInChildren<ParticleSystem>().duration + deflectionEffectClone.GetComponentInChildren<ParticleSystem>().startLifetime);
			Destroy(other.gameObject);
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
