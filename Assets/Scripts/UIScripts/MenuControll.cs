using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuControll : MonoBehaviour {


	private float dampTime;
	public bool isOnMainMenu;
	private float volume;
	private int graphicQuality;
	public GameObject mainMenu, options, newGame;
	public GameObject painelQuit;
	public GameObject volumeSlider;
	public GameObject nao;
	public EventSystem evento;
	public GameObject optionsButton;
	public GameObject quitButton;
	public GameObject newGameButton;
	public GameObject singlePlayerButton;
	public GameObject qualityButton;
	public GameObject musicButton;
	public GameObject highButton;
	public GameObject mediumButton;
	public GameObject lowButton;
	public GameObject pressA;
	public GameObject pressB;
	public GameObject pressAny;
	public float countPressAny;
	private bool canPressAny;
	private bool musicSelected;
	private bool qualitySelected;
	public Slider vol;


	void Start(){
		countPressAny = 0;
		dampTime = 0;
		painelQuit.SetActive (false);
		pressA.SetActive (false);
		pressB.SetActive (false);
		pressAny.SetActive (false);
		canPressAny = false;
		isOnMainMenu = false;
		mainMenu.SetActive (false);
		musicSelected = false;
		qualitySelected = false;
		options.SetActive (false);
		newGame.SetActive (false);
		Time.timeScale = 1;
		
				//preferencias salvas
				//volume
		if (PlayerPrefs.HasKey ("volume")) {
			volume = PlayerPrefs.GetFloat ("volume");
			vol.value = volume;
		} else {
			PlayerPrefs.SetFloat("volume", volume);
		}

				//qualidades graficas
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

	void Update(){
		dampTime += Time.deltaTime;
		ButtonBack ();
		if(qualitySelected)
			NavigateQualityButtons ();
		VolumeChange ();

		if (!isOnMainMenu) {
			countPressAny += Time.deltaTime;
			if (countPressAny > 5) {
				canPressAny = true;
				pressAny.SetActive (true);
				isOnMainMenu = true;
				countPressAny = 0;
			}
		} 

		if (canPressAny) {
			if (Input.anyKeyDown) {
				pressAny.SetActive (false);
				mainMenu.SetActive (true);
				pressA.SetActive (true);
				pressB.SetActive (true);
				canPressAny = false;
				evento.SetSelectedGameObject (newGameButton);
			}
		}
	}


	//
	public void ButtonOptions(){
		mainMenu.SetActive (false);
		newGame.SetActive (false);
		options.SetActive (true);
		evento.SetSelectedGameObject (musicButton);
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

	public void ButtonCredits(){
		SceneManager.LoadScene (4);
	}

	public void ButtonBack(){
		if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
			if (mainMenu.activeSelf) {
				if (painelQuit.activeSelf) {
					painelQuit.SetActive (false);
					evento.SetSelectedGameObject (quitButton);
				} else {
					isOnMainMenu = false;
					mainMenu.SetActive (false);
					pressA.SetActive (false);
					pressB.SetActive (false);
				}
			}

			if (options.activeSelf) {
				if (musicSelected) {
					musicSelected = false;
					volume = vol.value;
					PlayerPrefs.SetFloat("volume", volume);
					evento.SetSelectedGameObject (musicButton);
				} else if (qualitySelected) {
					qualitySelected = false;
					evento.SetSelectedGameObject (qualityButton);
				} else {
					options.SetActive (false);
					mainMenu.SetActive (true);
					evento.SetSelectedGameObject (optionsButton);
				}
			}
			if (newGame.activeSelf) {
				newGame.SetActive (false);
				mainMenu.SetActive (true);
				evento.SetSelectedGameObject (newGameButton);
			}

		}
	}

	public void ButtonNewGame(){
		mainMenu.SetActive (false);
		newGame.SetActive (true);
		options.SetActive (false);
		evento.SetSelectedGameObject (singlePlayerButton);
	}

	public void ButtonSinglePlayer(){
		isOnMainMenu = false;
		InputManager.players = 1;
		SceneManager.LoadScene (1);
	}

	public void ButtonTwoPlayers(){
		isOnMainMenu = false;
		InputManager.players = 2;
		SceneManager.LoadScene(1);
	}

	public void ButtonVolume(){
		musicSelected = true;
		evento.SetSelectedGameObject (volumeSlider);
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

	public void NavigateQualityButtons(){
		if (InputManager.LeftMenuButton()) {
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
			dampTime = 0;
		} else if (InputManager.RightMenuButton()) {
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
			dampTime = 0;
		}
		
	}

	public void HighQuality(){
		QualitySettings.SetQualityLevel (2);
		graphicQuality = 2;
		PlayerPrefs.SetInt("graphicQuality", graphicQuality);
	}

	public void MediumQuality(){
		QualitySettings.SetQualityLevel (1);
		graphicQuality = 1;
		PlayerPrefs.SetInt("graphicQuality", graphicQuality);
	}

	public void LowQuality(){
		QualitySettings.SetQualityLevel (0);
		graphicQuality = 0;
		PlayerPrefs.SetInt("graphicQuality", graphicQuality);
	}

	public void ButtonQuit(){
		painelQuit.SetActive (true);
		evento.SetSelectedGameObject (nao);
	}

	public void ButtonYes(){
		Application.Quit ();
	}

	public void ButtonNo(){
		painelQuit.SetActive (false);
		evento.SetSelectedGameObject (quitButton);
	}

	public void VolumeChange(){
		this.GetComponentInChildren<AudioSource> ().volume = vol.value;
	}


}
