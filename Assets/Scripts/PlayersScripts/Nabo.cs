using UnityEngine;
using System.Collections;

public class Nabo : MonoBehaviour {

	void OnTriggerEnter(Collider hit){
		if(hit.CompareTag("Player1") || hit.CompareTag("Player2")){
			hit.GetComponent<PlayersDamangeHandler>().RecoveryPlayer(40f);
			hit.gameObject.GetComponentInChildren<AudioManager> ().PlaySound (1);
			Destroy (gameObject);
		}
	}
}
