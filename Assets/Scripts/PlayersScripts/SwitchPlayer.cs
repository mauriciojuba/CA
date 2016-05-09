using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class SwitchPlayer : MonoBehaviour
{
	GameObject player1, player2;
	string controlling;

	private bool Onground = true;
	public float TimeTroca;

	public void Start()
	{
		if (InputManager.players == 2)
			this.enabled = false;
		player1 = GameObject.FindWithTag ("Player1");
		player2 = GameObject.FindWithTag ("Player2");
		controlling = "Player1";
		if (InputManager.players == 2) {
			this.enabled = false;
		}
	}

	public void Update()
	{
		if (Input.GetButtonDown ("XBOX_buttonA")) {
			Onground = false;
			TimeTroca = 2.5f;
		}

		if (TimeTroca < 0)
			Onground = true;

		if (player1 != null && player2 != null) {
			if (controlling == "Player1") {
				
				player1.GetComponent<ThirdPersonUserControlCamponesa> ().enabled = true;
				player2.GetComponent<ThirdPersonUserControlTurnip> ().enabled = false;
				player1.GetComponent<FSM_Camponesa> ().enabled = false;
				player2.GetComponent<FSM_Turnip> ().enabled = true;
				player1.transform.FindChild ("SelectedPlayer").GetComponent<MeshRenderer> ().enabled = true;
				player2.transform.FindChild ("SelectedPlayer").GetComponent<MeshRenderer> ().enabled = false;

			} else if (controlling == "Player2") {
				
				player2.GetComponent<ThirdPersonUserControlTurnip> ().enabled = true;
				player1.GetComponent<ThirdPersonUserControlCamponesa> ().enabled = false;
				player1.GetComponent<FSM_Camponesa> ().enabled = true;
				player2.GetComponent<FSM_Turnip> ().enabled = false;
				player1.transform.FindChild ("SelectedPlayer").GetComponent<MeshRenderer> ().enabled = false;
				player2.transform.FindChild ("SelectedPlayer").GetComponent<MeshRenderer> ().enabled = true;

			}

			if (Input.GetKeyDown (KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.E))
			{
				if (Onground) {
					if (controlling == "Player1") {
						controlling = "Player2";
					} else if (controlling == "Player2") {
						controlling = "Player1";
					}
				}
			}

		} else if (player1 == null) {
			
			player2.GetComponent<ThirdPersonUserControlTurnip> ().enabled = true;
			player2.GetComponent<FSM_Turnip> ().enabled = false;
			player2.transform.FindChild ("SelectedPlayer").GetComponent<MeshRenderer> ().enabled = true;
			controlling = "Player2";

		} else if (player2 == null) {
			player1.GetComponent<ThirdPersonUserControlCamponesa> ().enabled = true;
			player1.GetComponent<FSM_Camponesa> ().enabled = false;
			player1.transform.FindChild ("SelectedPlayer").GetComponent<MeshRenderer> ().enabled = true;
			controlling = "Player1";
		}


	}

	public void FixedUpdate()
	{
		TimeTroca -= Time.deltaTime;
	}
		
		
}
