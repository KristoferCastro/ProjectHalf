using UnityEngine;
using System.Collections;

public class FriendsHouseScenePreTalkingDialog : BaseDialogue {

	// dialogue game objects
	public GameObject playerPicture;
	public GameObject gradosPicture;
	public GameObject friendsPicture;
	public GameObject colonelPicture;
	
	public GameObject backgroundOutside;
	public GameObject backgroundInside;
	
	Talking emma;
	Talking grados; 
	Talking friend;
	Talking colonel;
	
	CutScene cutscene1;
	
	ScriptBranch head;
	ScriptBranch b1;
	ScriptBranch b2;
	ScriptBranch b2a;
	ScriptBranch b2b;
	
	ScriptBranch b3v1; // depend if predominantly bad
	ScriptBranch b3v2; // depend if predominantly good
	
	ScriptBranch b4;
	ScriptBranch b4a;
	
	ScriptBranch b4b;
	ScriptBranch b5v1; // depend if predominantly bad
	ScriptBranch b5v2; // depend if predominantly good
	
	/*
	ScriptBranch b6;
	ScriptBranch b6a;
	ScriptBranch b6b;
	*/
	
	
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
	}
	
	void InitializeGraph(){
		b1 = new ScriptBranch(this);
		b2 = new ScriptBranch(this);
		b2a = new ScriptBranch(this);
		b2b = new ScriptBranch(this);
		b3v1 = new ScriptBranch(this);
		b3v2 = new ScriptBranch(this);
		b4 = new ScriptBranch(this);
		b4a = new ScriptBranch(this);
		b4b = new ScriptBranch(this);
		b5v1 = new ScriptBranch(this);
		b5v2 = new ScriptBranch(this);
		/*
		b6 = new ScriptBranch(this);
		b6a = new ScriptBranch(this);
		b6b = new ScriptBranch(this);
		*/
	}

	// running to friends house still.
	void SetupB1 ()
	{
		b1.AddScriptPiece(new ScriptPiece(subtitle, "(running to friends house)", emma));    
		b1.AddScriptPiece(new ScriptPiece(subtitle, "Why the heck did they start fighting me out here?!", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "(Search her pockets…)", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "pulls out phone/ipad thing that has a notice of kill on sight for Emmalyn, marking the reasons for being treachery against H&D corporation.", grados));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "WHAT?! Treachery?! I’ve never done anything bad… I give money to Whales for Donaions for frick’s sake!", emma));
		b1.AddScriptPiece(new ScriptPiece(subtitle, "(Arives at friends house)", emma));
		                  
	}

	// in friends house
	void SetupB2 ()
	{
	/*
		b2.AddScriptPiece (new ScriptPiece(subtitle, "(knocks on door, friend opens it)", emma));
		b2.AddScriptPiece (new ScriptPiece(subtitle, "Emma! What do I deserve this fine visit", friend));
		b2.AddScriptPiece (new ScriptPiece(subtitle, "Um, sort of.  Can we come in", emma));
		b2.AddScriptPiece (new ScriptPiece(subtitle, "Uh sure, we?", friend));
		b2.AddScriptPiece (new ScriptPiece(subtitle, "Sorry, can i come in?", emma));
		b2.AddScriptPiece (new ScriptPiece(subtitle, "(enters house)", null));
		*/
		b2.AddScriptPiece (new ScriptPiece(subtitle, null, null, cutscene1));
		b2.AddScriptPiece (new ScriptPiece(subtitle, "So what's up? (laughs).  Trouble with the law or just fell off the sidewalk?", friend));
		b2.AddScriptPiece (new ScriptPiece(subtitle, " … Do you mind if I sit alone somewhere? I just need to make a phone call.", emma));
		b2.AddScriptPiece (new ScriptPiece(subtitle, "Oh. Sure, go ahead. But hey… Whenever you’re ready let me know what’s up. You’re making me pretty worried…", friend));
		b2.AddScriptPiece (new ScriptPiece(subtitle, "(Goes into other room.  starts talking to Grados)", null));
		b2.AddScriptPiece (new ScriptPieceDecision(subtitle, "(Press 1):    Okay frekazoid, tell me everything. Now!\n(Press 2):    Alright, we need to talk.  Augh, I don't know where to even start...", emma));
	}

	void SetupB2a ()
	{
		b2a.AddScriptPiece(new ScriptPiece(subtitle, "Where are you from and what the heck are you? ", emma));
		b2a.AddScriptPiece(new ScriptPiece(subtitle, "Huff, it’s a wonder you even have friends… I suppose if I’m stuck here I might as well be the one civil entity. ", grados));
		b2a.AddScriptPiece(new ScriptPiece(subtitle, "I come from a planet called Demos, it is my version of your planet in another dimension. ", grados));
		b2a.AddScriptPiece(new ScriptPiece(subtitle, "Beings like me populate the it, there’s different kinds and we all have powers, if you haven’t been too imbecilic you will have noticed that I can summon and control lower level demons.", grados));
		b2a.AddScriptPiece(new ScriptPiece(subtitle, " … Alright, that’s the coles notes but it works for me. Why are you here?", emma));
		
	}

	void SetupB2b ()
	{
		b2b.AddScriptPiece(new ScriptPiece(subtitle, "I guess I need to know where you’re from first… and what you are… ", emma));
		b2b.AddScriptPiece(new ScriptPiece(subtitle, "My planet is called Demos. In common terms, it’s the exact opposite of earth residing in another dimension.", grados));
		b2b.AddScriptPiece(new ScriptPiece(subtitle, " We are your “average” beings comprised of organic elements, Oxygen, Carbon…", grados));
		b2b.AddScriptPiece(new ScriptPiece(subtitle, "Sorry but you need to keep it simple. Like… What do humans do? They live, talk, breathe air, reproduce, etcetera, etcetera. What does your kind do?", emma));
		b2b.AddScriptPiece(new ScriptPiece(subtitle, "Uppity. Huff, You may call us demons. Our actions are very similar to the ones you just listed, some physiological differences but the main difference is that we have abilities linked to our races like the ones you’ve been borrowing", grados));
		b2b.AddScriptPiece(new ScriptPiece(subtitle, "My race summons and controls lower level demons to do my bidding.", grados));
		b2b.AddScriptPiece(new ScriptPiece(subtitle, "… Alright. I’ve been hearing a lot of weird today... So why are you here?", emma));		
	}

	void SetupB3v1 ()
	{
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "Wouldn’t you like to know, ape.", grados));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "Excuse me?! YOU teleported into MY body, you owe my ape butt an explanation why that happened.", emma));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "Huff… I have strict orders…", grados));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "Did your orders include getting merged with a twenty-something old Canadian babe? Cause if they did I’d be mighty interested in knowing what the heck else happens in this plan!", emma));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "FFFfffffiiiiinee. I suppose what has happened IS outside of the mission description. Sighs. You don’t know about the planetary connection, correct?", grados));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "What? No.", emma));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "Yes. It should be enough to reverse some of the freezing effects. And you apes should be used to it by now, I can make it appear like some war scenario. ", grados));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "That could get me a couple thousand at least. Other demons have been less creative using disease, black plague?", grados));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "That was another demon commander. Only problem now is how I’m going to complete the resolution but that has been solving itself nicely", grados));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "You can only use a fraction of my power, but as you use it I get more control over your body. And then I’ll be on my way!", grados));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "WHAT?! YOU WANT TO USE MY BODY? TO KILL PEOPLE?", emma));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "It’s… It’s my only option! And it’s for the best of the planets, you can’t be that selfish! ", grados));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "SELFISH MY LEFT N...", emma));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "Emma are you alright? You’re freaking me out…", friend));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, " Sighs … Yeah. I’m sorry _____ (friend). I’m almost done here... Didn’t mean to worry ya. ", emma));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "It’s okay, you know we’ll figure this out right? But take your time.", friend));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "… Well why don’t you tell the humans what’s happening? Like go to the prime minister? The UN? I’m sure they’d know what to do about it.", emma));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "Scoffs. Yes. Like your ape scientists could even comprehend what is happening.", grados));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "Well why can’t you at least try! Get some physical evidence, give it to the people! They’d expect an outcome!", emma));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "Again, have you thought how much energy it takes to even connect the two dimensions? How could we get that much energy?", grados));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, " I guess we’ll just have to figure that out, satan. You’re not using my body for anything.", emma));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "Well, the more you use my powers the more I get control. And it seems like you’ve been having to do that a lot…", grados));
		b3v1.AddScriptPiece(new ScriptPiece(subtitle, "Yeah, I wonder who’s fault that is. Let’s go… ", emma));	
	}

	void SetupB3v2 ()
	{
		b3v2.AddScriptPiece (new ScriptPiece(subtitle, "… That information is restricted.", grados));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, "What? Come on, we’re in this together… We’re literally stuck together! ", emma));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle,"...I have extremely strict orders…", grados));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, "...Come on, what are you going to do otherwise? If you need to do anything, I have to do it for you. So you might as well tell me your plan!", emma));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle,"Sighs. I suppose… The outcome of the mission is more important than playing by the rules… So, you humans are unaware that our two planets are connected, correct?", grados));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, "… A connection?", emma));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle, "Exactly. Our two worlds function synchronously with one another; when humans die their souls travel dimensions and are reborn as demons. ", grados));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle, "Alternately demon souls travel to earth once they have died in our world. ", grados));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle,"But the immaculatus vaccine is interrupting that balance; without human souls dying the planet's energy has shifted.", grados));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle,"The environment of Demos is changing much faster than earths; already, much of our planet has frozen over while your planet has just begun to experience a heat increase.", grados));		
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, " …What will happen if it continues?", emma));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle,"We expect that neither planet will be able to harbor life, causing mass extinction… ", grados));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, "So... how are you fixing this?", emma));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle,"Ah, this is where it become somewhat awkward to explain… The resolution has been used before, as human life expectancy began to rise.", grados));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle,"And protocol mandates that we must forcibly remove a fraction of the human population.", grados));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, "What?! You’re going to kill people?", emma));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle,"Well, yes. Humans have managed it before, the “black plague” was the first instance of my kind intervening,", grados));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle,"you all managed through that! My leaders estimated that I should only have to kill, give or take, a billion people to resolve this issue.", grados));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, " …WHAT?! … Wait, what do you plan on doing now that you’re in me?", emma));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle," Well that’s at least one resolving matter! I’ve noticed that we’ve both been getting stronger as you use more of my powers. ", grados));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle,"While I expect that you’ll only ever be able to use the smallest fraction of my strength, I’m sure I’ll be able to over take your consciousness and complete the resolution very soon!", grados));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle,"WHAT?! YOU WANT TO OVER TAKE MY BODY?", emma));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle," No! I don’t want to but it is for the greater good of both planets! You have to realize…", grados));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, "THAT YOU’RE GOING TO MURDER PEOPLE USING MY BODY?", emma));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle,"Well, you won’t be doing it… I’ll be using my powers, I will just… Look… Like… You…", grados));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, "OH. WELL THAT MAKES IT ALL OKAY THEN!", emma));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, " Emma! Is everything okay in there?! ", friend));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, "… Yeah…. Sorry, I’ll be out in a second. Didn’t mean to scare you.", emma));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, "...Alright. ", friend));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, "Sighs. Okay, sorry. I know orders are orders but that’s INSANE! Why don’t you just tell people about this connection?", emma));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, "Well… How would you tell the humans? We’re much more advanced than you are. Look at your scientists, they have been blaming the heating on gasses! ", emma));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, "Can’t you show, physical evidence of what’s happening from your planet? Reveal that multiple dimensions exist?", emma));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle,"Well, I suppose… But it takes an immense amount of energy to get any transference between dimensions. How could we get that?", grados));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, " don’t know… We have to figure it out though. You cannot use my body to kill people.", emma));
		b3v2.AddScriptPiece (new ScriptPiece(subtitle,"I’m sorry but that is still my main objective. And as you use my powers more… I’m going to try to get a better hold on your consciousness…", grados));
		b3v2.AddScriptPiece(new ScriptPiece(subtitle, "Stands up to go. Well… Thanks for the honesty but that is not happening. Lets go talk to ______.", emma));
		
		
	}

	void SetupB4 ()
	{
		b4.AddScriptPiece(new ScriptPiece(subtitle,"Hey… Sorry about that earlier…", emma));
		b4.AddScriptPiece(new ScriptPiece(subtitle," Hey, don’t worry about it, something really seems up… I’ve never hear you yell like that. Is it something about your parents?", friend));
		b4.AddScriptPiece(new ScriptPiece(subtitle,"What? No… It’s something else.", emma));
		b4.AddScriptPiece(new ScriptPiece(subtitle,"Your parents? What does that have to do with it?", grados));
		b4.AddScriptPiece(new ScriptPiece(subtitle," Just give me a second!", emma));
		b4.AddScriptPiece(new ScriptPiece(subtitle,"Yep, take your time.", friend));
		b4.AddScriptPiece(new ScriptPiece(subtitle," No… Sorry I meant… Sighs. Okay, I have to explain something to you, and it’s pretty weird… ", emma));
		b4.AddScriptPiece(new ScriptPiece(subtitle,"You are going to tell her about the resolution?! That’s classified! She’ll be a liability!", grados));
		b4.AddScriptPiece(new ScriptPiece(subtitle," Groans Demon… I know but I have to tell someone about this, and I’d trust her with anything. ", emma));
		b4.AddScriptPiece(new ScriptPiece(subtitle,"What…. Demon? Who are you talking to Emma?", friend));
		b4.AddScriptPiece(new ScriptPiece(subtitle,"If you tell her I will overtake your body and stop you, do you hear me? I won’t let you do this! ", grados));
		b4.AddScriptPiece(new ScriptPiece(subtitle,"Emma, you’re acting so weird... Is someone after you? ", friend));
		b4.AddScriptPiece(new ScriptPiece(subtitle,"Do it Emma and you’ll lose control!", grados));
		b4.AddScriptPiece(new ScriptPiece(subtitle," ENOUGH. ", emma));
		b4.AddScriptPiece(new ScriptPieceDecision(subtitle,"(press 1):    show friend\n(press 2):    tell friend", emma));
		
	}

	void SetupB4a ()
	{  
		b4a.AddScriptPiece(new ScriptPiece(subtitle, "Okay, I’m sorry this is going to sound insane but this demon thing accidentally merged  with me and now I have powers.", emma));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, "… We need to get you help Emma... Why don’t you come with me and we’ll…", friend));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, "No. I can’t… I’m kind of in trouble for no reason. See, I can do this.", emma));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, "Shows her, her powers, they get out of hand.", null));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, "AAAAAAAAAAHHHH!!", friend));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, "No! It’s okay! Sorry I don’t have complete control over them!", emma));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, " Stay away from me demon! Emma! If you’re still in there I’m going to get you some help! ", friend));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, "No! I’m fine! Just different… And H&D’s after me, you can’t tell them!", emma));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, " AAAH! Don’t hurt me! Runs out of house.", friend));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, "(Makes move to follow friend.)", emma));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, "Be reasonable Emmalyn! At least get some food first, we haven’t eaten all day! You’re about to pass out! ", grados));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, "But… I have to go after her…", emma));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, "You can’t. She might already be contacting H&D anyway. Lets calm down and get something to eat... We have to be ready to make an attack on H&D headquarters.", grados));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, " WHAT?", emma));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, "Well… We need to find out how they’re tracking us so we can get on with our work.", grados));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, " Yeah… Seems like they know something about us merging. Maybe they’ll know how to connect to your dimension… Or how I can get you out of me...", emma));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, "Agreed. I expected that they would give me some trouble but never this much… Something is going on there.", grados));
		b4a.AddScriptPiece(new ScriptPiece(subtitle, "(Door suddenly slams off it’s hinges. People immediately start shooting at you)", null));
	}

	void SetupB4b ()
	{		
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "I’m sorry… Okay so I need you to listen to what I’m about to tell you, please don’t interrupt until I’m done. Okay?", emma));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "Taken aback. … Alright.", friend));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "(half an hour later)", null));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "So… Can I show you what I can do to? To prove it?", emma));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "… Emma, I… Alright but don’t try too hard.", friend));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "Emma shows friend the powers.", null));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "Holy crap… You were telling the truth!?", friend));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "Yeah! I know it’s insane but it’s happening! But now I have H&D on my trail.", emma));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "Yeah… That’s so strange, I thought they were the first reputable company and bam. ", friend));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "They’re breaking a tonne of laws here! Emma, what can I do?", friend));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "For now, food? I’m absolutely starving and kind of eating for two now I guess.", emma));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "Ew. That’s so wrong… I’ll find you something. Leaves.", friend));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "So… What is our next move?", emma));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "We should make an attack on the H&D headquarters.", grados));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "WHAT?", emma));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "Well, we need to find out how they’re tracking us so we can get on with our work.", grados));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "Which we haven’t agreed on yet… But that sounds like a good plan, they seem to know something about what’s going on with us.", emma));
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "Maybe they’ll know how to connect to your dimension… Or if we can be split.", emma));	
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "Agreed. I expected that they would give me some trouble but never this much… Something is going on there.", grados));	
		b4b.AddScriptPiece(new ScriptPiece(subtitle, "(Door suddenly slams off it’s hinges. People immediately start shooting at you)", null));
		
	}

	void SetupB5v1 ()
	{
		b5v1.AddScriptPiece(new ScriptPiece(subtitle, "What happened to reading my rights?!", emma));
		b5v1.AddScriptPiece(new ScriptPiece(subtitle, " I’m who they call when the people don’t have the right to have rights anymore! Even your friend told us you were an abomination who had no right to live.", colonel));
		b5v1.AddScriptPiece(new ScriptPiece(subtitle, "You’re lying… SHE WOULDN’T!", emma));
		b5v1.AddScriptPiece(new ScriptPiece(subtitle, "I’m sure she would, especially if she knew how much damage you’ve done to my men.", colonel));
		b5v1.AddScriptPiece(new ScriptPiece(subtitle, "YYou’ve been attacking me this whole time!", emma));
		b5v1.AddScriptPiece(new ScriptPiece(subtitle, "Poor baby, too much heat for trying to destroy the world? Stop lying you filthy demon!", colonel));
		b5v1.AddScriptPiece(new ScriptPiece(subtitle, "You brainwashed idiot, you don’t know anything!", emma));
	}

	void SetupB5v2 ()
	{
		b5v2.AddScriptPiece(new ScriptPiece(subtitle,"(name of friend) get out of here now!", emma));
		b5v2.AddScriptPiece(new ScriptPiece(subtitle,"(Friend screams)", emma));
		b5v2.AddScriptPiece(new ScriptPiece(subtitle," NAME OF FRIEND! at colonel.  Why are you hurting her?", emma));
		b5v2.AddScriptPiece(new ScriptPiece(subtitle,"Those surrounding a demon have no rights under the governing of H&D. ", colonel));
		b5v2.AddScriptPiece(new ScriptPiece(subtitle," It’s for the greater good, no matter if how much false pity you’ve shown to my soldiers, I won’t let you get away Demon!", colonel));
		b5v2.AddScriptPiece(new ScriptPiece(subtitle," I don’t want to hurt anyone! I just want to be left alone!", emma));
		b5v2.AddScriptPiece(new ScriptPiece(subtitle,"Laughs. I’d be a moron to believe anything from a demon.", colonel));
		b5v2.AddScriptPiece(new ScriptPiece(subtitle,"You’re nothing but a filthy lying demon!", colonel));
		b5v2.AddScriptPiece(new ScriptPiece(subtitle,"Emma: You don’t know anything!", emma));
		
	}
	
	void SetUpGraph(){
		head = b1;
		
		b1.left = b2;
		b2.left = b2a;
		b2.right = b2b;
		
		// predominantly bad
		if (BadDominant()){
			b2a.left = b3v1;
			b2b.left = b3v1;
		}else{
			b2a.left = b3v2;
			b2b.left = b3v2;
		}
		
		b3v1.left = b4;
		b3v2.left = b4;
		
		b4.left = b4a;
		b4.right = b4b;
		
		// predominantly bad
		if (BadDominant()){
			b4a.left = b5v1;
			b4b.left = b5v1;
		}else{
			b4a.left = b5v2;
			b4b.left = b5v2;
		}
		
		SetupB1();
		SetupB2();
		SetupB2a();
		SetupB2b();
		SetupB3v1();
		SetupB3v2();
		SetupB4();
		SetupB4a();
		SetupB4b();
		SetupB5v1();
		SetupB5v2();
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
		
		Application.LoadLevel("FriendsHouseScene");
		
		yield return null;
	}
	
	protected override void SetUpDictionary(){
		base.SetUpDictionary();
		emma = new Talking("EMMA");
		grados = new Talking("GRADOS");
		friend = new Talking("FRIEND");
		colonel = new Talking("COLONEL");
		
		talkers.Add (emma, playerPicture);
		talkers.Add (grados, gradosPicture);
		talkers.Add (friend, friendsPicture);
		talkers.Add (colonel, colonelPicture);
	}
}
