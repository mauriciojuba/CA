using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {
	private float dampTime;
	public bool pause;
	public EventSystem evento;
	public GameObject panelPause, panelOptions, painelSure;
	private int level;
	private float volume;
	public Slider vol;
	private bool musicSelected;
	private bool qualitySelected;
	public GameObject highButton;
	public GameObject mediumButton;
	public GameObject lowButton;
	public GameObject qualityButton;
	public GameObject musicButton;
	public GameObject nao;
	public GameObject volumeSlider;
	public GameObject painelQuit;
	public GameObject camponesaLife;
	public GameObject turnipLife;
	private int graphicQuality;

	// Use this for initialization
	void Start () {
		
		pause = false;
		panelPause.SetActive (false);
		panelOptions.SetActive (true);
		painelSure.SetActive (false);
		musicSelected = false;
		qualitySelected = false;
		Time.timeScale = 1;
	
		if (PlayerPrefs.HasKey ("volume")) {
			volume = PlayerPrefs.GetFloat ("volume");
			vol.value = volume;
		} else {
			PlayerPrefs.SetFloat("volume", volume);
		}

		if (PlayerPrefs.HasKey ("graphicQuality")) {
			graphicQuality = PlayerPrefs.GetInt ("graphicQuality");
		} else {
			PlayerPrefs.SetInt("graphicQuality", graphicQuality);
		}

		if (graphicQuality == 0) {
			QualitySettings.SetQualityLevel (0);
			lowButton.SetActive (true);
			mediumButton.SetActive (false);
			highButton.SetActive (false);
		} else if (graphicQuality == 1) {
			QualitySettings.SetQualityLevel (1);
			lowButton.SetActive (false);
			mediumButton.SetActive (true);
			highButton.SetActive (false);
		} else if (graphicQuality == 2) {
			QualitySettings.SetQualityLevel (2);
			lowButton.SetActive (false);
			mediumButton.SetActive (false);
			highButton.SetActive (true);
		}
	}

	// Update is called once per frame
	void Update () {
		dampTime += Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7)) {
			pause = !pause;

			if (pause == true) {
				panelPause.SetActive (true);
				evento.SetSelectedGameObject (musicButton);
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

	public void Resume(){
		pause = false;
		Time.timeScale = 1;
		Input.ResetInputAxes ();
		panelPause.SetActive (false);
		//musicControl.SetActive (true);
		//		fps.GetComponent <UserInput> ().enabled = true;
		//		fps.GetComponent<CharacterMovement>().enabled = true;


	}

	public void VolumeChange(){
		
	}

	public void Quit(){
		Application.Quit ();
	}
}