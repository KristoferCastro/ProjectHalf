using UnityEngine;
using System.Collections;

public class HDBuildingScenePreTalkingDialog : BaseDialogue {

	// dialogue game objects
	public GameObject playerPicture;
	public GameObject gradosPicture;
	public GameObject colonelPicture;
	
	Talking emma;
	Talking grados; 
	Talking colonel;
	
	CutScene cutscene1;
	CutScene cutscene2;
	
	ScriptBranch head;
	ScriptBranch b1;
	ScriptBranch b1a;
	ScriptBranch b1b;
	
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
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Emma: So what’s our plan?", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "We should navigate the building, search for information on the CEO and find out exactly how we’re being tracked.", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Right, and info on what they know about your world and if they have any idea how to split us.", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Correct. We have two ways of doing this, sneaking through the building and causing as little damage as possible or we could prevent our presence from being known through force. ", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "He'll be fine. ", grados));	                  
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Right, and I guess that’s up to me. Onward and upward. ", emma));	
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
		
		Application.LoadLevel("HDBuildingScene");
		
		yield return null;
	}
	
	protected override void SetUpDictionary(){
		base.SetUpDictionary();
		emma = new Talking("EMMA");
		grados = new Talking("GRADOS");
		colonel = new Talking("COLONEL");
		
		talkers.Add (emma, playerPicture);
		talkers.Add (grados, gradosPicture);
		talkers.Add (colonel, colonelPicture);
	}
}
