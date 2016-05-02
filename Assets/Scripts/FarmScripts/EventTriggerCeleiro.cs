using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class EventTriggerCeleiro : MonoBehaviour {
	GameObject player1, player2;
	// Use this for initialization
	void Start () {
		player1 = GameObject.FindWithTag ("Player1");
		player2 = GameObject.FindWithTag ("Player2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TurnipActivation(){
		player1.GetComponent<ThirdPersonCharacter> ().enabled = false;
		player1.GetComponent<ThirdPersonUserControlCamponesa> ().enabled = false;
		player2.GetComponent<ThirdPersonCharacter> ().enabled = true;
		player2.GetComponent<ThirdPersonUserControlTurnip> ().enabled = true;
	}

	public void CamponesaActivation(){
		player1.GetComponent<ThirdPersonCharacter> ().enabled = true;
		player1.GetComponent<ThirdPersonUserControlCamponesa> ().enabled = true;
		player2.GetComponent<ThirdPersonCharacter> ().enabled = false;
		player2.GetComponent<ThirdPersonUserControlTurnip> ().enabled = false;
	}
}
