using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public static GameControl control;
	public AudioClip menuCircular;
	public AudioClip farm, cave, forest, menu, credits, gameover;
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
		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			this.gameObject.GetComponent<AudioSource> ().clip = menu;
		}else if (SceneManager.GetActiveScene ().buildIndex == 1){
			this.gameObject.GetComponent<AudioSource> ().clip = menu;
		} else if (SceneManager.GetActiveScene ().buildIndex == 2) {
			this.gameObject.GetComponent<AudioSource> ().clip = farm;
		} else if (SceneManager.GetActiveScene ().buildIndex == 3) {
			this.gameObject.GetComponent<AudioSource> ().clip = cave;
		} else if (SceneManager.GetActiveScene ().buildIndex == 4) {
			this.gameObject.GetComponent<AudioSource> ().clip = forest;
		} else if (SceneManager.GetActiveScene ().buildIndex == 5) {
			this.gameObject.GetComponent<AudioSource> ().clip = credits;
		}
		this.gameObject.GetComponent<AudioSource> ().Play ();
	}

	void Update(){
		if (SceneManager.GetActiveScene ().buildIndex == 0 && this.gameObject.GetComponent<AudioSource> ().clip != menu) {
			this.gameObject.GetComponent<AudioSource> ().clip = menu;
		}
		else if (SceneManager.GetActiveScene ().buildIndex == 1 && this.gameObject.GetComponent<AudioSource> ().clip != menu){
			this.gameObject.GetComponent<AudioSource> ().clip = menu;
		}
		else if (SceneManager.GetActiveScene ().buildIndex == 2 && this.gameObject.GetComponent<AudioSource> ().clip != farm){
			this.gameObject.GetComponent<AudioSource> ().clip = farm;
		}
		else if (SceneManager.GetActiveScene ().buildIndex == 3 && this.gameObject.GetComponent<AudioSource> ().clip != cave){
			this.gameObject.GetComponent<AudioSource> ().clip = cave;
		}
		else if (SceneManager.GetActiveScene ().buildIndex == 4 && this.gameObject.GetComponent<AudioSource> ().clip != forest){
			this.gameObject.GetComponent<AudioSource> ().clip = forest;
		}
		else if (SceneManager.GetActiveScene ().buildIndex == 5 && this.gameObject.GetComponent<AudioSource> ().clip != credits) {
			this.gameObject.GetComponent<AudioSource> ().clip = credits;
		}
		if(!this.gameObject.GetComponent<AudioSource> ().isPlaying)
			this.gameObject.GetComponent<AudioSource> ().Play ();
	}

	public void FimJogo(){
		SceneManager.LoadScene (7);
	}
}
