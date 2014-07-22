using UnityEngine;
using System.Collections;

public class DemonicProjectile : MonoBehaviour {

	public GameObject demonSummon;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter2D(Collision2D other){
		Debug.Log (other.gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
