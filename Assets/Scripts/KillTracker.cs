using UnityEngine;
using System.Collections;

public class KillTracker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] allMembers = GameObject.FindGameObjectsWithTag("Enemy");
		int totalMembers = PlayerPrefs.GetInt (PlayerPrefVariables.TOTAL_MEMBERS) + allMembers.Length;
		PlayerPrefs.SetInt(PlayerPrefVariables.TOTAL_MEMBERS, totalMembers);  	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (PlayerPrefs.GetInt (PlayerPrefVariables.TOTAL_MEMBERS));
	}
}
