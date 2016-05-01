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
	public GameObject volumeSlider;
	public EventSystem evento;
	public GameObject newGameButton;
	public GameObject singlePlayerButton;
	public GameObject qualityButton;
	public GameObject musicButton;
	public GameObject highButton;
	public GameObject mediumButton;
	public GameObject lowButton;
	private bool musicSelected;
	private bool qualitySelected;
	public Slider vol;


	void Start(){
		dampTime = 0;
		isOnMainMenu = true;
		mainMenu.SetActive (true);
		musicSelected = false;
		qualitySelected = false;
		options.SetActive (false);
		newGame.SetActive (false);
		lowButton.SetActive (false);
		mediumButton.SetActive (false);
		Time.timeScale = 1;
		//
		//		//preferencias salvas
		//		//volume
		//		if (PlayerPrefs.HasKey ("volume")) {
		//			volume = PlayerPrefs.GetFloat ("volume");
		//		} else {
		//			PlayerPrefs.SetFloat("volume", volume);
		//		}
				//qualidades graficas
		if (PlayerPrefs.HasKey ("graphicQuality")) {
			graphicQuality = PlayerPrefs.GetInt ("graphicQuality");
		} else {
			PlayerPrefs.SetInt("graphicQuality", graphicQuality);
		}
		if (graphicQuality == 0) {
			QualitySettings.SetQualityLevel (0);
			lowButton.SetActive (true);
		} else if (graphicQuality == 1) {
			QualitySettings.SetQualityLevel (1);
			mediumButton.SetActive (true);
		} else if (graphicQuality == 2) {
			QualitySettings.SetQualityLevel (2);
			highButton.SetActive (true);
		}
				
	}

	void Update(){
		dampTime += Time.deltaTime;
		ButtonBack ();
		if(qualitySelected)
		NavigateQualityButtons ();
	}


	//
	public void ButtonOptions(){
		mainMenu.SetActive (false);
		newGame.SetActive (false);
		options.SetActive (true);
		evento.SetSelectedGameObject (musicButton);
	}

	public void ButtonCredits(){
		SceneManager.LoadScene (4);
	}

	public void ButtonBack(){
		if(Input.GetKeyDown(KeyCode.JoystickButton1)){
			Debug.Log ("voltar");
		if (options.activeSelf) {
				if (musicSelected) {
					musicSelected = false;
					evento.SetSelectedGameObject (musicButton);
				} else if (qualitySelected) {
					qualitySelected = false;
					evento.SetSelectedGameObject (qualityButton);
				} else {
					options.SetActive (false);
					mainMenu.SetActive (true);
					evento.SetSelectedGameObject (newGameButton);
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
		Debug.Log ("Roda Jogo");
		//Application.LoadLevel(1);
		SceneManager.LoadScene (1);
	}

	public void ButtonTwoPlayers(){
		isOnMainMenu = false;
		Debug.Log ("Roda Jogo");
		//Application.LoadLevel(1);
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
		if (Input.GetAxisRaw ("XBOX_DpadHorizontal") > 0 && dampTime > 0.2) {
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
		} else if (Input.GetAxisRaw ("XBOX_DpadHorizontal") < 0 && dampTime > 0.2) {
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
	}

	public void MediumQuality(){
		QualitySettings.SetQualityLevel (1);
		graphicQuality = 1;
	}

	public void LowQuality(){
		QualitySettings.SetQualityLevel (0);
		graphicQuality = 0;
	}

	public void ButtonQuit(){
		Application.Quit();
	}

	public void VolumeChange(){
//		GetComponent<AudioSource> ().volume = vol.value;
	}

}
