using UnityEngine;
using System.Collections;

public class DeBossDemonicBlast : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject,7);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.name == "Emmalyn"){
			PlayerHealth playerHealth = GameObject.Find(other.gameObject.name).GetComponent<PlayerHealth>();
			playerHealth.ReduceHealth(2);
			Destroy (gameObject);
		}
		if (other.gameObject.tag == "Wall"){
			Destroy (gameObject);
		}
		
	}
}
