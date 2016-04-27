using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuControll : MonoBehaviour {



	public bool isOnMainMenu;
	private float volume;
	private int graphicQuality;
	public GameObject mainMenu, credits, options, newGame;
	public EventSystem evento;
	public GameObject newGameButton;
	public GameObject backOptions;
	public GameObject backCredits;
	public GameObject singlePlayerButton;

	void Start(){
		isOnMainMenu = true;
		mainMenu.SetActive (true);
		credits.SetActive (false);
		options.SetActive (false);
		newGame.SetActive (false);
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
	//
	public void ButtonOptions(){
		mainMenu.SetActive (false);
		credits.SetActive (false);
		newGame.SetActive (false);
		options.SetActive (true);
		evento.SetSelectedGameObject (backOptions);
	}

	public void ButtonCredits(){
		SceneManager.LoadScene (4);
	}

	public void ButtonBack(){

		if (credits.activeSelf) {
			credits.SetActive(false);
		}
		if (options.activeSelf) {
			options.SetActive(false);
		}
		if (newGame.activeSelf) {
			newGame.SetActive (false);
		}
		mainMenu.SetActive (true);
		evento.SetSelectedGameObject (newGameButton);
	}

	public void ButtonNewGame(){
		mainMenu.SetActive (false);
		credits.SetActive (false);
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
