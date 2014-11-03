using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ToFriendHouseDialogue : BaseDialogue {

	// dialogue game objects
	public GameObject playerPicture;
	public GameObject gradosPicture;

	Talking emma;
	Talking grados; 
	
	CutScene cutscene1;
	CutScene cutscene2;
	
	// Use this for initialization
	void Start () {
		SetUpDictionary ();
		SetUpCutScenes ();
		//StartCoroutine("ScriptBranch1");
		DisableMovieCamera();
	}
	
	protected override void SetUpDictionary(){
		base.SetUpDictionary();
		emma = new Talking("EMMA");
		grados = new Talking("GRADOS");
		
		talkers.Add (emma, playerPicture);
		talkers.Add (grados, gradosPicture);
	}
	
	void SetUpCutScenes(){
		cutscene1 = new CutScene(0);
		cutscene2 = new CutScene(1);
	}
	
	IEnumerator ScriptBranch1(){
		ScriptBranch scriptNode1 = new ScriptBranch(this);
		
		ScriptPiece talk = new ScriptPiece(subtitle, "Grados:    What's the plan now ", grados);
		talk.talkDelay = 2;
		scriptNode1.AddScriptPiece(talk);
		ScriptPieceDecision scriptWithDecision = new ScriptPieceDecision(subtitle,  "(Press 1):    I'm going to my friends house.\n (Press 2):    None of your business", emma, cutscene1, cutscene2);
		scriptNode1.AddScriptPiece(scriptWithDecision);
		yield return StartCoroutine(scriptNode1.Play(ShowTalker));
		
		yield return null;
	}
	
	
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
