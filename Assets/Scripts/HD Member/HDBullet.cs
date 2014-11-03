using UnityEngine;
using System.Collections;

public class HDBullet : MonoBehaviour {

	float lifeTime = 2f;
	// Use this for initialization
	void Start () {
		Invoke("DestroyBullet", lifeTime);
	}
	
	void DestroyBullet(){
		Destroy(gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
