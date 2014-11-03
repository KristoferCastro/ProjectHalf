using UnityEngine;
using System.Collections;

public class DemonSummonEvilAI : MonoBehaviour {

	public float speed = 4;
	public GameObject playerObject;
	// Use this for initialization
	void Start () {

		rigidbody2D.velocity = new Vector3(speed, 0, 0);
	}
	

	public void Flip(){

		this.transform.RotateAround (Vector3.up, Mathf.PI);		
		speed*=-1;
	}
}
