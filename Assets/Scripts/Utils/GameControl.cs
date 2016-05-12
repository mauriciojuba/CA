using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public static GameControl control;
	public AudioClip menuCircular;
	public AudioClip farm, cave, forest;
	public string CamponesaNome;

	// Use this for initialization
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this)
			Destroy (gameObject);

	}

	void Start(){
		if (SceneManager.GetActiveScene ().buildIndex == 2){
			this.gameObject.GetComponent<AudioSource> ().clip = farm;
		}
		else if (SceneManager.GetActiveScene ().buildIndex == 3){
			this.gameObject.GetComponent<AudioSource> ().clip = cave;
		}
		else if (SceneManager.GetActiveScene ().buildIndex == 4){
			this.gameObject.GetComponent<AudioSource> ().clip = forest;
		}
		this.gameObject.GetComponent<AudioSource> ().Play ();
	}

	public void FimJogo(){
		SceneManager.LoadScene (5);
	}
}
