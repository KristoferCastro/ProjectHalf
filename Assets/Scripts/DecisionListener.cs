using UnityEngine;
using System.Collections;

public class DecisionListener : MonoBehaviour {

	float lastGoodCount;
	float lastEvilCount;
	public AudioClip goodDecision;
	public AudioClip badDecision;
		
	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (lastGoodCount != GameDirector.instance.GetGoodCount()){
			audio.Stop ();
			audio.clip = goodDecision;
			audio.Play();
			Debug.Log ("changed good");
		}
		
		else if(lastEvilCount != GameDirector.instance.GetBadCount()){
			audio.Stop();
			audio.clip = badDecision;
			audio.Play ();
			Debug.Log ("changed bad");	
		}
		
		lastGoodCount = GameDirector.instance.GetGoodCount();
		lastEvilCount = GameDirector.instance.GetBadCount();

	}
}
