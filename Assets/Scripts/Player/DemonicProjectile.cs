using UnityEngine;
using System.Collections;

public class DemonicProjectile : MonoBehaviour {

	public GameObject demonSummonMelee;
	public GameObject demonSummonProjectile;
	
	public LayerMask whatIsGround;
	
	public GameObject summonEffect;
	GameObject player;
	
	PlayerMana mana;
//	PlayerVariables playerVariables;
	
	GameObject summonEffectClone;
	
	// Use this for initialization
	void Start () {
		summonEffectClone = null;
		player = GameObject.Find("Emmalyn");
		mana = player.GetComponent<PlayerMana>();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "Ground"){
			GameObject summonEffectExist = GameObject.Find("Summon Effect(Clone)");
			if (summonEffectExist){
				Destroy (summonEffectExist);
			}
			summonEffectClone = (GameObject) Instantiate (summonEffect, transform.position, Quaternion.identity);
			Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);
			PlayerVariables playerV = player.GetComponent<PlayerVariables>();
			
			if (playerV.currentSummon == PlayerVariables.Summon.Evil){
				GameObject summon = (GameObject) Instantiate(demonSummonMelee, spawnPosition, Quaternion.identity);
				if (this.rigidbody2D.velocity.x < 0){
					summon.GetComponentInChildren<DemonSummonEvilAI>().Flip();
				}
				player.GetComponent<PlayerVariables>().numberOfSummons += 1;
				
			}
			else if (playerV.currentSummon == PlayerVariables.Summon.Good){
				GameObject summon = (GameObject) Instantiate(demonSummonProjectile, spawnPosition, Quaternion.identity);
				if (this.rigidbody2D.velocity.x < 0){
					summon.GetComponentInChildren<DemonSummonGoodAI>().Flip();
				}
				player.GetComponent<PlayerVariables>().numberOfSummons += 1;
			}
			Destroy(this.gameObject);	
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
