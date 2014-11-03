using UnityEngine;
using System.Collections;

public class IntroScrenePreTalking : BaseDialogue {


	// dialogue game objects
	public GameObject playerPicture;
	public GameObject gradosPicture;
	public GameObject hdPicture;
	
	Talking emma;
	Talking grados; 
	Talking hd; 
	
	CutScene cutscene1;
	CutScene cutscene2;
	CutScene cutscene3;
	CutScene cutscene4;
	
	ScriptBranch head;
	ScriptBranch b1;
	ScriptBranch b1a;
	ScriptBranch b1b;
	ScriptBranch b2;
	ScriptBranch b2a;
	ScriptBranch b2b;
	ScriptBranch b2ba;
	ScriptBranch b2bb;
	ScriptBranch b3;
	
	
	// Use this for initialization
	void Start () {
		DisableMovieCamera();
		SetUpDictionary();
		SetUpCutScenes ();
		InitializeGraph();
		SetUpGraph();
		StartCoroutine(PlayGraph());
	}
	
	// Update is called once per frame
	void Update () {
		
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
		
		Application.LoadLevel("IntroScene");
		yield return null;
	}
	
	void InitializeGraph(){

	    b1 = new ScriptBranch(this);
		b1a = new ScriptBranch(this);
		b1b = new ScriptBranch(this);
		b2 = new ScriptBranch(this);
		b2a = new ScriptBranch(this);
		b2b = new ScriptBranch(this);
		b2ba = new ScriptBranch(this);
		b2bb = new ScriptBranch(this);
		b3 = new ScriptBranch(this);
		 
		head = b1;
	}
	
	protected override void SetUpDictionary(){
		base.SetUpDictionary();
		emma = new Talking("EMMA");
		grados = new Talking("GRADOS");
		hd = new Talking("HD");
		
		talkers.Add (emma, playerPicture);
		talkers.Add (grados, gradosPicture);
		talkers.Add (hd, hdPicture);
	}
	
	void SetUpGraph(){
		b1.left = b1a;
		b1.right = b1b;
		
		b1a.left = b2;
		b1b.left = b2;
		
		b2.left = b2a;
		b2.right = b2b;
		
		b2b.left = b2ba;
		b2b.right = b2bb;
		
		b2ba.left = b3;
		b2bb.left = b3;
		
		b2a.left = b3;
		
		SetupBranchB1();
		SetupBranchB1a();
		SetupBranchB1b ();
		SetupBranchB2 ();
		SetupBranchB2a ();
		SetupBranchB2b ();
		SetupBranchB2ba ();
		SetupBranchB2bb ();
		SetupBranchB3 ();
	}
	
	void SetUpCutScenes(){
		cutscene1 = new CutScene(0);
		cutscene2 = new CutScene(1);
		cutscene3 = new CutScene(2);
		cutscene4 = new CutScene(3);
	}
	
	void SetupBranchB1(){		
		b1.AddScriptPiece(new ScriptPiece(subtitle, null, null, cutscene1));
		
		//b1.AddScriptPiece(new ScriptPiece(subtitle, null, null, null));
		
		ScriptPieceDecision scriptWithDecision = new ScriptPieceDecision(subtitle,  "(Press 1):    Ugh, I do not need to hear that.\n(Press 2):    Mmmm, I wonder if a power outage will interupt that.", emma);
		b1.AddScriptPiece(scriptWithDecision);
;
	}
	
	void SetupBranchB1a(){
		b1a.AddScriptPiece(new ScriptPiece(subtitle, null, null, cutscene2));	
	}
	
	void SetupBranchB1b(){
		b1b.AddScriptPiece(new ScriptPiece(subtitle, null, null, cutscene3));
	}
	
	void SetupBranchB2(){
		b2.AddScriptPiece(new ScriptPiece(subtitle, null, null, cutscene4));	
		b2.AddScriptPiece(new ScriptPieceDecision(subtitle, "(Press 1):    ...how did I get to bed?!\n(Press 2):    ...what a weird dream...", emma));			
	}
	
	void SetupBranchB2a(){
		b2a.AddScriptPiece(new ScriptPiece(subtitle, "I helped you to bed!", grados));
		b2a.AddScriptPiece(new ScriptPiece(subtitle, "(Screams) Who the heck was that?!", emma));
		b2a.AddScriptPiece(new ScriptPiece(subtitle, "Oh, you didn't know I was here?", grados));
		b2a.AddScriptPiece(new ScriptPiece(subtitle, "No... Who is this?", emma));
		b2a.AddScriptPiece(new ScriptPiece(subtitle, "...Wha...", emma));
		b2a.AddScriptPiece(new ScriptPiece(subtitle, "It’s quite unfortunate, I teleported to your planet last night but was put on the same spot you were standing. ", grados));
		b2a.AddScriptPiece(new ScriptPiece(subtitle, "So, now I guess we’re temporary roommates! Except closer! Two consciousnesses in one body, have not heard of that happening before! ", grados));
		b2a.AddScriptPiece(new ScriptPiece(subtitle, "Ah yes, I’d appreciate it if you didn’t look into my memories… but anyway! When I accidently merged with you you passed out, so I took your body to bed. That shows that I’m gaining some energy! How promising!", grados));
		b2a.AddScriptPiece(new ScriptPiece(subtitle, "This has to be a fever dream...", emma));
		b2a.AddScriptPiece(new ScriptPiece(subtitle, "I wish it was as well but alas, no...", grados));
	}
	
	void SetupBranchB2b(){
		b2b.AddScriptPiece(new ScriptPiece(subtitle, "(Looks troubled)...I wish I was dreaming about someone hot instead...", emma));
		b2b.AddScriptPiece(new ScriptPiece(subtitle, "I'd rather that as well...", grados));
		b2b.AddScriptPiece(new ScriptPiece(subtitle, "(Shocked)...Hello? Is someone here? (looks around room).  I'm prety sure I locked the door last night!", emma));
		b2b.AddScriptPiece(new ScriptPiece(subtitle, "Yes, I think you did as well and I’d rather you didn’t peek into my memories.", grados));
		b2b.AddScriptPiece(new ScriptPiece(subtitle, "...Peek into… What? Hey I don’t know who you are but you need to get out! ", emma));
		b2b.AddScriptPiece(new ScriptPiece(subtitle, "Wish I could Miss Emmalyn but  I appear to be stuck here. Unless you knew some method of separating us.", grados));
		b2b.AddScriptPiece(new ScriptPieceDecision(subtitle, "(Press 1):    Okay you sick freak, get out of my apartment!\n(Press 2):    What... Who is this?", emma));			
	}
	
	void SetupBranchB2ba(){
		b2ba.AddScriptPiece(new ScriptPiece(subtitle, "Oh, well aren’t you unpleasant. I wish to be stuck in your body as much as you want me here.", grados));
		b2ba.AddScriptPiece(new ScriptPiece(subtitle, "The heck are you talking about freakazoid?", emma));
		b2ba.AddScriptPiece(new ScriptPiece(subtitle, "Now that’s not even clever. Last night I transported to your planet to complete my mission.", grados));
		b2ba.AddScriptPiece(new ScriptPiece(subtitle, "Unfortunately you were standing on the spot where I was teleporting. Knocked you right out…", grados));
		b2ba.AddScriptPiece(new ScriptPiece(subtitle, "I was going to sulk and leave you on the floor but I thought better and was nice enough to control your body to bed.", grados));
		b2ba.AddScriptPiece(new ScriptPiece(subtitle, "(Looking around apartment for a person who could be talking)", emma));
		b2ba.AddScriptPiece(new ScriptPiece(subtitle, "(laughs).  Right, so what does that mean? I'm possessed?", emma));
		b2ba.AddScriptPiece(new ScriptPiece(subtitle, "In your dimensions terms, I suppose.   Since you are more used to this body, you have control but I have already gotten stronger as I’ve stayed in your body.", grados));
		b2ba.AddScriptPiece(new ScriptPiece(subtitle, "I believe I might be a conflicting roommate now! laughs Hello, you may call me Grados.", grados));
		
	}
	
	void SetupBranchB2bb(){
		b2bb.AddScriptPiece(new ScriptPiece(subtitle, "Oh, I apologize for my rudeness, I’m Grados. You might know me as a demon in  your world’s terms. ", grados));
		b2bb.AddScriptPiece(new ScriptPiece(subtitle, "It’s quite unfortunate, I teleported to your planet last night but was put on the same spot you were standing.", grados));
		b2bb.AddScriptPiece(new ScriptPiece(subtitle, "So, now I guess we’re temporary roommates! Except closer! Two consciousnesses in one body.", grados));
		b2bb.AddScriptPiece(new ScriptPiece(subtitle, "Nope, that’s not true. This has got to be a dream or some sort of christmas carol crap. Grados... I don’t think I’ve ever messed with a Grados.", emma));
		b2bb.AddScriptPiece(new ScriptPiece(subtitle, "No, I assure you I’m ...", grados));
		b2bb.AddScriptPiece(new ScriptPiece(subtitle, " Alright, time to go to the doctor! Maybe get that H&D vaccine.", emma));
		b2bb.AddScriptPiece(new ScriptPiece(subtitle, "No! I am quite real, I’ve just started to get some power back! I got you to your bed last night, who knows how much else I can start to do soon!", grados));
		
	}
	
	void SetupBranchB3(){
		b3.AddScriptPiece(new ScriptPiece(subtitle, "...Right, you’re in my body… so prove it to me!", emma));
		b3.AddScriptPiece(new ScriptPiece(subtitle, "Sighs, well… Put out your hand and pretend to exert yourself as though you were sucking water out of the air.", grados));
		b3.AddScriptPiece(new ScriptPiece(subtitle, "Laughs). Alright, I’m home alone anyway. Performs move. (Screams and performs the move again, then screams again)", emma));
		b3.AddScriptPiece(new ScriptPiece(subtitle, "(H&D agent breaks down the door)", null));
		
		b3.AddScriptPiece(new ScriptPiece(subtitle, "Ma’am, is everything alright? H&D corporation got some notice of suspicious activities were occurring around this area", hd));
		b3.AddScriptPiece(new ScriptPiece(subtitle, "...(stops as he sees her powers pulls out weapon).  Put your hands up!", hd));
		b3.AddScriptPiece(new ScriptPiece(subtitle, "I guess it's time for some on the go training, allons-y!", grados));		
	}


}
