using UnityEngine;
using System.Collections;

public class PlayerTakeDamage : MonoBehaviour {

	PlayerHealth playerHealth;
	
	// Use this for initialization
	void Start () {
		playerHealth = gameObject.GetComponent<PlayerHealth>();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "bullet(Clone)"){
			playerHealth.ReduceHealth(1);
		}
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.name == "bullet(Clone)"){
			playerHealth.ReduceHealth(1);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
