using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuControll : MonoBehaviour {


	private float dampTime;
	public bool isOnMainMenu;
	private float volume = 0.5f;
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
	public GameObject leftSelectN, leftSelectH;
	public GameObject rightSelectN, rightSelectH;
	Camera mainCam;
	Animator camAnim;

	void Start(){
		mainCam = Camera.main;
		camAnim = mainCam.GetComponent<Animator>();
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
            PlayerPrefs.SetFloat("volume", volume);
            vol.value = volume;
            VolumeChange();
        } else {
			PlayerPrefs.SetFloat("volume", volume);
            vol.value = volume;
            VolumeChange();
        }
        vol.value = 0.5f;
        VolumeChange();

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
			if (countPressAny > 1) {
				StartCoroutine(PressAnyFade());
				pressAny.SetActive (true);
				isOnMainMenu = true;
				countPressAny = 0;
			}
		} 

		if (canPressAny) {
			if (Input.anyKeyDown) {
				camAnim.Rebind();
				camAnim.speed=1;
				camAnim.Play("cameraMovement",-1,0f);
				StartCoroutine(MenuFade());

			}
		}
	}


		
	//
	public void ButtonOptions(){
		mainMenu.SetActive (false);
		newGame.SetActive (false);
		options.SetActive (true);
		evento.SetSelectedGameObject (musicButton);
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
	}

	public void ButtonCredits(){
		SceneManager.LoadScene (5);
	}

	public void ButtonBack(){
		if (InputManager.BButton()) {
			if (mainMenu.activeSelf) {
				if (painelQuit.activeSelf) {
					painelQuit.SetActive (false);
					evento.SetSelectedGameObject (quitButton);
				} else {
					camAnim.Rebind();
					camAnim.Play("cameraReverse",-1,0f);
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
//		SceneManager.LoadScene (6);
		LoadingScreenManager.LoadScene(6);
	}

	public void ButtonTwoPlayers(){
		isOnMainMenu = false;
		InputManager.players = 2;
//		SceneManager.LoadScene(6);
		LoadingScreenManager.LoadScene(6);
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
			leftSelectH.SetActive (false);
			leftSelectN.SetActive (true);
			rightSelectH.SetActive (true);
			rightSelectN.SetActive (false);
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
			leftSelectH.SetActive (true);
			leftSelectN.SetActive (false);
			rightSelectH.SetActive (false);
			rightSelectN.SetActive (true);
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
		GameObject.Find("GameControl").GetComponent<AudioSource> ().volume = vol.value;
	}

	IEnumerator PressAnyFade(){
		float counter = 0;
		float timeToFade = 1.0f;

		Image pressAnyImg = pressAny.GetComponent<Image>(); 

		Color startColor = Color.white;
		Color endColor = Color.white;
		Color currentColor = startColor;

		startColor.a = 0;

		pressAny.SetActive (true);


		while(counter<timeToFade){
			counter+=Time.deltaTime;
			currentColor = Color.Lerp(startColor,endColor,counter);
			pressAnyImg.color = currentColor;

			yield return null;
		}
		canPressAny = true;

		yield return null;
	}

	IEnumerator MenuFade(){
		float counter = 0;
		float timeToFade = 1.0f;

		Image pressAnyImg = pressAny.GetComponent<Image>(); 
		Image mainMenuImg = mainMenu.GetComponent<Image>();
		Image pressAImg = pressA.GetComponent<Image>();
		Image pressBImg = pressB.GetComponent<Image>();

		Color startColor = Color.white;
		Color endColor = Color.white;
		Color currentColor = startColor;
		Color invertedColor = endColor;

		startColor.a = 0;

		mainMenu.SetActive (true);
		pressA.SetActive (true);
		pressB.SetActive (true);

		while(counter<timeToFade){
			counter+=Time.deltaTime;
			currentColor = Color.Lerp(startColor,endColor,counter);
			invertedColor = Color.Lerp(endColor,startColor,counter);
			mainMenuImg.color = currentColor;
			pressAnyImg.color = invertedColor;
			pressAImg.color = currentColor;
			pressBImg.color = currentColor;

			yield return null;
		}
		canPressAny = false;
		evento.SetSelectedGameObject (newGameButton);
		pressAny.SetActive(false);
		yield return null;
	}


}
