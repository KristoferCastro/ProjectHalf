using UnityEngine;
using System.Collections;

public class BossBattleAScenePostTalking : BaseDialogue {

	// dialogue game objects
	public GameObject playerPicture;
	public GameObject gradosPicture;
	
	Talking emma;
	Talking grados; 
	
	CutScene cutscene1;
	CutScene cutscene2;
	
	ScriptBranch head;
	ScriptBranch b1;
	
	// Use this for initialization
	void Start () {
		DisableMovieCamera();
		SetUpDictionary();
		InitializeGraph();
		SetUpGraph();
		StartCoroutine(PlayGraph());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void InitializeGraph(){
		b1 = new ScriptBranch(this);
	}
	
	void SetUpGraph(){
		head = b1;
		
		SetupB1();
		
	}
	
	void SetupB1(){
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Gasping Just in time, I thought we were in trouble there…", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, " Oh Grados, I had it all under control…", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Would you like the honor of setting this place ablaze kind sir?", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "It would be my pleasure madame!", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "(Run outside, arms full of papers.)", null));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Got the dirt, what next?", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "I say we follow that lead to New Mexico, it seems the most promising if we’re going to try and warn the humans.", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Oh Grados! You amazing softy, thank you! I knew you’d get a liking of humans, I’ll do my best to do stuff your way a little more now.", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Like stay away from mirrors! Maybe grow dreds if you dig them? Seem right up your alley!", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "… Emma, I thought I should let you know… I can be in full control now if I want to… That doesn’t mean I’ll do anything outside of your comfort!", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "I will only over take you when it’s necessary!", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Right-o… Honestly, it’s still a bit weird but you know, we’ll just have to deal with it. Thanks a lot for telling me though...", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "(Laughs)", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Hopefully you won’t start controlling me like I was a part of the ministry of silly walks…", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "… What?", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "(Laughs)", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "We’ll watch that later… Onwards and upwards I say! Thank you Vancouver! It’s been a pleasure!", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Allons-y!", grados));
	}
	
	bool BadDominant(){
		return PlayerPrefs.GetInt(PlayerPrefVariables.BAD_COUNT) > PlayerPrefs.GetInt(PlayerPrefVariables.GOOD_COUNT);
	}
	
	// reusable
	IEnumerator PlayGraph(){
		ScriptBranch currentBranch = head;
		do{
			yield return StartCoroutine(currentBranch.Play(ShowTalker));
			if (currentBranch.lastDecision == Decision.A){
				currentBranch = currentBranch.left;
			}
			else if (currentBranch.lastDecision == Decision.B){
				currentBranch = currentBranch.right;
			}else{
				currentBranch = currentBranch.left;
			}
		}while(currentBranch != null && !currentBranch.IsEmpty());
		
		Application.LoadLevel("EndScene");
		
		yield return null;
	}
	
	protected override void SetUpDictionary(){
		base.SetUpDictionary();
		emma = new Talking("EMMA");
		grados = new Talking("GRADOS");
		
		talkers.Add (emma, playerPicture);
		talkers.Add (grados, gradosPicture);
	}
}
