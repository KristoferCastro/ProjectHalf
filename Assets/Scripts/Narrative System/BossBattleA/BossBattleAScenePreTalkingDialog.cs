using UnityEngine;
using System.Collections;

public class BossBattleAScenePreTalkingDialog : BaseDialogue {

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
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Here we are! The CEO’s office!", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Good, lets search the their files…", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Geez, someone doesn’t want to get hacked…", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Emma, make sure there isn’t an alarm!", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "(Emma forces the drawer open)", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Oops! No alarm, isn’t that lucky! So what should we search up first?", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Grumbles. ", grados));	                  
		b1.AddScriptPiece(new ScriptPieceDecision(subtitle, "(Press 1):    Tracking\n(Press 2):    Bribery", emma));	
	}
	
	void SetupB1a(){
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "Tracking… T…. T… Tracking! There it is! It’s a list… You’re on here but do you recognize the rest of the names?", grados));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, " Yeah… They’re politicians. Look at this, adultery, embezzling, lying about age… These are all the things he has on people of government! ", emma));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "But... beside my name and some other people it just says tracking… And then, on other pages it has a SUPER detailed description of what we were doing but…", emma));	
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "What? ", grados));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "Some of them cut off saying “lacking refractory.”", emma));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, " OH! That’s it! The CEO must be a Demon! One of the races has the ability to camouflage in refractory materials. It’s just a very rare ability… ? ", grados));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "What? Ew, does that mean the CEO can hide in... mirrors? And he’s been sneaking through them to see everyone’s info?", grados));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "Yes. I’m sure that’s how he’s done everything. He has been controling the government to help H&D hold a great amount of power. That’s why they’ve been able to chase after us so merciously…", grados));
		b1a.AddScriptPiece(new ScriptPiece(subtitle, "Great… Thanks Canada… ", emma));		
	}
	
	void SetupB1b(){
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "Hum, there’s a pretty thick file on bribery… Shall we see what the CEO’s been up to? ", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "Well it may give us leverage to influence people's decision to stop taking the vaccine...", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, " Just what I was thinking… Wow, they started dirty! There’s a paper trail showing that they bribed a bunch of medical companies to push the vaccine straight to human trials… ", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "Which resulted in a high level of people getting this thing called the prometheus effect… ", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "That took  the most money to cover up it seems, they paid the medical companies, families, sent those people away, and then the media… They bought several entire media companies!", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "That explains H&D’s horrible exposes… This is disgusting, they even have bills showing their push to do multiple stories on sick kids like ten times over…", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "They knew just how to get the people to buy this.", emma));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "Wait, look at that paper! They’re all for energy companies in New Mexico… There’s only a couple bills from them but they all add up to obscene amounts!", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, " They must be trying to access dimensions there!", grados));
		b1b.AddScriptPiece(new ScriptPiece(subtitle, "Awesome, we know our next place to go!", emma));
	}
	
	void SetupB2(){
		b2.AddScriptPiece(new ScriptPiece(subtitle, "(Materializes out of a near by reflective object)", null));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Here you are my little mutt..", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Screams. … Ahem. Prepare to get your butt kicked demon overlord!", emma));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "(Laughs). That’s not very likely, I’ve been waiting around here for so long for YOU to come. Really shows your abilities Grados…", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "(Shocked). How did you know I was here?", grados));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Ooh, look at that… Talking through your partner now, you must really be getting along swimmingly! ", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Well be careful, it took quite a lot of muscle to separate myself and my human. Also, I’m not stupid Grados.", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "quite a lot of muscle to separate myself and my human. Also, I’m not stupid Grados. I knew the council would send someone else after I didn’t complete the resolution..", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "The council trusted you with the resolution?", grados));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Yes, I was sucked into Dr. Bernhard’s body after an experiment of his went wrong. I was trapped but I saw a promising opportunity with that man", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "All the power and pull in society I wanted! As you know Grados, our system is not anything near this capitalist one, everyone is so equal but so stuck! ", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "But what you’re doing is going to kill them all!", emma));
		b2.AddScriptPiece(new ScriptPiece(subtitle, " Good, no dimension needs a world full of underachievers who would rather implement quick fixes than make their great existence known! I’d rather live here.", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "I’m sure I could put Bernhard to work in a way to reverse the global warming after Demos is exterminated.", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Then it’d just be the beautiful, greedy, humans, all alone and all powerful in all dimensions!", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Why did you want us to find you?", emma));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "I wanted to offer you the opportunity to aid this great cause. I’ve given you everything I have to offer but honestly, you really don’t seem very interested…", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Heck no!", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Ah, c’est la vie! You know what I do with spoiled infants who don’t understand an opportunity of a lifetime?", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "I teach them a lesson… ", demonBoss));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "Bring it on, I’ll kick your Satan butt right back to your dimension!", emma));
		b2.AddScriptPiece(new ScriptPiece(subtitle, "(fight)", emma));
		
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
		
		Application.LoadLevel("BossBattleBScene");
		
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

