using UnityEngine;
using System.Collections;
using Fungus;

public class ErvaDaninha : MonoBehaviour {
	public GameObject player;

	void OnTriggerEnter(Collider hit){
		if(hit.CompareTag("Player1") || hit.CompareTag("Player2")){
			player.GetComponentInChildren<AudioManager> ().PlaySound (2);
			player.GetComponent<DialogHandlerTutorial> ().countDaninha++;
			Destroy (gameObject);
		}
	}

}
