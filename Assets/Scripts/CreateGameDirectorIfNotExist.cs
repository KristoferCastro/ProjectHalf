using UnityEngine;
using System.Collections;

public class CreateGameDirectorIfNotExist : MonoBehaviour {

	public GameObject gameDirector;
	// Use this for initialization
	void Start () {
		if(!GameObject.Find("GameDirector")){
			GameObject director  = Instantiate(gameDirector) as GameObject;
			director.name = "GameDirector";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
