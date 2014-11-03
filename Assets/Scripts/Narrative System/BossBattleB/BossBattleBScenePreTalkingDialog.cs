using UnityEngine;
using System.Collections;

public class BossBattleBScenePreTalkingDialog : BaseDialogue {

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
		SetupB2 ();
	}
	
	void SetupB1(){
		b1.AddScriptPiece(new ScriptPiece(subtitle, " Phew, we made it to… the laboratory?", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "There’s no use of us being here, let’s go.", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "C’mon bossy britches, let’s look around. Maybe there’s something.", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "(Whistles). Holy cow, what a lot of filing cabinets…. And no computer! Well, this makes it easy on us! Guess they don’t want hackers getting their stuff..", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "(Forces cabinet open with pure strength)", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "You should have checked for an alarm system….", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Oh Satan you big baby. They think this place is completely unknown, they aren’t worried about people getting some files… Lets see, what should we search first? ", emma));	                  
		b1.AddScriptPiece(new ScriptPieceDecision(subtitle, "(Press 1):    dimensions\n(Press 2):    demons", null));	
	}
	
	void SetupB1a(){
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "Whoa! Page one they just start talking about demons! Hum… Math, math, math, boring stuff…", emma));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "I’m glad I’m getting that down, can’t trust anything important with you.", grados));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "Well, I wouldn’t trust you to walk in a straight line. Take one step and you woul accidently merge with another hot girl!", emma));	
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "(Embarrassed) Look at the section under New Mexico..", grados));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "They know how to interact with your dimension! Huh… They’ve done it a couple times… ", emma));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "Wow, every time it’s used a tonne of energy. That can’t be helping out this whole situation…", emma));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "No, i would only unbalance the planets more…", grados));	
	}
	
	void SetupB1b(){
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "Alright, Demons… Weird... It’s talking more about the vaccine than actual demons… It says that the vaccine was synthesize from something from the demon world! ", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "Emmalyn. I am perfectly able to read.", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "Just making sure you can keep up with me Satan.", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, " But yes, we do have something like that on our planet. We’re immunized as young demons to prevent from passing on too quickly", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, " If we didn’t it would cause the cycle of rebirth too quickly.", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "So it was made, semi permanent,  for healthy demons That’s why this… Prometheus effect… Oh my gosh.", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "...If the subject has experienced some sort of trauma within a period of two months before taking the vaccine, there is a high chance the cells will revert to their injured state cyclically… This cannot be reversed…", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "(Sniffs, crying.)", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "Oh! Um… This isn’t really the time for that…", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "I know…", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "Why are you crying?", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "It’s just, I’ve been so… so… mad... Pretty soon after the vaccine came out my parents were attack by a mentally ill person.", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, " I know it wasn’t their fault and it would have happened to anyone but… They wouldn’t fix them.. ", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "The doctors wouldn’t give them the vaccine saying that the paperwork had to be filled out…", emma));	
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "All these excuses that didn’t make sense since the vaccine ads made it seem like some miracle cure they were throwing at anyone...", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "So they died before I could help them. I always wondered why the doctor just took so much of the abuse I threw at him after they died...", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "They knew it would cause this… ", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "Yeah, and as it says here they would have been forcefully removed from society… Forced to suffer, in pain, alone... How can they be this inhuman?", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "… because there’s some inhuman demon… Satan... power going on here?", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "(Laughs) I knew you had a sense of humor…", emma));
	}
	
	void SetupB2(){
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Oh, you’re here.", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Bernhard! You incomprehensible jerk!", emma));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "So you are half demon… Shows powers. That’s good, we’ll be evenly matched…", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "What?!", emma));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "What?!", grados));	
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Yes. Bit of an accident, was attempting alternative methods of dimensional access and I succeeded in intercepting an incoming demon and moved it to my coordinates where we merged.", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "And… You’re still merged?", emma));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "No, I disconnected. ", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Why are you working here then?", emma));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Access. Any scientific material, implementing any scientific method, making a name for myself, doing anything I wish…", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Rules are put in place for a reason! You can’t just mess with beings or dimensions like this! Do you realize what you’re doing to the balance of the…", grados));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Look at that, you can talk outside of her body. Gaining more power are we? Tsk tsk. You know that only makes it harder to separate?", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "I barely used my demons powers and it nearly killed us to be separated… And yes, the balance issue. Inconsequential.", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "I don’t give a flying frick if you died. For everything you’ve done, I hope you die!", emma));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Oh, child. I know about your lack of concern with death, look at what a blood trail you’ve left behind you.", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "While you’re struggling to get by, barely living,  I’m at the peak; ultimate control of the world, dimensions!", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "(…Looks guilty)", emma));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Even then, I don’t plan on living forever, and those fools who wish to can deal with it gloal warming.", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Exponential development of psychological problems, joblessness, starvation without dying, seeing the same faces forever? ", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "They all come with living forever and conceptually I wouldn’t wish it on my worst enemy but it has also give me everything… Laughs What a paradox…", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "You don’t shut up do you, you egomaniac? One question, why tell us all this?", emma));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Well, I’m supposed to offer you a position to work with us… CEO Chranac told me to tell you everything to convince you, are you interested?", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "No.", emma));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Not on your ever shortening life.", emma));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Fine by me, let’s end this shall we?", emma));
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
		
		Application.LoadLevel("BossBattleAScene");
		
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
