using UnityEngine;
using System.Collections;

public class MoviePlayer : MonoBehaviour {

	MovieTexture movie;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void PlayMovie(MovieTexture m){
		this.movie = m;
		renderer.material.mainTexture = movie as MovieTexture;
		movie.loop = false;
		movie.Stop ();
		//audio.Play ();
		movie.Play();
	}
	
	public void PlayMovie(MovieTexture m, AudioClip a){
		this.movie = m;
		audio.clip = a;
		renderer.material.mainTexture = movie as MovieTexture;
		movie.loop = false;
		movie.Stop ();
		audio.loop = false;
		audio.Stop();
		audio.Play ();
		movie.Play();
	}
	
	public bool IsFinishPlaying(){
		return !movie.isPlaying;
	}
}
