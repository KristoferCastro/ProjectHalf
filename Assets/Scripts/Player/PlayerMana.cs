using UnityEngine;
using System.Collections;

public class PlayerMana : MonoBehaviour {

	float mana = 1;
	float manaCost;
	float timeAliveCost = .15f;
	float rechargeRate = .25f;
	public UISlider manaSlider;
	
	float numberOfSummons; 
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		DestroySummons();
		
		numberOfSummons = gameObject.GetComponent<PlayerVariables>().numberOfSummons;
		
		if (numberOfSummons > 0){
			mana -= timeAliveCost*numberOfSummons*Time.deltaTime;
		}
		
		if (numberOfSummons <= 0){
			mana += rechargeRate*Time.deltaTime;
			if (mana > 1)
				mana = 1;
			
		}
		
		manaSlider.sliderValue = mana;
		
		UpdatePlayerVariables ();
	}
	
	void DestroySummons(){
		if (mana <= 0){
			GameObject[] summons = GameObject.FindGameObjectsWithTag("Demon Summons");
			foreach (GameObject summon in summons){
			
				Destroy (summon);
				gameObject.GetComponent<PlayerVariables>().numberOfSummons = 0;
			}
		}
	}
	
	void UpdatePlayerVariables(){
		gameObject.GetComponent<PlayerVariables>().mana = mana;
	}
	
	
}
