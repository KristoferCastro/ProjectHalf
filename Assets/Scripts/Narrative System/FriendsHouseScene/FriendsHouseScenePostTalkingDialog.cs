using UnityEngine;
using System.Collections;

public class FriendsHouseScenePostTalkingDialog : BaseDialogue {

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
		SetupCutScenes();
		InitializeGraph();
		SetUpGraph();
		StartCoroutine(PlayGraph());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void SetupCutScenes(){
		cutscene1 = new CutScene(0);
		cutscene2 = new CutScene(1);
		
	}
	
	void InitializeGraph(){
		b1 = new ScriptBranch(this);
		b1a = new ScriptBranch(this);
		b1b = new ScriptBranch(this);
	}
	
	
	void SetUpGraph(){
		head = b1;
		
		b1.left = b1a;
		b1.right = b1b;
		
		SetupB1();
		SetupB1a();
		SetupB2b();
	}
	
	void SetupB1(){
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Breathing Heavily. How do they know where I am every time?", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Coughs. I would never tell you.", colonel));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Give him incentive to tell you.", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Hurt him more?! He looks pretty bad…", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "He'll be fine. ", grados));	                  
		b1.AddScriptPiece (new ScriptPieceDecision(subtitle, "(Press 1):    Push for info\n(Press 2):    H&D to pick him up", emma));
	}
	
	void SetupB1a(){
	/*
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "(Steps on the Colonel)", emma));*/
		b1a.AddScriptPiece(new ScriptPiece(subtitle, null, null, cutscene1));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "Screams", colonel));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "How do they keep finding me?!", emma));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, " …You… You’re a monster…", colonel));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "Harder...", grados));	                  
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "How?!", emma));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "  Screams. The CEO just new! He’s like you… But good… Would always have exact locations about where you were!", colonel));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, " … Tracking? Only a demon could have a power like that…", grados));	                  
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "Where’s the CEO?", emma));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "Screams. At the headquarters…  It’s on Water… Street…", colonel));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "That’s not where the H&D building is! How do I know you’re not lying? ", emma));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "Groans.", colonel));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "You should stop now Emmalyn. He can’t take anymore..", grados));	                  
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "That building's a front...", colonel));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "There we go. Not that hard, right? ….", emma));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "Oh my god, he’s dead…", emma));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "You shouldn’t have pushed him that hard…", grados));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "How was I supposed to know?! You’re the expert in all this! Not me!", emma));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "...", grados));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "So what do we do now? Take him to a hospital?", emma));	
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "It doesn’t matter, H&D will be here soon… Lets go to the headquarters…", grados));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "... Alright… Looks at body. I’m sorry…", emma));		
	}
	
	void SetupB2b(){
	/*
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"I can’t do that to him…", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"Sighs. You can’t really be soft right now.", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"I can be whatever the heck I want right now. We just went through a lot.", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"H&D helplines… uses phone. Hey, tell your boss the demon lady thinks he should pick up the Colonel. He’s not looking too hot. Hangs up. Lets go.", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle,": Wait… why don’t we wait to see who picks him up? They could lead us right to the person behind all this.", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"Right.", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"(they hide in bushes, some time passes)", null));
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"(Car comes, picks up Colonel, drives off)", null));
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"Follow them.", grados));
	*/
		b1b.AddScriptPiece(new ScriptPiece(subtitle, null, null, cutscene2));
	/*	
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"(Car comes, picks up Colonel, drives off)", null));*/
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"(car stopping, people helping the Colonel out. Man walks out of the building)", null));
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"Whoa! That’s the CEO! What are they doing here? This isn’t the H&D headquarters…", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"Good thing we followed our intuition! … Huh… Something’s not right about the CEO…", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"What?", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"I get a funny feeling from him...", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle,".… Is it… Love?", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"No! Why would you ever think…", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle,"Calm down, can’t a gal make a joke during these hard times? Lets go.", emma));
				
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
		
		Application.LoadLevel("HDBuildingScenePreTalking");
		
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
