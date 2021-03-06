﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Fungus;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour {
	private float dampTime;
	public bool pause;
	public EventSystem evento;
	public GameObject panelPause;
	public GameObject panelOptions, painelSure;
	private int level;
	private float volume;
	private float volumeSfx;
	public Slider vol;
	public Slider volSfx;
	private bool musicSelected;
	private bool sfxSelected;
	private bool qualitySelected;
	public GameObject highButton;
	public GameObject mediumButton;
	public GameObject lowButton;
	public GameObject qualityButton;
	public GameObject musicButton;
	public GameObject sfxButton;
	public GameObject backToMenuButton;
	public GameObject nao;
	public GameObject volumeSlider;
	public GameObject volumeSfxSlider;
	public GameObject hudPlayers;
	public Image camponesaLife1, camponesaLife2;
	public Image turnipLife1, turnipLife2;
	public Image lifePause1;
	public Image lifePause2;
	private int graphicQuality;
	public GameObject leftSelectN, leftSelectH;
	public GameObject rightSelectN, rightSelectH;
	public AudioMixer masterMixer;

	// Use this for initialization
	void Start () {
		panelPause = GameObject.Find ("PauseMenu");
		pause = false;
		panelPause.SetActive (false);
		panelOptions.SetActive (true);
		painelSure.SetActive (false);
		musicSelected = false;
		qualitySelected = false;
		Time.timeScale = 1;
		rightSelectH.SetActive (false);
		leftSelectH.SetActive (false);

		if (PlayerPrefs.HasKey ("volume")) {
			volume = PlayerPrefs.GetFloat ("volume");
			vol.value = volume;
		} else {
			PlayerPrefs.SetFloat("volume", volume);
		}
		if (PlayerPrefs.HasKey ("volumeSfx")) {
			volumeSfx = PlayerPrefs.GetFloat ("volumeSfx");
			volSfx.value = volumeSfx;
		} else {
			PlayerPrefs.SetFloat("volumeSfx", volumeSfx);
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
		if(pause)
			Flowchart.BroadcastFungusMessage ("pause");
		dampTime += Time.deltaTime;
		ButtonBack ();
		if(qualitySelected)
			NavigateQualityButtons ();
		VolumeChange ();

		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7)) {
			pause = !pause;

			if (pause == true) {
				panelPause.SetActive (true);
				evento.SetSelectedGameObject (musicButton);
				//Pause tudo que for automatico no unit
				Time.timeScale = 0;
				if (InputManager.players == 2) {
					lifePause1.fillAmount = camponesaLife2.fillAmount;
					lifePause2.fillAmount = turnipLife2.fillAmount;
					hudPlayers.SetActive (false);
				} else {
					lifePause1.fillAmount = camponesaLife1.fillAmount;
					lifePause2.fillAmount = turnipLife1.fillAmount;
					hudPlayers.SetActive (false);
				}
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
		hudPlayers.SetActive (true);
		panelPause.SetActive (false);
		//musicControl.SetActive (true);
		//		fps.GetComponent <UserInput> ().enabled = true;
		//		fps.GetComponent<CharacterMovement>().enabled = true;


	}

	public void ButtonBack(){
		if (InputManager.BButton ()) {
			if (panelPause.activeSelf) {
				if (panelOptions.activeSelf) {
					if (musicSelected) {
						musicSelected = false;
						volume = vol.value;
						PlayerPrefs.SetFloat ("volume", volume);
						evento.SetSelectedGameObject (musicButton);
					} else if (sfxSelected) {
						sfxSelected = false;
						volumeSfx = volSfx.value;
						PlayerPrefs.SetFloat ("volumeSfx", volumeSfx);
						evento.SetSelectedGameObject (sfxButton);
					} else if (qualitySelected) {
						qualitySelected = false;
						evento.SetSelectedGameObject (qualityButton);
						leftSelectH.SetActive (false);
						leftSelectN.SetActive (true);
						rightSelectH.SetActive (false);
						rightSelectN.SetActive (true);
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
					} else {
						Resume ();
					}
				}
				if (painelSure.activeSelf) {
					painelSure.SetActive (false);
					panelOptions.SetActive (true);
					evento.SetSelectedGameObject (backToMenuButton);
				}
			}
		}
	}

	public void ButtonBackToMenu(){
		panelOptions.SetActive (false);
		painelSure.SetActive (true);
		evento.SetSelectedGameObject (nao);
	}

	public void ButtonQuality(){
		qualitySelected = true;
		if (graphicQuality == 0) {
			evento.SetSelectedGameObject (lowButton);
		} else if (graphicQuality == 1) {
			evento.SetSelectedGameObject (mediumButton);
		} else if (graphicQuality == 2) {
			evento.SetSelectedGameObject (highButton);
		}

	}

	public void ButtonNo(){
		painelSure.SetActive (false);
		panelOptions.SetActive (true);
		evento.SetSelectedGameObject (backToMenuButton);
	}

	public void ButtonYes(){
		SceneManager.LoadScene(0);
	}

	public void VolumeChange(){
		GameObject.Find("Musica").GetComponent<AudioSource> ().volume = vol.value;
	}

	public void NavigateQualityButtons(){
		if (InputManager.LeftMenuButton() || Input.GetKeyDown(KeyCode.D)) {
			if (highButton.activeSelf) {
				highButton.SetActive (false);
				lowButton.SetActive (true);
				evento.SetSelectedGameObject (lowButton);
			} else if (mediumButton.activeSelf) {
				mediumButton.SetActive (false);
				highButton.SetActive (true);
				evento.SetSelectedGameObject (highButton);
			} else if (lowButton.activeSelf) {
				lowButton.SetActive (false);
				mediumButton.SetActive (true);
				evento.SetSelectedGameObject (mediumButton);
			}
			leftSelectH.SetActive (false);
			leftSelectN.SetActive (true);
			rightSelectH.SetActive (true);
			rightSelectN.SetActive (false);
		} else if (InputManager.RightMenuButton() || Input.GetKeyDown(KeyCode.A)) {
			if (highButton.activeSelf) {
				highButton.SetActive (false);
				mediumButton.SetActive (true);
				evento.SetSelectedGameObject (mediumButton);
			} else if (mediumButton.activeSelf) {
				mediumButton.SetActive (false);
				lowButton.SetActive (true);
				evento.SetSelectedGameObject (lowButton);
			} else if (lowButton.activeSelf) {
				lowButton.SetActive (false);
				highButton.SetActive (true);
				evento.SetSelectedGameObject (highButton);
			}
			leftSelectH.SetActive (true);
			leftSelectN.SetActive (false);
			rightSelectH.SetActive (false);
			rightSelectN.SetActive (true);
		}

	}

	public void ButtonVolume(){
		musicSelected = true;
		evento.SetSelectedGameObject (volumeSlider);
	}
	public void ButtonVolumeSfx(){
		sfxSelected = true;
		evento.SetSelectedGameObject (volumeSfxSlider);
	}

	public void HighQuality(){
		QualitySettings.SetQualityLevel (2);
		graphicQuality = 2;
		PlayerPrefs.SetInt("graphicQuality", graphicQuality);
		leftSelectH.SetActive (false);
		leftSelectN.SetActive (true);
		rightSelectH.SetActive (false);
		rightSelectN.SetActive (true);
		qualitySelected = false;
		evento.SetSelectedGameObject (qualityButton);
	}

	public void MediumQuality(){
		QualitySettings.SetQualityLevel (1);
		graphicQuality = 1;
		PlayerPrefs.SetInt("graphicQuality", graphicQuality);
		leftSelectH.SetActive (false);
		leftSelectN.SetActive (true);
		rightSelectH.SetActive (false);
		rightSelectN.SetActive (true);
		qualitySelected = false;
		evento.SetSelectedGameObject (qualityButton);
	}

	public void LowQuality(){
		QualitySettings.SetQualityLevel (0);
		graphicQuality = 0;
		PlayerPrefs.SetInt("graphicQuality", graphicQuality);
		leftSelectH.SetActive (false);
		leftSelectN.SetActive (true);
		rightSelectH.SetActive (false);
		rightSelectN.SetActive (true);
		qualitySelected = false;
		evento.SetSelectedGameObject (qualityButton);
	}

	public void SetSfxLvl(float sfxLvl)
	{
		masterMixer.SetFloat ("sfxVol", sfxLvl);
	}


}