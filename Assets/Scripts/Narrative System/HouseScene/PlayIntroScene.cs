using UnityEngine;
using System.Collections;

public class PlayIntroScene : MonoBehaviour {

	public MovieTexture movie;
	// Use this for initialization
	void Start () {
		renderer.material.mainTexture = movie as MovieTexture;
		audio.Play ();
		GetComponent<AudioSource>().pitch = 0.65f; //The scale factor you want
		movie.loop = false;
		movie.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(movie.isPlaying == false){
			if (GameDirector.instance != null)
				GameDirector.instance.ChangeState(GameDirector.Screen.INTRO_LEVEL);
			else
				Application.LoadLevel ("IntroScene");
		}	
	}
}
