using UnityEngine;
using System.Collections;

public class BossBattleBScenePostTalkingDialog : BaseDialogue {

	// dialogue game objects
	public GameObject playerPicture;
	public GameObject gradosPicture;
	public GameObject demonBossPicture;
	
	Talking emma;
	Talking grados; 
	Talking demonBoss;
	
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
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Damn. That was quite the fight… Wanna set fire to the building?", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "If no other reason than spite, yes.", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "(Run outside, arms full of papers.)", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Got the info… Next stop, New Mexico?", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "… I can fully control you now…", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "… What does this mean?", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "… For now, we will go to New Mexico. In all honestly, I have about a year before the resolution must be complete.", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "You have half of that to try your plan. But know I can change my mind at any point!", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Alright, I can deal with that for now! We’re going on a trip! But you know, now that you can control me you still have to respect my rights, a’ight?", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Alright. I have a say in what we eat though.", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Deal. Onwards and upwards! I’ll be back Vancouver!", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Allons-y!", emma));		
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
		demonBoss = new Talking("DEMONBOSS");
		
		talkers.Add (emma, playerPicture);
		talkers.Add (grados, gradosPicture);
		talkers.Add (demonBoss, demonBossPicture);
	}
}
