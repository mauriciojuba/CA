using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

	public bool canOpen1;
	public bool canOpen2;
	public GameObject porta1;
	public GameObject porta2;
	public GameObject porta3;
	public GameObject porta4;
	public GameObject player;
	public GameObject naboVidaEvento;

	// Use this for initialization
	void Start () {
		canOpen1 = false;
		canOpen2 = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.players == 2) {
			if (InputManager.YButton2 () && canOpen1) {
				porta1.GetComponent<Animation> ().Play ();
				porta2.GetComponent<Animation> ().Play ();
				player.GetComponent<DialogHandlerTutorial> ().ActivateFollowCamponesa ();
				canOpen1 = false;
				naboVidaEvento.SetActive (true);
			}	
		} else {
			if (InputManager.YButton () && canOpen1) {
				porta1.GetComponent<Animation> ().Play ();
				porta2.GetComponent<Animation> ().Play ();
				player.GetComponent<DialogHandlerTutorial> ().ActivateFollowCamponesa ();
				canOpen1 = false;
				naboVidaEvento.SetActive (true);
			}
		}
		if (InputManager.YButton() && canOpen2) {
			porta3.GetComponent<Animation> ().Play ();
			porta4.GetComponent<Animation> ().Play ();
			player.GetComponent<DialogHandlerTutorial> ().message = "FIM";
			player.GetComponent<DialogHandlerTutorial> ().canTalk = true;
			canOpen2 = false;
		}
	}

	void OnTriggerEnter(Collider hit){
		if (hit.tag == "Player2") 
			canOpen1 = true;
	
		if (hit.tag == "Player1")
			canOpen2 = true;
	}

	void OnTriggerExit(Collider hit){
		if (hit.tag == "Player2") 
			canOpen1 = false;

		if (hit.tag == "Player1")
			canOpen2 = false;
	}
}
