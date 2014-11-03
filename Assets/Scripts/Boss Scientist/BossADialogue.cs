using UnityEngine;
using System.Collections;

public class BossADialogue : MonoBehaviour {

	public bool playingDialogue;
	public AudioClip battleSound;
	public AudioClip talkingSound;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(Talk ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator Talk(){
		PlayBattleAudio();
		yield return null;
	}
	
	
	void PlayBattleAudio(){
		audio.Stop ();
		audio.clip = battleSound;
		audio.Play ();
	}
	
	void PlayConversationAudio(){
		audio.Stop ();
		audio.clip = talkingSound;
		audio.Play ();
	}
}

