using UnityEngine;
using System.Collections;

public class PlayerVariables : MonoBehaviour {

	public float health = 20;
	public float mana = 1;
	public int numberOfSummons = 0;
	public float demonicLevel = 50; 
	
	//public float goodCount = 0;
	//public float badCount = 0;
	
	public enum Summon{Good,Evil, None}
	
	public Summon currentSummon;
	
	// Use this for initialization
	void Start () {
		currentSummon = Summon.None;
		/*
		if (GameDirector.instance != null){
			//update variables
			goodCount = GameDirector.instance.goodCount;
			badCount = GameDirector.instance.badCount;
		}
		
		goodCount = PlayerPrefs.GetInt(PlayerPrefVariables.GOOD_COUNT);
		badCount = PlayerPrefs.GetInt(PlayerPrefVariables.BAD_COUNT);
		*/
	}
	
	public float PercentageOfGood(){
		/*
		if ((goodCount + badCount) == 0)
			return 100;
		return (goodCount/(goodCount+badCount))*100;
		*/
		return GameDirector.instance.PercentageOfGood();
	}
	
	public float PercentageOfBad(){
	/*
		if ((goodCount + badCount) == 0)
			return 0;
		return (badCount/(goodCount+badCount))*100;
		*/
		return GameDirector.instance.PercentageOfBad();
	}
	
	public void IncreaseGoodness(){
		GameDirector.instance.IncreaseGoodCount();
		//goodCount += 1;
		//GameDirector.instance.goodCount +=1;
	}
	
	public void IncreaseBadness(){
		GameDirector.instance.IncreaseBadCount();
		//badCount += 1;
		//GameDirector.instance.badCount += 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Tab)){
			if (currentSummon == Summon.Good)
				currentSummon = Summon.Evil;
			else if(currentSummon == Summon.Evil) {
				currentSummon = Summon.None;
			}else{
				currentSummon = Summon.Good;
			}
		}
	}
}
