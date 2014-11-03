using UnityEngine;
using System.Collections;

public class BossScientistDamage : MonoBehaviour {

	public GameObject player;
	PlayerHealth playerHealth; 
	
	// Use this for initialization
	void Start () {
		playerHealth = player.GetComponent<PlayerHealth>();
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		//Debug.Log ("collided: " + collision.gameObject.name);
		
		if (collision.gameObject.name == "Emmalyn"){
			playerHealth.ReduceHealth(1);
		}
	}
	
	void OnCollisionExit2D(Collision2D collision){
		if (collision.gameObject.name == "Emmalyn"){
			
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		if (playerHealth.health <= 0){
			PlayerPrefs.SetString(PlayerPrefVariables.LAST_LEVEL, "BossBattleAScene");
			Application.LoadLevel ("GameOverScene");
		}
	}
}
