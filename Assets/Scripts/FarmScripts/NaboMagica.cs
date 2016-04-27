using UnityEngine;
using System.Collections;

public class NaboMagica : MonoBehaviour {
	public GameObject nabo;
	private GameObject player;

	void Start(){
		player = GameObject.FindWithTag ("Player1");
	}

	public void NaboAnimar(){
		nabo.GetComponent<Animation>().enabled = true;
	}

	public void NaboSound(){
		player.GetComponentInChildren<AudioManager> ().PlaySound (4);
	}
}
