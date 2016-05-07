using UnityEngine;
using System.Collections;
using Fungus;

public class ErvaDaninha : MonoBehaviour {
	public GameObject player;

	void OnTriggerEnter(Collider hit){
		if(hit.CompareTag("TurnipAtk")){
			player.GetComponentInChildren<AudioManager> ().PlaySound (2);
			player.GetComponent<DialogHandlerTutorial> ().countDaninha++;
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision hit){
		if(hit.gameObject.CompareTag("Nabo")){
			player.GetComponentInChildren<AudioManager> ().PlaySound (2);
			player.GetComponent<DialogHandlerTutorial> ().countDaninha++;
			Destroy (gameObject);
		}
	}

}
