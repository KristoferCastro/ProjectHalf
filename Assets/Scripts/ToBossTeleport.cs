using UnityEngine;
using System.Collections;

public class ToBossTeleport : MonoBehaviour {

	public HDLevelAI levelAI;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Emmalyn"){
			bool badDominant = GameDirector.instance.KilledTooMuch();
			Debug.Log (badDominant);
			if (badDominant) // load lab boss
				Application.LoadLevel ("BossBattleAScenePreTalking");
			else
				Application.LoadLevel ("BossBattleBScenePreTalking");
		}
	}
	

}
