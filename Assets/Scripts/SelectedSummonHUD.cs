using UnityEngine;
using System.Collections;

public class SelectedSummonHUD : MonoBehaviour {

	public SpriteRenderer goodSummon;
	public SpriteRenderer badSummon;
	
	public PlayerVariables playerV;
	
	bool developerMode = false;
	
	float unselectedAlpha = 0.4f;
	
	// Use this for initialization
	void Start () {
		UnSelectedGoodSummon ();
		UnSelectedEvilSummon ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (developerMode == false){
			if (playerV.PercentageOfGood() >= playerV.PercentageOfBad()){
				SelectedGoodSummon();
				UnSelectedEvilSummon();
			}
			else{
				SelectedEvilSummon();
				UnSelectedGoodSummon();
			}
		}
		else{
			if(Input.GetKeyUp (KeyCode.Tab)){
				
				if(playerV.currentSummon == PlayerVariables.Summon.Evil){
					UnSelectedGoodSummon();
					SelectedEvilSummon();
				}
				
				else if(playerV.currentSummon == PlayerVariables.Summon.Good){
					SelectedGoodSummon();
					UnSelectedEvilSummon();
				}else{
					UnSelectedGoodSummon();
					UnSelectedEvilSummon();
				}
			}
		}	
		
		if (Input.GetKeyDown(KeyCode.M)){
			developerMode = true;
		}
	}
	
	void UnSelectedGoodSummon(){
		goodSummon.color = new Color(goodSummon.color.r, goodSummon.color.g, goodSummon.color.b, unselectedAlpha);
		
	}
	
	void UnSelectedEvilSummon(){
		badSummon.color = new Color(badSummon.color.r, badSummon.color.g, badSummon.color.b, unselectedAlpha);
		
	}
	
	void SelectedGoodSummon(){
		goodSummon.color = new Color(goodSummon.color.r, goodSummon.color.g, goodSummon.color.b, 1);
		playerV.currentSummon = PlayerVariables.Summon.Good;	
	}
	
	void SelectedEvilSummon(){
		badSummon.color = new Color(badSummon.color.r, badSummon.color.g, badSummon.color.b, 1);
		playerV.currentSummon = PlayerVariables.Summon.Evil;	
		
	}
	
	
}
