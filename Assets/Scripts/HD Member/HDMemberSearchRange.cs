using UnityEngine;
using System.Collections;

public class HDMemberSearchRange : MonoBehaviour {

	public bool foundPlayer;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log (other.name);
		if (other.tag == "Player"){
			foundPlayer = true;
		}	
	}
	
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player"){
			foundPlayer = false;
		}	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
