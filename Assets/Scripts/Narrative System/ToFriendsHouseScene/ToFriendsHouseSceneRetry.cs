using UnityEngine;
using System.Collections;

public class ToFriendsHouseSceneRetry : MonoBehaviour {

	PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find("Emmalyn").GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth.health <= 0){
			PlayerPrefs.SetString("LastLevel", "ToFriendsHouseScene");
			Application.LoadLevel("GameOverScene");
		}
	}
}
