using UnityEngine;
using System.Collections;

public class HDOfficialAI : HDMemberStreetAI {
	float maximumSpeed = 3;
	HDLevelAI levelAI;
	bool foundPlayer;
	// Use this for initialization
	void Start () {
		base.Start();
		//InvokeRepeating ("Flip", 0, 3);
		//InvokeRepeating ("RandomShoot", 0, 1.5f);
		health.health = 12;
//		levelAI = GameObject.Find("LevelAI").GetComponent<HDLevelAI>();
		
	}
	
	// Update is called once per frame
	void Update () {

	}

}
