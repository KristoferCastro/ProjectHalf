using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BaseDialogue : MonoBehaviour {

	static readonly float TALK_SPEED_NORMAL = 4.0f;
	static readonly float TALK_SPEED_INSTANT = 0;
	static readonly float TALK_SPEED_ONE_SECOND = 2f;
	static readonly float TALK_SPEED_TWO_SECOND = 2.75f;
	static readonly float TALK_SPEED_THREE_SECOND = 6f;
	
	
	protected enum Decision{NONE, A, B};
	//protected enum CutScene{NONE};
	//protected enum Talking{NONE};
	
	public class Talking{
		public Talking(string name) {this.name = name;}
		public string name{ get; set;}
	};
	
	public class CutScene{
		public CutScene(int name) {this.index = name;}
		public int index{ get; set; }
	}
	// maps talkers to their game objects
	protected Dictionary<Talking, GameObject> talkers;
	
	// all cut scene videos
	public MovieTexture[] cutScenes; 
	public AudioClip[] cutScenesAudio;
	
	// NGUI Subtitle reference
	public UILabel subtitle;
	
	//things to maybe disable while talking
	public GameObject playerHUD;
	
	public MoviePlayer moviePlayer;
	public Camera mainCamera;
	public Camera movieCamera;
	
	// Use this for initialization
	void Start () {
		if (Input.GetKeyDown(KeyCode.Alpha1) ){
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	protected virtual void SetUpDictionary(){
		talkers = new Dictionary<Talking, GameObject>();
	}	
	
	void HideAllPictures(){
		foreach (KeyValuePair<Talking, GameObject> pair in talkers){
			GameObject picture = pair.Value;
			picture.SetActive(false);
		}
	}
	
	protected void ShowTalker(Talking talkerWanted){
	
		foreach (KeyValuePair<Talking, GameObject> pair in talkers){
			GameObject picture = pair.Value;
			Talking currentTalker = pair.Key;
			if (talkerWanted != null && currentTalker.name == talkerWanted.name)
				picture.SetActive(true);
			else
				picture.SetActive(false);
		}
	}
	
	
	IEnumerator PlayCutScene(CutScene cutSceneIndex){
		// disable gameplay, switch on movie camera
		// take the cutScenes[cutSceneIndex] and put it on the movie cube
		// play it.
		// switch off movie camera
		
		subtitle.text = "";
		EnableMovieCamera();
		
		MovieTexture cutscene = cutScenes[cutSceneIndex.index];
		
		AudioClip audio = null;
		if (cutScenesAudio.Length != 0){
			audio = cutScenesAudio[cutSceneIndex.index];
			Debug.Log ("has audio");
		}
		if (audio != null)
			moviePlayer.PlayMovie(cutscene,  audio);
		else
			moviePlayer.PlayMovie (cutscene);
		// wait till movie finishes playing	
		while (!moviePlayer.IsFinishPlaying()){
			yield return null;
		}
		
		DisableMovieCamera();
	}
	
	protected void EnableMovieCamera(){
		mainCamera.enabled = false;
		movieCamera.enabled = true;
	}
	
	protected void DisableMovieCamera(){
		mainCamera.enabled = true;
		movieCamera.enabled = false;
	}
	
	protected class ScriptBranch{
		BaseDialogue parent;
		List<ScriptPiece> myScript;
		public ScriptBranch left;
		public ScriptBranch right;
		public Decision lastDecision;
		
		public ScriptBranch(BaseDialogue parent){
			this.parent = parent;
			myScript = new List<ScriptPiece>();
			lastDecision = Decision.NONE;
		}
		
		public void AddScriptPiece(ScriptPiece p){
			p.SetParent(parent);
			myScript.Add(p);
		}
		
		public IEnumerator Play(Action<Talking> showTalkingMethod){
			parent.ShowTalker(null);
			parent.DisableMovieCamera();
			ScriptPiece lastSp = null;
			foreach (ScriptPiece sp in myScript){
				lastSp = sp;
				yield return parent.StartCoroutine(sp.Play(showTalkingMethod));
			}
			if (lastSp is ScriptPieceDecision){
				lastDecision = ((ScriptPieceDecision)lastSp).storyDecision;
				
				// branching decisions have more impact
				if (lastDecision == Decision.A){
				/*
					int currentEvilCount = PlayerPrefs.GetInt(PlayerPrefVariables.BAD_COUNT);
					currentEvilCount += 1;
					PlayerPrefs.SetInt(PlayerPrefVariables.BAD_COUNT, currentEvilCount); 
					*/
					GameDirector.instance.IncreaseBadCount();
				}else{
				/*
					int currentGoodCount = PlayerPrefs.GetInt(PlayerPrefVariables.GOOD_COUNT);
					currentGoodCount += 1;
					PlayerPrefs.SetInt(PlayerPrefVariables.GOOD_COUNT, currentGoodCount); 
					*/
					GameDirector.instance.IncreaseGoodCount();			
				}
			}
			yield return null;
		}
		
		public bool IsEmpty(){
			return myScript.Count == 0;
		}
	}
	
	protected class ScriptPiece{
		protected BaseDialogue parent;
		protected string text;
		protected Talking talking;	
		protected CutScene cutSceneIndexAfter;	
		protected Func<CutScene, IEnumerator> playCutSceneMethod;
		public float talkDelay = BaseDialogue.TALK_SPEED_TWO_SECOND;	
		protected UILabel subtitleLabel;
		
		public ScriptPiece(UILabel subtitleLabel, string text, Talking talking){
			this.text = text;
			this.talking = talking;
			this.subtitleLabel = subtitleLabel;
			AdjustTalkDelay(text);
			if (text == null)
				talkDelay = 0f; 
		}
		
		public ScriptPiece(UILabel subtitleLabel, string text, Talking talking, CutScene cutSceneIndex){
			this.text = text;
			this.talking = talking;
			this.cutSceneIndexAfter = cutSceneIndex;
			//this.playCutSceneMethod = parent.PlayCutScene;
			this.subtitleLabel = subtitleLabel;
			AdjustTalkDelay(text);
			if (text == null)
				talkDelay = 0f; 
		}
		
		public void AdjustTalkDelay(string text){
			if (text == null) return;
			if (text.Length < 50){
				talkDelay = TALK_SPEED_ONE_SECOND;
			}
			if (text.Length >= 50){
				talkDelay = TALK_SPEED_TWO_SECOND;
			}
			
			if (text.Length >= 120){
				talkDelay = TALK_SPEED_THREE_SECOND;
			}
		}
		
		public void SetParent(BaseDialogue parent){
			this.parent = parent;
		}
		
		public virtual IEnumerator Play(Action<Talking> showTalkingMethod){
			// show whose talking
			showTalkingMethod(this.talking);
			subtitleLabel.text = this.text;
			yield return new WaitForSeconds(talkDelay);
			
			// there is a video attached
			if (cutSceneIndexAfter != null){
				yield return parent.StartCoroutine(parent.PlayCutScene(cutSceneIndexAfter));
			}
			
		}
	}
	
	protected class ScriptPieceDecision : ScriptPiece{
		public Decision storyDecision;
		CutScene cutsceneA;
		CutScene cutsceneB;
		
		public ScriptPieceDecision(UILabel subtitleLabel, string text, Talking talking) : base(subtitleLabel, text, talking){
			storyDecision = Decision.NONE;
		}
		
		public ScriptPieceDecision(UILabel subtitleLabel, string text, Talking talking, CutScene cutSceneAIndex,CutScene cutSceneBIndex) 
		: base (subtitleLabel, text, talking){
			storyDecision = Decision.NONE;			
			cutsceneA = cutSceneAIndex;
			cutsceneB = cutSceneBIndex;
		}
		
		public override IEnumerator Play(Action<Talking> showTalkingMethod){			
			showTalkingMethod(talking);
			subtitleLabel.text = this.text;
			yield return parent.StartCoroutine(WaitForDecision());
			
			if (storyDecision == Decision.A)
				cutSceneIndexAfter = cutsceneA;
			else
				cutSceneIndexAfter = cutsceneB;
				
			// there is a video attached
			if (cutSceneIndexAfter != null){		
				yield return parent.StartCoroutine(parent.PlayCutScene(cutSceneIndexAfter));
			}
		}
		
		IEnumerator WaitForDecision(){
			
			while(! (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Alpha2)) ){
				yield return null;
			}
			
			if (Input.GetKeyDown (KeyCode.Alpha1)){
				storyDecision = Decision.A;/*
				int currentEvilCount = PlayerPrefs.GetInt(PlayerPrefVariables.BAD_COUNT);
				currentEvilCount += 1;
				PlayerPrefs.SetInt(PlayerPrefVariables.BAD_COUNT, currentEvilCount); 
				*/
				GameDirector.instance.IncreaseBadCount();
				
			}
			if (Input.GetKeyDown (KeyCode.Alpha2)){
				storyDecision = Decision.B;
				/*
				int currentGoodCount = PlayerPrefs.GetInt(PlayerPrefVariables.GOOD_COUNT);
				currentGoodCount += 1;
				PlayerPrefs.SetInt(PlayerPrefVariables.GOOD_COUNT, currentGoodCount); 
				*/
				GameDirector.instance.IncreaseGoodCount();
				
			}
		}
	}
}
