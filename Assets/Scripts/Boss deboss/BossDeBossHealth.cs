using UnityEngine;
using System.Collections;

public class BossDeBossHealth : MonoBehaviour {

	float maxHealth = 25;
	public float health;
	public UISlider healthSlider;
	
	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.sliderValue = health/maxHealth;
		CheckIfDead ();
		
	}
	
	void CheckIfDead(){
		if (health <= 0){
			PlayerPrefs.SetString("LastLevel", "BossBattleBScene");
			Application.LoadLevel("BossBattleBScenePostTalking");
		}
	}
}
