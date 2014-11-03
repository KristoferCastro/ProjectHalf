using UnityEngine;
using System.Collections;

public class GoodDemonicProjectile : MonoBehaviour {

	float destroyTime = 1f;
	// Use this for initialization
	void Start () {
		Invoke ("DestroyProjectile", destroyTime);
	}
	
	void DestroyProjectile(){
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		Destroy (gameObject);
	}
}
