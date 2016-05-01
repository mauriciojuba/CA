using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuControll : MonoBehaviour {



	public bool isOnMainMenu;
	private float volume;
	private int graphicQuality;
	public GameObject mainMenu, options, newGame;
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

	void Start(){
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
		//		//qualidades graficas
		//		if (PlayerPrefs.HasKey ("graphicQuality")) {
		//			graphicQuality = PlayerPrefs.GetInt ("graphicQuality");
		//		} else {
		//			PlayerPrefs.SetInt("graphicQuality", graphicQuality);
		//		}
		//
	}

	void Update(){

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

	public void ButtonQuit(){
		Application.Quit();
	}



}
