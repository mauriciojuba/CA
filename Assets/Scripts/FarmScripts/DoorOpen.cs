using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

	public bool canOpen1, open1;
	public bool canOpen2, open2;
	public GameObject porta1;
	public GameObject porta2;
	public GameObject porta3;
	public GameObject porta4;
	public GameObject player;
	public GameObject naboVidaEvento;
	public GameObject texto;

	// Use this for initialization
	void Start () {
		canOpen1 = false;
		canOpen2 = false;
		open1 = false;
		open2 = false;
		texto.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.players == 2) {
			if (InputManager.YButton2 () && canOpen1) {
				porta1.GetComponent<Animation> ().Play ();
				porta2.GetComponent<Animation> ().Play ();
				player.GetComponent<DialogHandlerTutorial> ().ActivateFollowCamponesa ();
				canOpen1 = false;
				open1 = true;
				naboVidaEvento.SetActive (true);
			}	
		} else {
			if (InputManager.YButton () && canOpen1) {
				porta1.GetComponent<Animation> ().Play ();
				porta2.GetComponent<Animation> ().Play ();
				player.GetComponent<DialogHandlerTutorial> ().ActivateFollowCamponesa ();
				canOpen1 = false;
				open1 = true;
				naboVidaEvento.SetActive (true);
			}
		}
		if (InputManager.YButton() && canOpen2) {
			porta3.GetComponent<Animation> ().Play ();
			porta4.GetComponent<Animation> ().Play ();
			player.GetComponent<DialogHandlerTutorial> ().message = "FIM";
			player.GetComponent<DialogHandlerTutorial> ().canTalk = true;
			canOpen2 = false;
			open2 = true;
		}
	}

	void OnTriggerEnter(Collider hit){
		if (hit.tag == "Player2") {
			if (!open1) {
				canOpen1 = true;
				texto.SetActive (true);
			}
		}
		if (hit.tag == "Player1") {
			if (!open2) {
				canOpen2 = true;
				texto.SetActive (true);
			}
		}
	}

	void OnTriggerExit(Collider hit){
		if (hit.tag == "Player2") {
			canOpen1 = false;
			texto.SetActive (false);
		}
		if (hit.tag == "Player1") {
			canOpen2 = false;
			texto.SetActive (false);
		}
	}
}
