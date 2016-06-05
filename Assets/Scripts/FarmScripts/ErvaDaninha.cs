using UnityEngine;
using System.Collections;
using Fungus;

public class ErvaDaninha : MonoBehaviour {
	public GameObject player;
	public GameObject particle;

	void OnTriggerEnter(Collider hit){
		if(hit.CompareTag("TurnipAtk")){
			player.GetComponentInChildren<AudioManager> ().PlaySound (2);
			GameObject particula = GameObject.Instantiate (particle, this.transform.position, hit.transform.rotation) as GameObject;
			DialogHandlerTutorial.countDaninha++;
			Destroy (particula, 3);
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision hit){
		if(hit.gameObject.CompareTag("Nabo")){
			player.GetComponentInChildren<AudioManager> ().PlaySound (2);
			DialogHandlerTutorial.countDaninha++;
			Destroy (gameObject);
		}
	}

}
