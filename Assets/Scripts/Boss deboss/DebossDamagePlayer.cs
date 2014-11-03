using UnityEngine;
using System.Collections;

public class DebossDamagePlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D enter){
		if (enter.gameObject.name == "Emmalyn"){
			PlayerHealth playerHealth = GameObject.Find("Emmalyn").GetComponent<PlayerHealth>();
			playerHealth.ReduceHealth(1);
		}
	}
}
