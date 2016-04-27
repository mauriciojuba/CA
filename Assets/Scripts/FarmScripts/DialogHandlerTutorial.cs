using UnityEngine;
using System.Collections;
using Fungus;
using UnityStandardAssets.Characters.ThirdPerson;

public class DialogHandlerTutorial : MonoBehaviour {

	public string message;
    public bool canTalk;
	public GameObject girar, trocarPersonagem, atirarNabos;
	public bool begin, change, shoot, final;
	public int count, countDaninha;
	public GameObject camponesa, turnip, triggerCeleiro2;

	void Start () {
		message = "";
		canTalk = false;
		girar.SetActive (true);
		trocarPersonagem.SetActive (false);
		atirarNabos.SetActive (false);
		count = 0;
		countDaninha = 0;
		begin = true;
		change = false;
		shoot = false;
	}
	void Update () {
		if (begin) {
			if (Input.GetKeyDown (KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.X)) {
				TurnipRotate ();
				begin = false;
				change = true;
				ChangeText ();
			}
		}
		if (change) {
			if (Input.GetKeyDown (KeyCode.JoystickButton4) || Input.GetKeyDown(KeyCode.Tab)) {
				ChangePlayer();
				change = false;
				shoot = true;
				ChangeText ();
				camponesa.GetComponent<TacarNabos> ().enabled = true;
			}
		}

		if (count >= 3) {
			count = 0;
			camponesa.GetComponent<TacarNabos> ().enabled = false;
			shoot = false;
			ChangeText ();
			canTalk = true;
			message = "Farm1";
		}
		if (shoot) {
			if (Input.GetKeyDown (KeyCode.Mouse0) || Input.GetKeyDown (KeyCode.JoystickButton2)) {
				count++;
			}
		}

		if (countDaninha == 6) {
			canTalk = true;
			message = "Daninha";
			countDaninha = 0;
		}




        if (canTalk)
        {
			if (message == "Farm1")
			{
				Flowchart.BroadcastFungusMessage(message);
				canTalk = false;
				message = "";
			}

			if (message == "Farm2")
            {
				Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
				message = "";
            }

			if (message == "Farm3")
			{
				Flowchart.BroadcastFungusMessage(message);
				canTalk = false;
				message = "";
			}

			if (message == "TurnipRotate") 
			{
				Flowchart.BroadcastFungusMessage(message);
				canTalk = false;
				message = "";
			}

			if (message == "ChangePlayer") 
			{
				Flowchart.BroadcastFungusMessage(message);
				canTalk = false;
				message = "";
			}

			if (message == "Daninha") 
			{
				Flowchart.BroadcastFungusMessage(message);
				canTalk = false;
				message = "";
			}

			if (message == "TriggerVida") 
			{
				Flowchart.BroadcastFungusMessage(message);
				canTalk = false;
				message = "";
			}

			if (message == "PegouNabo") 
			{
				Flowchart.BroadcastFungusMessage(message);
				canTalk = false;
				message = "";
			}

			if (message == "FIM") 
			{
				Flowchart.BroadcastFungusMessage(message);
				canTalk = false;
				message = "";
			}
        }
	}

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "TriggerCeleiro1")
        {
            canTalk = true;
			message = "Farm2";
        }

		if (hit.tag == "TriggerCeleiro2") {
			canTalk = true;
			message = "Farm3";
		}

		if (hit.tag == "TriggerVida") {
			canTalk = true;
			message = "TriggerVida";
		}
		if (hit.tag == "PegouNabo") {
			canTalk = true;
			message = "PegouNabo";
			triggerCeleiro2.SetActive (true);
		}
    }

    void OnTriggerExit(Collider hit)
    {
            canTalk = false;
    }

	public void TurnipRotate(){
		canTalk = true;
		message = "TurnipRotate";
	}

	public void ChangePlayer(){
		canTalk = true;
		message = "ChangePlayer";
		trocarPersonagem.SetActive (false);
	}

	public void ChangeText(){
		if (begin) {
			girar.SetActive (true);
		} else if (change) {
			trocarPersonagem.SetActive (true);
			girar.SetActive (false);
		} else if (shoot) {
			trocarPersonagem.SetActive (false);
			atirarNabos.SetActive (true);
		} else {
			atirarNabos.SetActive (false);
		}
	}

	public void DesativarPlayers(){
		camponesa.GetComponent<ThirdPersonCharacter> ().enabled = false;
		camponesa.GetComponent<ThirdPersonUserControl> ().enabled = false;
		turnip.GetComponent<ThirdPersonCharacter> ().enabled = false;
		turnip.GetComponent<ThirdPersonUserControl> ().enabled = false;
		turnip.GetComponent<FSM_Turnip> ().enabled = false;
		camponesa.GetComponent<FSM_Camponesa> ().enabled = false;
	}

	public void TurnipActivation(){
		camponesa.GetComponent<ThirdPersonCharacter> ().enabled = false;
		camponesa.GetComponent<ThirdPersonUserControl> ().enabled = false;
		turnip.GetComponent<ThirdPersonCharacter> ().enabled = true;
		turnip.GetComponent<ThirdPersonUserControl> ().enabled = true;
	}

	public void CamponesaActivation(){
		camponesa.GetComponent<ThirdPersonCharacter> ().enabled = true;
		camponesa.GetComponent<ThirdPersonUserControl> ().enabled = true;
		turnip.GetComponent<ThirdPersonCharacter> ().enabled = false;
		turnip.GetComponent<ThirdPersonUserControl> ().enabled = false;
	}

	public void ActivateFollowTurnip(){
		turnip.GetComponent<FSM_Turnip> ().enabled = true;
	}

	public void ActivateFollowCamponesa(){
		camponesa.GetComponent<FSM_Camponesa> ().enabled = true;
	}

}
