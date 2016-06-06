using UnityEngine;
using System.Collections;

public class CutsceneInicialMusica : MonoBehaviour {

	public AudioSource audio;
	public AudioClip intro, loop;
	public bool loopPlaying;

	// Use this for initialization
	void Start () {
		audio.clip = intro;
		audio.loop = false;
		audio.Play ();
		loopPlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!audio.isPlaying && !loopPlaying) {
			audio.clip = loop;
			audio.loop = true;
			audio.Play ();
			loopPlaying = true;
		}
	}
}
