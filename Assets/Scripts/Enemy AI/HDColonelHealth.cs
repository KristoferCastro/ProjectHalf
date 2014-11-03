using UnityEngine;
using System.Collections;

public class HDColonelHealth : HDMemberHealth {

	public UISlider healthbar;
	
	public float maxHealth = 20;
	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		healthbar.sliderValue = health/maxHealth;
			
	}
}
