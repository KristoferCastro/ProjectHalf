using UnityEngine;
using System.Collections;

public class ToFriendsHouseScenePreTalkingDialog : BaseDialogue {

	// dialogue game objects
	public GameObject playerPicture;
	public GameObject gradosPicture;
	
	Talking emma;
	Talking grados; 
	
	CutScene cutscene1;
	CutScene cutscene2;
	
	ScriptBranch head;
	ScriptBranch b1;
	ScriptBranch b1a;
	ScriptBranch b1b;
	ScriptBranch b2;
	
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
		b1a = new ScriptBranch(this);
		b1b = new ScriptBranch(this);
		b2 = new ScriptBranch(this);
		
	}
	
	void SetUpGraph(){
		head = b1;
		
		b1.left = b1a;
		b1.right = b1b;
		
		b1a.left = b2;
		b1b.left = b2;
		
		SetupB1();
		SetupB1a();
		SetupB1b();
		SetupB2();
	}
	
	void SetupB1(){
		b1.AddScriptPiece(new ScriptPiece(subtitle, "What's the plan now?", grados));
		b1.AddScriptPiece(new ScriptPieceDecision(subtitle, "(Press 1)    None of your business! \n (Press 2)    I'm going to my friends house.", emma));	
	}
	
	void SetupB1a(){
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "So very rude...", grados));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "(Sighs, exasperatedly)", emma));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, " I’m going to my friends. I’ll figure out if I’m not out of my mind there.", emma));
	}
	
	void SetupB1b(){
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "She’ll give us some place to hide and we’ll see if this blows over or figure out what to do.", emma));		
	}
	
	void SetupB2(){
		b2.AddScriptPiece(new ScriptPiece(subtitle, " (Starts walking around in the world, H&D guy notices them and starts to fight.)", null));		
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
		
		Application.LoadLevel("ToFriendsHouseScene");
		
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
