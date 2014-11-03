using UnityEngine;
using System.Collections;

public class TryAgainScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)){
			Application.LoadLevel(PlayerPrefs.GetString("LastLevel"));
		}
	}
}
