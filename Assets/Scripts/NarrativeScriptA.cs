using UnityEngine;
using System.Collections;

public class NarrativeScriptA : MonoBehaviour {

	UILabel subtitleLabel;
	
	string[] script;
	
	// Use this for initialization
	void Start () {
		subtitleLabel = GameObject.Find("Subtitle").GetComponent<UILabel>();
		InitializeScript ();
	}
	
	void InitializeScript(){
	
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(WriteStory());
	}
	
	IEnumerator WriteStory(){
		yield return new WaitForSeconds(1);
		subtitleLabel.text = "(Emmalyn) : Testing super long text blah blah blah blah Atleast everythign is centered";
		subtitleLabel.text += "Testing super long text blah blah blah blah Atleast everythign is centered";
		subtitleLabel.text += "Testing super long text blah blah blah blah Atleast everythign is centered";
		subtitleLabel.text += "Testing super long text blah blah blah blah Atleast everythign is centered";
		subtitleLabel.text += "Testing super long text blah blah blah blah Atleast everythign is centered";
	}
}
