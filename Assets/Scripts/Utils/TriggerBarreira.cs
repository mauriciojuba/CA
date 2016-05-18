using UnityEngine;
using System.Collections;
using Fungus;

public class TriggerBarreira : MonoBehaviour {

	public string Message;

	public void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "Player1" || hit.gameObject.tag == "Player2") {
			Flowchart.BroadcastFungusMessage (Message);
			Destroy (gameObject);
		}
	}
}
