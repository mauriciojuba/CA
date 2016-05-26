using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

	public bool canOpen1;
	public bool canOpen2;
	public static bool open1;
	public static bool open2;
	public GameObject porta1;
	public GameObject porta2;
	public GameObject porta3;
	public GameObject porta4;
	public GameObject player;
	public GameObject naboVidaEvento;
	public GameObject texto1, texto2;

	// Use this for initialization
	void Start () {
		canOpen1 = false;
		canOpen2 = false;
		open1 = false;
		open2 = false;
		texto1.SetActive (false);
		texto2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.YButton () && canOpen1) {
			 	canOpen1 = false;
				open1 = true;
				naboVidaEvento.SetActive (true);
				texto1.SetActive (false);
				Destroy(GameObject.Find("BarreiraEvento"));
				Destroy (this.gameObject);
			}

		if (InputManager.YButton() && canOpen2) {
			porta3.GetComponent<Animation> ().Play ();
			porta4.GetComponent<Animation> ().Play ();
			player.GetComponent<DialogHandlerTutorial> ().message = "FIM";
			player.GetComponent<DialogHandlerTutorial> ().canTalk = true;
			canOpen2 = false;
			open2 = true;
			texto2.SetActive (false);
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider hit){
		if (hit.tag == "Player2") {
			if (!open1) {
				canOpen1 = true;
				texto1.SetActive (true);
			}
		}
		if (hit.tag == "Player1") {
			if (!open2 && open1) {
				canOpen2 = true;
				texto2.SetActive (true);
			}
		}
	}

	void OnTriggerExit(Collider hit){
		if (hit.tag == "Player2") {
			canOpen1 = false;
			texto1.SetActive (false);
		}
		if (hit.tag == "Player1") {
			canOpen2 = false;
			texto2.SetActive (false);
		}
	}
}
