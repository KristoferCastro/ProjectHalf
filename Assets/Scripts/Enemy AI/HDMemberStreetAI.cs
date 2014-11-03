using UnityEngine;
using System.Collections;

public class HDMemberStreetAI : HDMemberAIIntro {

	public float followRange = 2f;
	// Use this for initialization
	void Start () {
		base.Start();
		health.health = 6; 
		if (player == null){
			player = GameObject.Find("Emmalyn");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x >= transform.position.x-followRange 
			&& player.transform.position.x <= transform.position.x+followRange
			
			&& player.transform.position.y <= transform.position.y + followRange/3){
			base.Update();	
		}
	}
}
