using UnityEngine;
using System.Collections;

public class HDMemberHealth : MonoBehaviour {

	public float health = 12;
	Animator anim;
	
	bool checkedOnce = false;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!checkedOnce && health <= 0){
			anim.SetBool ("dying", true);
			
			checkedOnce = true;
			GameDirector.instance.IncreaseKillCount(1);
		}
	}
	
}
