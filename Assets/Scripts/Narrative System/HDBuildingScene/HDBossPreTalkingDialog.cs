using UnityEngine;
using System.Collections;

public class HDBossPreTalkingDialog : BaseDialogue {

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
		b1.AddScriptPiece(new ScriptPieceDecision(subtitle, "(Press 1):    Go to this random room.\n(Press 2):   Go to the laboratory.", null));	
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
		
		
		if(b1.lastDecision == Decision.A)
			Application.LoadLevel("BossBattleBScene");
		else{
			Application.LoadLevel("BossBattleAScene");
		}
		
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
