using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOverControl : MonoBehaviour {

	private float count;
	public GameObject painelContinue, yesButton;
	public EventSystem evento;
	private bool continuar;

	// Use this for initialization
	void Start () {
		count = 0;
		painelContinue.SetActive (false);
		continuar = true;
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;

		if (count > 5 && continuar) {
			painelContinue.SetActive (true);
			evento.SetSelectedGameObject (yesButton);
			continuar = false;
		}
	}

	public void Yes(){
		LoadingScreenManager.LoadScene (3);
	}

	public void No(){
		LoadingScreenManager.LoadScene (0);
	}
}
