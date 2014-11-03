using UnityEngine;
using System.Collections;

public class HDLevelAI : MonoBehaviour {

	public bool foundPlayer = false;
	public bool foundDead = false;
	public HDMemberHealth[] healths;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckForDead ();
		Debug.Log (foundDead);
	}
	
	void CheckForDead(){
		foreach (HDMemberHealth h in healths){
			if (h.health <= 0){
				foundDead = true;
			}
		}
	}
	
}
