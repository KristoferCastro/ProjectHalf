using UnityEngine;
using System.Collections;

public class IntroSceneDialog : MonoBehaviour {

	enum Talking{EMMA, GRADOS, HD, NOONE};
	
	public UILabel subtitle;

	int numberOfTalks = 11;
	float talkDelay = 4f;
	
	float FAST_TALK = 0.5f;
	float NORMAL_TALK = 4f;
	float INSTANT_TALK = 0f;
	
	string[] scriptNode1;
	string[] scriptNode2;
	string[] scriptNode2a;
	string[] scriptNode2b;
	string[] scriptNode2b_a;
	string[] scriptNode2b_b;
	string[] scriptNode3;
	string[] scriptNodeTraining;
	string[] scriptNodeEnd;
	
	StoryDecision decision1;
	StoryDecision decision2;
	StoryDecision decision2b;
	StoryDecision decision3;
	StoryDecision decisionEnd;
	
	public GameObject player;
	public GameObject hdMember;
	public GameObject playerHUD;
	public GameObject dialoguePlayer;
	public GameObject dialogueGrados;
	public GameObject dialogueHD;
	
	public SpriteRenderer background;
	
	public AudioClip battleSound;
	public AudioClip conversation;
	
	// Use this for initialization
	void Start () {
		DisableGameplay();
		decision1 = new StoryDecision();
		decision2 = new StoryDecision();
		decision2b = new StoryDecision();
		decision3 = new StoryDecision();
		decisionEnd = new StoryDecision();
		
		SetUpScript1();
		SetUpScript2 ();
		SetUpScript2a();
		SetUpScript2b();
		SetUpScript3();
		SetUpScript2b_a();
		SetUpScript2b_b();
		SetUpTrainingScript();
		SetUpScriptNodeEnd();
		
		StartCoroutine("Talk");
	}
	
	void DisableGameplay(){
		GameObject[] summons = GameObject.FindGameObjectsWithTag("Demon Summons");
		foreach (GameObject s in summons){
			Destroy (s);
		}
		hdMember.SetActive(false);
		player.SetActive(false);
		playerHUD.SetActive (false);
		background.color = new Color32(10,10,10,255);
	}
	
	void EnableGameplay(){
		ShowTalking(Talking.NOONE);
		player.SetActive(true);
		hdMember.SetActive(true);
		playerHUD.SetActive (true);
		background.color = new Color32(255,255,255,255);
		
	}
	
	void ShowTalking(Talking who){
		switch(who){
			case Talking.EMMA: {
				dialoguePlayer.SetActive (true);
				dialogueGrados.SetActive (false);
				dialogueHD.SetActive (false);
				break;
			}
			case Talking.GRADOS: {
				dialoguePlayer.SetActive (false);
				dialogueGrados.SetActive (true);
				dialogueHD.SetActive (false);
				break;
			}
			case Talking.HD: {
				dialoguePlayer.SetActive (false);
				dialogueGrados.SetActive (false);
				dialogueHD.SetActive (false);
				break;
			}
			case Talking.NOONE:{
				dialoguePlayer.SetActive (false);
				dialogueGrados.SetActive (false);
				dialogueHD.SetActive (false);
				break;
			}
		}
	}
	
	void SetUpScript1(){
		scriptNode1 = new string[]{
			/*
			Setting: Emma’s apartment, small, cluttered, the tv is on, she’s laying on the couch watching tv. 
			Pan throughout the room then to her on the couch looking intently at the screen. 
			After, pan in to see what the tv is playing. CBC logo shows, super canadianess
			*/	
			"TV announcer: We now continue the special on the miraculous formation of the H&D corporation. From self fulfilling physicists to global savoirs of those in dire need, how did they get there?",			
			/*
			images show almost religious imagry associated with H&D, people praying, looking happy, walking out of hospitals ect.
			*/		
			"TV announcer: Through hard work and sacrifice, the prophetic Doctor Brendon Bernhard was the first scientist from the fledgling H&D corporation to discover a breakthrough in human immortality.",
			"TV announcer: Several months later he created the immaculatus vaccine, which has provided five billion people with the chance to re start and re live without ever aging or becoming sick again",		
			/*
			Picture of Bernhard, eerily similar to the portraits of Kim Jong Il
			*/			
			"TV announcer: Dr. Bernhard found a catalyst that would make cells “recycle” themselves rather than dying. ",
			"TV announcer: If any impediment to human life occurs cells simply revert to their healthiest form overpowering %99.99 percent of all diseases, injuries, or impediments to human life.",
			/*
			Images of Bernhard in a science coat, looking at jellyfish (google immortal jellyfish) 
			then switches to lines of people getting the vaccine. Tv studio lights flicker, slightly,
			 Emma hums at the notice of this.
			*/
			"TV announcer: ...And finally, we have a performance by the church of H&D\'s children\'s choir called \"Our ultimate light and savior, the H&D corporation.\"...",
			"(Press 1):    Ugh, I do not need to hear that.\n(Press 2):    Mmmm, I wonder if a power outage will interupt that."
		};
	}
	
	void SetUpScript2(){
		scriptNode2 = new string[]{
			"Emma:    Wha...",
			"Demon One:    ...complete the resolution...",
			"Grados:    How many should die?",
			"Demon Two:    ...Attempt several tens of thousands...Should make an impact...",
			"(Press 1):    ...how did I get to bed?\n(Press 2):    ...what a weird dream..."
		};
	}
	
	void SetUpScript2a(){
		scriptNode2a = new string[]{
			"Grados:    I helped you to bed!",
			"Emma:    (Screams) Who the heck was that?!",
			"Grados:    Oh, you didn't know I was here?",
			"Emma:    ...Wha...",
			"Grados:    It’s quite unfortunate, I teleported to your planet last night but was put on the same spot you were standing. ",
			"Grados:    So, now I guess we’re temporary roommates! Except closer! Two consciousnesses in one body, have not heard of that happening before! ",
			"Grados:    Ah yes, I’d appreciate it if you didn’t look into my memories… but anyway! When I accidently merged with you you passed out, so I took your body to bed. That shows that I’m gaining some energy! How promising!",
			"Emma:    This has to be a fever dream...",
			"Grados:   I wish it was as well but alas, no..."  	
		};
	}
	
	void SetUpScript2b(){
		scriptNode2b = new string[]{
			"Emma:   (Looks troubled)...I wish I was dreaming about someone hot instead...",
			"Grados:   I'd rather that as well...",
			"Emma:    (Shocked)...Hello? Is someone here? (looks around room).  I'm prety sure I locked the door last night!",
			"Grados:    Yes, I think you did as well and I’d rather you didn’t peek into my memories.",
			"Emma:    ...Peek into… What? Hey I don’t know who you are but you need to get out! ",
			"Grados:    Grados: Wish I could Miss Emmalyn but  I appear to be stuck here. Unless you knew some method of separating us.",	
			"(Press 1):    Okay you sick freak, get out of my apartment!\n(Press 2):    What... Who is this?",
		};
	}
	
	void SetUpScript2b_a(){
		scriptNode2b_a = new string[]{
			"Grados:     Oh, well aren’t you unpleasant. I wish to be stuck in your body as much as you want me here.",
			"Emma:    The heck are you talking about freakazoid?",
			"Grados:    Now that’s not even clever. Last night I transported to your planet to complete my mission. Unfortunately you were standing on the spot where I was teleporting. Knocked you right out…",
			"Grados:     I was going to sulk and leave you on the floor but I thought better and was nice enough to control your body to bed.",
			"Emma:   (Looking around apartment for a person who could be talking)",
			"Emma:  (laughs).  Right, so what does that mean? I'm possessed?",
			"Grados:    In your dimensions terms, I suppose.   Since you are more used to this body, you have control but I have already gotten stronger as I’ve stayed in your body.",
			"Grados:     I believe I might be a conflicting roommate now! laughs Hello, you may call me Grados."
		};
	}
	
	void SetUpScript2b_b(){
		scriptNode2b_b = new string[]{
			"Grados:   Oh, I apologize for my rudeness, I’m Grados. You might know me as a demon in  your world’s terms. ",
			"Grados:    It’s quite unfortunate, I teleported to your planet last night but was put on the same spot you were standing.",
			"Grados:   So, now I guess we’re temporary roommates! Except closer! Two consciousnesses in one body.",
			"Emma:    Nope, that’s not true. This has got to be a dream or some sort of christmas carol crap. Grados... I don’t think I’ve ever messed with a Grados.",
			"Grados:    No, I assure you I’m ...",
			"Emma:    Alright, time to go to the doctor! Maybe get that H&D vaccine.",
			"Grados:    No! I am quite real, I’ve just started to get some power back! I got you to your bed last night, who knows how much else I can start to do soon!"
		};
	}
	
	void SetUpScript3(){
		scriptNode3 = new string[]{
			"Emma:    ...Right, you’re in my body… so prove it to me!",
			"Grados:    Sighs, well… Put out your hand and pretend to exert yourself as though you were sucking water out of the air.",
			"Emma:     (Laughs). Alright, I’m home alone anyway. Performs move. (Screams and performs the move again, then screams again)",
			"(H&D agent breaks down the door)",
			"Agent:    Ma’am, is everything alright? H&D corporation got some notice of suspicious activities were occurring around this area",
			"Agent:    ...(stops as he sees her powers pulls out weapon).  Put your hands up!",
			"Grados:   I guess it's time for some on the go training, allons-y!"
		};
	}
	
	void SetUpTrainingScript(){
		scriptNodeTraining = new string[] {
			"Grados:    You use spacebar to release your powers.",
			"Grados:    You summon demons this way.",
			"Grados:    The demons you summon depends on your personality.",
			"Grados:    Ok, so charging your powers can make it go farther",
			"Grados:    Remember, you got legs so you can move around and even jump !",
			"Grados:    Use arrow keys to move."
		};
	}
	
	void SetUpScriptNodeEnd(){
		scriptNodeEnd = new string[]{
			"Emma:    (Grasping for breath).  Oh. My. God.",
			"Grados:    So! That's that, feel better now?",
			"Emma:  somewhat furious ...",
			"Grados:    Anyway, should we lock him up somewhere? Do you have a storage locker?",
			"Emma:     What… I can’t just do that, they’ll know that somethings up with me anyway when he doesn’t come back!",
			"Emma:     Oh man… I don’t want to leave him to die…",
			"Grados:    He won’t die. I’m sure someone might find him before he starves! He’ll just be a little worse for wear…",
			"Grados:    But that doesn’t matter, that place he works for will know about us sooner if we don’t lock him up!",
			"(Press 1):    Lock the H&D agent up\n(Press 2):    Leave him",
		};
	}
	
	IEnumerator PlayScriptEnd(){
	
		ShowTalking (Talking.EMMA);
		subtitle.text = scriptNodeEnd[0];
		yield return Delay(talkDelay);
		
		ShowTalking (Talking.GRADOS);
		subtitle.text = scriptNodeEnd[1];
		yield return Delay(talkDelay);
		
		ShowTalking (Talking.EMMA);
		subtitle.text = scriptNodeEnd[2];
		yield return Delay(talkDelay);
		
		ShowTalking (Talking.GRADOS);
		subtitle.text = scriptNodeEnd[3];
		yield return Delay(talkDelay);
		
		ShowTalking (Talking.EMMA);
		subtitle.text = scriptNodeEnd[4];
		yield return Delay(talkDelay);
		
		ShowTalking (Talking.EMMA);
		subtitle.text = scriptNodeEnd[5];
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNodeEnd[6];
		ShowTalking (Talking.GRADOS);
		yield return Delay(talkDelay);
		
		ShowTalking (Talking.GRADOS);
		subtitle.text = scriptNodeEnd[7];
		yield return Delay(talkDelay);
		
		ShowTalking (Talking.EMMA);
		subtitle.text = scriptNodeEnd[8];
		yield return StartCoroutine(WaitForDecision(decisionEnd));
		Debug.Log ("decisionEnd: " + decisionEnd.ToString());	
	}

	
	IEnumerator PlayTrainingScript(){
		ShowTalking (Talking.GRADOS);
		
		while (!HDMemberDead()){
			foreach (string training in scriptNodeTraining){
				if (HDMemberDead ()){
					break;
				}
				subtitle.text = training;
				yield return Delay (talkDelay);
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.I)){
			talkDelay = INSTANT_TALK;
		}
		if (Input.GetKeyDown (KeyCode.O) ){
			talkDelay = FAST_TALK;
		}
		
		if (Input.GetKeyDown (KeyCode.P)){
			talkDelay = NORMAL_TALK;
		}
		
	}
	
	
	IEnumerator PlayScript1(){
		ShowTalking(Talking.NOONE);
		/*
		subtitle.text = scriptNode1[0];
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode1[1];
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode1[2];
		yield return Delay (talkDelay);
		
		subtitle.text = scriptNode1[3];
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode1[4];
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode1[5];
		yield return Delay (talkDelay);
		*/
		subtitle.text = scriptNode1[6];
		yield return StartCoroutine(WaitForDecision(decision1));
		Debug.Log ("decision1: " + decision1.ToString());			
		
	}
	
	IEnumerator PlayScript2(){
		subtitle.text = scriptNode2[0];
		ShowTalking(Talking.EMMA);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2[1];
		ShowTalking(Talking.NOONE);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2[2];
		ShowTalking(Talking.GRADOS);
		yield return Delay (talkDelay);
		
		subtitle.text = scriptNode2[3];
		ShowTalking(Talking.NOONE);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2[4];
		ShowTalking(Talking.EMMA);
		yield return StartCoroutine(WaitForDecision(decision2));
		Debug.Log ("decision2: " + decision2.ToString());			
		
	}
	
	IEnumerator PlayScript2a(){
		subtitle.text = scriptNode2a[0];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2a[1];
		ShowTalking(Talking.EMMA);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2a[2];
		ShowTalking(Talking.GRADOS);
		yield return Delay (talkDelay);
		
		subtitle.text = scriptNode2a[3];
		ShowTalking(Talking.EMMA);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2a[4];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2a[5];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2a[6];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2a[7];
		ShowTalking(Talking.EMMA);
		yield return Delay (talkDelay);
		
		subtitle.text = scriptNode2a[8];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
	}
	
	IEnumerator PlayScript2b(){
		subtitle.text = scriptNode2b[0];
		ShowTalking(Talking.EMMA);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2b[1];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2b[2];
		ShowTalking(Talking.EMMA);
		yield return Delay (talkDelay);
		
		subtitle.text = scriptNode2b[3];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2b[4];
		ShowTalking(Talking.EMMA);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2b[5];
		ShowTalking(Talking.GRADOS);
		
		yield return Delay(talkDelay);
		subtitle.text = scriptNode2b[6];
		ShowTalking(Talking.EMMA);
		
		yield return StartCoroutine(WaitForDecision(decision2b));
		Debug.Log ("decision2b: " + decision2b.ToString());	
	}
	
	IEnumerator PlayScript2b_a(){
		subtitle.text = scriptNode2b_a[0];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2b_a[1];
		ShowTalking(Talking.EMMA);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2b_a[2];
		ShowTalking(Talking.GRADOS);
		yield return Delay (talkDelay);
		
		subtitle.text = scriptNode2b_a[3];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2b_a[4];
		ShowTalking(Talking.EMMA);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2b_a[5];
		ShowTalking(Talking.EMMA);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2b_a[6];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2b_a[7];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
	}
	
	IEnumerator PlayScript2b_b(){
		subtitle.text = scriptNode2b_b[0];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2b_b[1];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2b_b[2];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2b_b[3];
		ShowTalking(Talking.EMMA);
		yield return Delay (talkDelay);
		
		subtitle.text = scriptNode2b_b[4];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2b_b[5];
		ShowTalking(Talking.EMMA);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode2b_b[6];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
	}
	
	IEnumerator PlayScript3(){
		subtitle.text = scriptNode3[0];
		ShowTalking(Talking.EMMA);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode3[1];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode3[2];
		ShowTalking(Talking.EMMA);
		yield return Delay (talkDelay);
		
		subtitle.text = scriptNode3[3];
		ShowTalking(Talking.EMMA);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode3[4];
		ShowTalking(Talking.HD);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode3[5];
		ShowTalking(Talking.HD);
		yield return Delay(talkDelay);
		
		subtitle.text = scriptNode3[6];
		ShowTalking(Talking.GRADOS);
		yield return Delay(talkDelay);
	}
	
	IEnumerator Talk(){		
/*
		PlayConversationAudio();
		yield return StartCoroutine(PlayScript1 ());
		yield return StartCoroutine(PlayScript2 ());
		if (decision2.decision == StoryDecision.Decision.A)
			yield return StartCoroutine (PlayScript2a());
		else{
			yield return StartCoroutine (PlayScript2b());
			
			if (decision2b.decision == StoryDecision.Decision.A)
				yield return StartCoroutine (PlayScript2b_a());
			else
				yield return StartCoroutine (PlayScript2b_b());
		}		
		
		yield return StartCoroutine(PlayScript3 ());
		*/
		EnableGameplay();
		PlayBattleAudio();
		yield return StartCoroutine(PlayTrainingScript());
		
		while(!HDMemberDead()){
			yield return null;
		}
		DisableGameplay();
		PlayConversationAudio();
		hdMember.SetActive (true);
		yield return StartCoroutine (PlayScriptEnd());
		
		Application.LoadLevel("ToFriendsHouseScenePreTalking");
		
		yield return null;
	}
	
	bool HDMemberDead(){
	
		return hdMember.GetComponent<HDMemberHealth>().health <= 0;
	}
	
	void PlayBattleAudio(){
		audio.Stop ();
		audio.clip = battleSound;
		audio.Play ();
	}
	
	void PlayConversationAudio(){
		audio.Stop ();
		audio.clip = conversation;
		audio.Play ();
	}
	
	IEnumerator WaitForDecision(StoryDecision decision){
		
		while(! (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Alpha2)) ){
			yield return null;
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)){
			decision.decision = StoryDecision.Decision.A;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)){
			decision.decision = StoryDecision.Decision.B;
		}
	}
	
	IEnumerator WaitForEnter(){
		while (! Input.GetKeyDown (KeyCode.Return) ){
			yield return null;
		}
	}
	
	WaitForSeconds Delay(float delay){
		return new WaitForSeconds(delay);
	}
	
	class StoryDecision{
		public enum Decision{A, B, NONE};
		public Decision decision;
		
		public StoryDecision(){
			decision = Decision.NONE;
		}
		
		public string ToString(){
			return decision.ToString();
		}
	}

}
