using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerHealth : MonoBehaviour {

	public UISlider healthBar;
	readonly float MAXHEALTH = 30;
	public float health; 
	PlayerVariables playerV;
	public AudioClip playerHitSound;
	
	Animator anim;
	// Use this for initialization
	void Start () {
		playerV = gameObject.GetComponent<PlayerVariables>();
		health = MAXHEALTH;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.sliderValue = health/MAXHEALTH;
		playerV.health = health;
	}
	
	void ResetHealth(){
		health = MAXHEALTH;
	}
	
	public void ReduceHealth(float number){
		health -= number;
		audio.PlayOneShot(playerHitSound);
		anim.SetBool ("getting hit", true);
		Invoke ("StopGettingHitAnimation", 1);
	}
	
	public void StopGettingHitAnimation(){
		anim.SetBool ("getting hit", false);
	}
	
	
}
