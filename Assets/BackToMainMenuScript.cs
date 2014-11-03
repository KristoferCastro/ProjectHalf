using UnityEngine;
using System.Collections;

public class BackToMainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)){
			GameDirector.instance.ChangeState(GameDirector.Screen.MAIN_MENU);
		}
	
	}
}
