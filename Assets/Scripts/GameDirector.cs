using UnityEngine;
using System.Collections;

public class GameDirector : MonoBehaviour {

	public static GameDirector instance;
	
	// TO-DO: This is not being used yet, refractor code to use this for easy maintenance
	public enum Screen{MAIN_MENU, INTRO_CUT_SCENE, INTRO_LEVEL, LEVELA, GAME_OVER};
	
	public Screen currentScreen; 
	public Screen previousScreen;
	
	public Hashtable globalVariables;

	// Use this for initialization
	void Start () {
		currentScreen = Screen.MAIN_MENU;
		InitializeGlobalVariables();
		
	}
	
	void Awake(){
		if (!instance){
			instance = this;
			InitializeGlobalVariables();
			DontDestroyOnLoad(gameObject);
		}else{
			Destroy (gameObject);
		}
	}
	
	public Hashtable GetVariables(){
		if (globalVariables == null){
			InitializeGlobalVariables();
		}
		return globalVariables;
	}
	
	void InitializeGlobalVariables(){
		globalVariables = new Hashtable();
		globalVariables.Add(PlayerPrefVariables.GOOD_COUNT, 0);
		globalVariables.Add(PlayerPrefVariables.BAD_COUNT, 0);
		globalVariables.Add(PlayerPrefVariables.KILL_COUNT, 0);
		globalVariables.Add(PlayerPrefVariables.TOTAL_MEMBERS, 0);	
	}
	
	public void IncreaseGoodCount(){
		globalVariables[PlayerPrefVariables.GOOD_COUNT] = (int) globalVariables[PlayerPrefVariables.GOOD_COUNT] + 1 ;
	}
	
	public int GetGoodCount(){
		return (int) globalVariables[PlayerPrefVariables.GOOD_COUNT];
	}
	
	public int GetBadCount(){
		return (int) globalVariables[PlayerPrefVariables.BAD_COUNT];
	}
	
	public void IncreaseBadCount(){
		globalVariables[PlayerPrefVariables.BAD_COUNT] =(int) globalVariables[PlayerPrefVariables.BAD_COUNT] + 1;
	}
	
	public bool KilledTooMuch(){
		return (int)globalVariables[PlayerPrefVariables.KILL_COUNT] >= (int)globalVariables[PlayerPrefVariables.TOTAL_MEMBERS]/2;
	}
	
	public void IncreaseTotalMembers(int byN){
		
		globalVariables[PlayerPrefVariables.TOTAL_MEMBERS] = (int) globalVariables[PlayerPrefVariables.TOTAL_MEMBERS] + byN;
		Debug.Log ("Total Enemy Now: " + (int) globalVariables[PlayerPrefVariables.TOTAL_MEMBERS]);
	}
	
	public void IncreaseKillCount(int byN){
		globalVariables[PlayerPrefVariables.KILL_COUNT] = (int) globalVariables[PlayerPrefVariables.KILL_COUNT] + byN;
		Debug.Log ("Kill Count: " + (int) globalVariables[PlayerPrefVariables.KILL_COUNT]);
		           
	}
	
	public int GetTotalEnemyEncountered(){
		return (int) globalVariables[PlayerPrefVariables.TOTAL_MEMBERS];
	}
	
	public int GetKillCount(){
		return (int) globalVariables[PlayerPrefVariables.KILL_COUNT];
	}
	
	public bool GoodDominant(){
		if (PercentageOfGood() >= PercentageOfBad()){
			return true;
		}
		return false;
	}
	
	public float PercentageOfGood(){
		int goodCount = (int)globalVariables[PlayerPrefVariables.GOOD_COUNT];
		int badCount = (int) globalVariables[PlayerPrefVariables.BAD_COUNT];
		if ((goodCount + badCount) == 0)
			return 100;
		return (goodCount/(goodCount+badCount))*100;
	}
	
	public float PercentageOfBad(){
		int goodCount = (int) globalVariables[PlayerPrefVariables.GOOD_COUNT];
		int badCount = (int) globalVariables[PlayerPrefVariables.BAD_COUNT];
		if ((goodCount + badCount) == 0)
			return 0;
		return (badCount/(goodCount+badCount))*100;
	}
	
	public void ChangeState(Screen state){
		previousScreen = currentScreen;
		currentScreen = state;
		processState(state);
	}
	
	private void processState(Screen state){
		switch(state){
			case Screen.MAIN_MENU : {
				Application.LoadLevel ("MainMenu");
				break;
			}
			case Screen.LEVELA : {
				Application.LoadLevel("LevelA");
				break;
			}
			case Screen.INTRO_CUT_SCENE :{
				Application.LoadLevel ("IntroCutScene");
				break;
			}
			case Screen.INTRO_LEVEL : {
				Application.LoadLevel("IntroScene");
				break;
			}
			case Screen.GAME_OVER : {
				Application.LoadLevel ("GameOverScene");
				break;
			}
			default : 
				break;
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	/*
		if (Input.GetKeyDown (KeyCode.F1)){
			ChangeState (Screen.MAIN_MENU);
		}
	*/
	}
}
