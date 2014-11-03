using UnityEngine;
using System.Collections;

public class HDColonelDoDamage : MonoBehaviour {

		PlayerHealth playerHealth;
	
	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find("Emmalyn").GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Emmalyn"){
			playerHealth.ReduceHealth(1);
		}
	}
}
