using UnityEngine;
using System.Collections;

public class DemonicBlastDeath : MonoBehaviour {

	public PlayerHealth playerHealth;
	GameObject player;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 8f);
		player = GameObject.Find("Emmalyn");
		if (playerHealth == null){
			playerHealth = player.GetComponent<PlayerHealth>();
		}
	}
	
	void OnCollisionEnter2D(Collision2D other){		
		if (other.gameObject.name == "Emmalyn"){

			playerHealth.ReduceHealth(1);
			Destroy (gameObject);
		}
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
