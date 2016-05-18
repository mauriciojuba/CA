using UnityEngine;
using System.Collections;

public class TriggerHelp : MonoBehaviour {

	public GameObject help;

	public void OnTriggerStay(Collider hit){
		if (hit.gameObject.tag == "Player1" || hit.gameObject.tag == "Player2") {
			help.SetActive (true);
		} else {
			help.SetActive (false);
		}
	}
}
