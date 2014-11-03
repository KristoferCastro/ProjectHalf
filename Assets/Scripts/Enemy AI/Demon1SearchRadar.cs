using UnityEngine;
using System.Collections;

public class Demon1SearchRadar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log (other.name);
		if(other.name.Contains("HD Member") || other.name.Contains ("Boss Scientist")){
			GetComponentInParent<Animator>().SetBool("attack", true);
			StartCoroutine("DisableAttack");
		}
	}
	
	IEnumerator DisableAttack(){
		yield return new WaitForSeconds(1.0f);
		GetComponentInParent<Animator>().SetBool("attack", false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
