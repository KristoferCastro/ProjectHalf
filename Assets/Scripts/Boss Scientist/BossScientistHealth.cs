using UnityEngine;
using System.Collections;

public class BossScientistHealth : MonoBehaviour {

	float maxHealth = 10;
	public float health;
	public UISlider healthSlider;

	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	void CheckDead(){
		if (health <= 0){
			PlayerPrefs.SetString("LastLevel", "BossBattleAScene");
			Application.LoadLevel ("BossBattleAScenePostTalking");
		}
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.sliderValue = health/maxHealth;
		CheckDead ();
	}
}
