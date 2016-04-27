using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

	public bool pause;
	public EventSystem evento;
	public GameObject panelPause, panelOptions;
	public GameObject fps;
	private int level;
	public GameObject button, volume;
	public Slider vol;

	// Use this for initialization
	void Start () {
		panelPause = GameObject.FindWithTag ("PauseMenu");
		panelOptions = GameObject.FindWithTag ("OptionsMenu");
		fps = GameObject.FindWithTag ("Player1");
		pause = false;
		panelPause.SetActive (false);
		panelOptions.SetActive (false);
		level = Application.loadedLevel;
		fps.GetComponent<AudioSource> ().volume = vol.value;
	}

	// Update is called once per frame
	void Update () {

		if (fps == null) {
			fps = GameObject.FindWithTag ("Player1");
		}

		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7)) {
			pause = !pause;

			if (pause == true) {
				panelPause.SetActive (true);
				evento.SetSelectedGameObject (button);
				//Pause tudo que for automatico no unit
				Time.timeScale = 0;

				//Pause the other objects
				//musicControl.SetActive(false);
				//				fps.GetComponent<UserInput>().enabled = false;
				//				fps.GetComponent<CharacterMovement>().enabled = false;

			} else {
				Resume ();

			}
		}
	}

	public void NewGame(){
		pause = false;
		panelPause.SetActive (false);
		Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevel);
	}

	public void Resume(){
		pause = false;
		Time.timeScale = 1;
		Input.ResetInputAxes ();
		panelPause.SetActive (false);
		//musicControl.SetActive (true);
		//		fps.GetComponent <UserInput> ().enabled = true;
		//		fps.GetComponent<CharacterMovement>().enabled = true;


	}

	public void Options(){
		panelPause.SetActive (false);
		panelOptions.SetActive (true);
		evento.SetSelectedGameObject (volume);
	}


	public void ButtonBack(){
		panelOptions.SetActive (false);
		panelPause.SetActive (true);
		evento.SetSelectedGameObject (button);

	}

	public void VolumeChange(){
		fps.GetComponent<AudioSource> ().volume = vol.value;
	}

	public void Quit(){
		Application.Quit ();
	}
}