using UnityEngine;
using System.Collections;

public class VerifyPlayers : MonoBehaviour {
	public GameObject lifeTurnip1, lifeCamponesa1;
	public GameObject lifeTurnip2, lifeCamponesa2;
	public GameObject turnip, camponesa;
	// Use this for initialization
	void Start () {

		if (InputManager.players == 2) {
			lifeTurnip1.SetActive (false);
			lifeCamponesa1.SetActive (false);
			lifeTurnip2.SetActive (true);
			lifeCamponesa2.SetActive (true);
		} else if (InputManager.players == 1) {
			lifeCamponesa1.SetActive (true);
			lifeTurnip1.SetActive (false);
			lifeTurnip2.SetActive (false);
			lifeCamponesa2.SetActive (false);
		}
	}

	void Update(){
		if (turnip.GetComponent<SwitchPlayer> ().enabled && camponesa.GetComponent<SwitchPlayer> ().enabled) {
			if (camponesa.GetComponent<SwitchPlayer> ().controlling == "Player2" || turnip.GetComponent<SwitchPlayer>().controlling == "Player2") {
				lifeTurnip1.SetActive (true);
				lifeCamponesa1.SetActive (false);
			} else {
				lifeCamponesa1.SetActive (true);
				lifeTurnip1.SetActive (false);
			}
		}
	}
}
