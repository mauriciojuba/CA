using UnityEngine;
using System.Collections;

public class MusicsCave : MonoBehaviour {

	public AudioClip[] Musics;
	public AudioSource Musica;

	// Use this for initialization
	void Start () {
		Musica.clip = Musics [0];
		Musica.Play ();
	}
	public void  Mudamusica(){
			Musica.clip = Musics [1];
			Musica.Play ();
	}
}
