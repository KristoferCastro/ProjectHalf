using UnityEngine;
using System.Collections;

public class NarrativeScriptA : MonoBehaviour {

	UILabel subtitleLabel;
	// Use this for initialization
	void Start () {
		subtitleLabel = GameObject.Find("Subtitle").GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(WriteStory());
	}
	
	IEnumerator WriteStory(){
		yield return new WaitForSeconds(1);
		subtitleLabel.text = "Testing super long text blah blah blah blah Atleast everythign is centered";	
	}
}
