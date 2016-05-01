using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class SwitchPlayer : MonoBehaviour
{
	GameObject player1, player2;
	string controlling;

	public void Start()
	{
		player1 = GameObject.FindWithTag ("Player1");
		player2 = GameObject.FindWithTag ("Player2");
		controlling = "Player1";
	}

	public void Update()
	{
		if (controlling == "Player1")
		{

//			player1.GetComponent<CamponesaController>().enabled = true;
//			player2.GetComponent<TurnipController>().enabled = false;
			player1.GetComponent<FSM_Camponesa>().enabled = false;
			player2.GetComponent<FSM_Turnip>().enabled = true;
		}
		else if (controlling == "Player2")
		{


//			player2.GetComponent<TurnipController>().enabled = true;
//			player1.GetComponent<CamponesaController>().enabled = false;
			player1.GetComponent<FSM_Camponesa>().enabled = true;
			player2.GetComponent<FSM_Turnip> ().enabled = false;
		}
	}

	public void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.E))
		{
			if (controlling == "Player1")
			{
				controlling = "Player2";
			}
			else if (controlling == "Player2")
			{
				controlling = "Player1";
			}
		}
	}
}
