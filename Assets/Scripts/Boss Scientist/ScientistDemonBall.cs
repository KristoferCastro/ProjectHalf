using UnityEngine;
using System.Collections;

public class ScientistDemonBall : MonoBehaviour {

	public bool startExplosionTimer;
	float timeTillExplode = 0.5f;
	public GameObject summonEffectPrefab;
	public GameObject summonPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (startExplosionTimer){
			Invoke("DestroyBall", timeTillExplode);
		}
	}
	
	void DestroyBall(){
		GameObject obj = Instantiate (summonEffectPrefab) as GameObject;
		obj.transform.position = gameObject.transform.position;
		GameObject.Destroy(obj, obj.GetComponentInChildren<ParticleSystem>().duration + obj.GetComponentInChildren<ParticleSystem>().startLifetime);
		GameObject summon = Instantiate (summonPrefab) as GameObject;
		summon.transform.position = obj.transform.position;
		Destroy (summon,5);
		Destroy (gameObject);
	}
	
	void DestroyEffect(GameObject obj){
		Destroy (obj);
	}
}
