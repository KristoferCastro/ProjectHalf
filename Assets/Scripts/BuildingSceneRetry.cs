using UnityEngine;
using System.Collections;

public class BuildingSceneRetry : MonoBehaviour {

	PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find("Emmalyn").GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHealth.health <= 0){
			PlayerPrefs.SetString(PlayerPrefVariables.LAST_LEVEL, "HDBuildingScene");
			Application.LoadLevel("GameOverScene");
		}
	}
}
