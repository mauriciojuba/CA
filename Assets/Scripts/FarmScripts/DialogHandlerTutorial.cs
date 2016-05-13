using UnityEngine;
using System.Collections;
using Fungus;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

public class DialogHandlerTutorial : MonoBehaviour {

	public string message;
    public bool canTalk;
	public GameObject girar, trocarPersonagem, atirarNabos, mirarTurnip;
	public bool begin, change, aim, shoot, final;
	public int count;
	public static int countDaninha;
	public GameObject camponesa, turnip, triggerCeleiro2;
	public float delayAtk, delayToTalk;
	public bool toTalk;
	public GameObject dialogCamp, dialogTurnip;

	void Start () {
		message = "começou";
		canTalk = false;
		girar.SetActive (true);
		mirarTurnip.SetActive (false);
		trocarPersonagem.SetActive (false);
		atirarNabos.SetActive (false);
		count = 0;
		toTalk = false;
		delayToTalk = 0;
		countDaninha = 0;
		delayAtk = 0;
		begin = true;
		change = false;
		shoot = false;
		camponesa.GetComponent<SwitchPlayer> ().enabled = false;
		turnip.GetComponent<SwitchPlayer> ().enabled = false;
		turnip.GetComponent<ThirdPersonUserControlTurnip> ().enabled = false;

	}

	void Update () {
		delayAtk += Time.deltaTime;
//
//		if (dialogCamp.activeSelf || dialogTurnip.activeSelf) {
//			
//		}

		if (begin) {
			DesativarPlayers ();
			if (InputManager.players == 2) {
				if (InputManager.XButton2 () || Input.GetKeyDown (KeyCode.X)) {
					TurnipRotate ();
					begin = false;
					aim = true;
					ChangeText ();
				}
			} else {
				if (InputManager.XButton () || Input.GetKeyDown (KeyCode.X)) {
					TurnipRotate ();
					begin = false;
					change = true;
					ChangeText ();
				}
			}
		}
		if (change) {
			if (InputManager.LButton() || Input.GetKeyDown(KeyCode.Tab)) {
				ChangePlayer();
				change = false;
				aim = true;
				ChangeText ();

			}
		}

		if (aim) {
			if (InputManager.RButton () || Input.GetKeyDown (KeyCode.U)) {
				
				aim = false;
				shoot = true;
				ChangeText ();
			}
		}

		if (count >= 3) {
			count = 0;
			toTalk = true;
		}

		if (toTalk) {
			delayToTalk += Time.deltaTime;
			if (delayToTalk > 2) {
				toTalk = false;
				delayToTalk = 0;
				shoot = false;
				ChangeText ();

				camponesa.GetComponent<ThirdPersonUserControlCamponesa> ().selectedTarget.FindChild("SelectedPoint").GetComponent<MeshRenderer>().enabled = false;
				camponesa.GetComponent<ThirdPersonUserControlCamponesa> ().selectedTarget = null;
				camponesa.GetComponent<ThirdPersonUserControlCamponesa> ().targets.Clear();
				camponesa.GetComponent<ThirdPersonUserControlCamponesa> ().AddAllEnemies ();

				canTalk = true;
				if(InputManager.players == 2)
					message = "Farm2Players1";
				else
					message = "Farm1";
			}
		}
			
		if (shoot) {
			if (InputManager.XButton() && delayAtk > 3) {
				count++;
			}
		}

		if (countDaninha == 6) {
			canTalk = true;
			if (InputManager.players == 2) {
				message = "Daninha2Players";
			} else {
				message = "Daninha";
			}
			countDaninha = 0;
		}

		if (message == "começou") {
			Flowchart.BroadcastFungusMessage (message);
			canTalk = false;
			message = "";
		}


        if (canTalk)
        {
			
				if (message == "Farm2Players1") {
					Flowchart.BroadcastFungusMessage (message);
					canTalk = false;
					message = "";
				}

				if (message == "Farm2Players2") {
					Flowchart.BroadcastFungusMessage (message);
					canTalk = false;
					message = "";
				}

				if (message == "Farm2Players3") {
					Flowchart.BroadcastFungusMessage (message);
					canTalk = false;
					message = "";
				}

				if (message == "Daninha2Players") {
					Flowchart.BroadcastFungusMessage (message);
					canTalk = false;
					message = "";
				}

				if (message == "TriggerVida2Players") {
					Flowchart.BroadcastFungusMessage (message);
					canTalk = false;
					message = "";
				}

				if (message == "PegouNabo2Players") {
					Flowchart.BroadcastFungusMessage (message);
					canTalk = false;
					message = "";
				}

				if (message == "Farm1") {
					Flowchart.BroadcastFungusMessage (message);
					canTalk = false;
					message = "";
				}

				if (message == "Farm2") {
					Flowchart.BroadcastFungusMessage (message);
					canTalk = false;
					message = "";
				}

				if (message == "Farm3") {
					Flowchart.BroadcastFungusMessage (message);
					canTalk = false;
					message = "";
				}

				if (message == "TurnipRotate") {
					Flowchart.BroadcastFungusMessage (message);
					canTalk = false;
					message = "";
				}

				if (message == "ChangePlayer") {
					Flowchart.BroadcastFungusMessage (message);
					canTalk = false;
					message = "";
				}

				if (message == "Daninha") {
					Flowchart.BroadcastFungusMessage (message);
					canTalk = false;
					message = "";
				}

				if (message == "TriggerVida") {
					Flowchart.BroadcastFungusMessage (message);
					canTalk = false;
					message = "";
				}

				if (message == "PegouNabo") {
					Flowchart.BroadcastFungusMessage (message);
					canTalk = false;
					message = "";
				}

				if (message == "FIM") {
					Flowchart.BroadcastFungusMessage (message);
					canTalk = false;
					message = "";
				}

        }
	}

    void OnTriggerEnter(Collider hit)
    {
		if (InputManager.players == 2) {
			if (hit.tag == "TriggerCeleiro1") {
				canTalk = true;
				message = "Farm2Players2";
			}

			if (hit.tag == "TriggerCeleiro2") {
				canTalk = true;
				message = "Farm2Players3";
			}

			if (hit.tag == "TriggerVida") {
				canTalk = true;
				message = "TriggerVida2Players";
			}
			if (hit.tag == "PegouNabo") {
				canTalk = true;
				message = "PegouNabo2Players";
				triggerCeleiro2.SetActive (true);
			}
		} else {
			if (hit.tag == "TriggerCeleiro1") {
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
		CamponesaActivation ();
	}

	public void ChangeText(){
		if (InputManager.players == 2) {
			if (begin) {
				girar.SetActive (true);
			} else if (aim) {
				mirarTurnip.SetActive (true);
				camponesa.GetComponent<ThirdPersonUserControlCamponesa> ().AddTarget (turnip.transform);
				girar.SetActive (false);
			} else if (shoot) {
				mirarTurnip.SetActive (false);
				atirarNabos.SetActive (true);
			} else {
				atirarNabos.SetActive (false);
			}
		} else {
			if (begin) {
				girar.SetActive (true);
			} else if (change) {
				trocarPersonagem.SetActive (true);
				girar.SetActive (false);
			} else if (aim) {
				mirarTurnip.SetActive (true);
				camponesa.GetComponent<ThirdPersonUserControlCamponesa> ().AddTarget (turnip.transform);
				trocarPersonagem.SetActive (false);
			} else if (shoot) {
				mirarTurnip.SetActive (false);
				atirarNabos.SetActive (true);

			} else {
				atirarNabos.SetActive (false);
			}
		}
	}

	public void DesativarPlayers(){
		
		camponesa.GetComponent<ThirdPersonUserControlCamponesa> ().enabled = false;
		turnip.GetComponent<ThirdPersonUserControlTurnip> ().enabled = false;

		camponesa.GetComponent<ThirdPersonCharacter> ().m_Animator.SetFloat ("Forward", 0);
		camponesa.GetComponent<ThirdPersonCharacter> ().m_Animator.SetFloat ("Turn", 0);
		turnip.GetComponent<ThirdPersonCharacter> ().m_Animator.SetFloat ("Forward", 0);
		turnip.GetComponent<ThirdPersonCharacter> ().m_Animator.SetFloat ("Turn", 0);

		turnip.GetComponent<FSM_Turnip> ().enabled = false;
		camponesa.GetComponent<FSM_Camponesa> ().enabled = false;
		camponesa.GetComponent<SwitchPlayer> ().enabled = false;
		turnip.GetComponent<SwitchPlayer> ().enabled = false;
	}

	public void TurnipActivation(){
		camponesa.GetComponent<ThirdPersonCharacter> ().enabled = true;
		camponesa.GetComponent<ThirdPersonUserControlCamponesa> ().enabled = false;
		turnip.GetComponent<ThirdPersonCharacter> ().enabled = true;
		turnip.GetComponent<ThirdPersonUserControlTurnip> ().enabled = true;
		camponesa.transform.FindChild ("SelectedPlayer").GetComponent<MeshRenderer> ().enabled = false;
		turnip.transform.FindChild ("SelectedPlayer").GetComponent<MeshRenderer> ().enabled = true;
	}

	public void CamponesaActivation(){
		camponesa.GetComponent<ThirdPersonCharacter> ().enabled = true;
		camponesa.GetComponent<ThirdPersonUserControlCamponesa> ().enabled = true;
		turnip.GetComponent<ThirdPersonCharacter> ().enabled = true;
		turnip.GetComponent<ThirdPersonUserControlTurnip> ().enabled = false;
		camponesa.transform.FindChild ("SelectedPlayer").GetComponent<MeshRenderer> ().enabled = true;
		turnip.transform.FindChild ("SelectedPlayer").GetComponent<MeshRenderer> ().enabled = false;
	}

	public void TwoPlayersActivation(){
		camponesa.GetComponent<ThirdPersonUserControlCamponesa> ().enabled = true;
		turnip.GetComponent<ThirdPersonUserControlTurnip> ().enabled = true;
		camponesa.GetComponent<ThirdPersonCharacter> ().enabled = true;
		turnip.GetComponent<ThirdPersonCharacter> ().enabled = true;
	}

	public void ActivateFollowTurnip(){
		turnip.GetComponent<FSM_Turnip> ().enabled = true;
	}

	public void ActivateFollowCamponesa(){
		camponesa.GetComponent<FSM_Camponesa> ().enabled = true;
	}

	public void SwitchActivation(){
		camponesa.GetComponent<SwitchPlayer> ().enabled = true;
		turnip.GetComponent<SwitchPlayer> ().enabled = true;
	}

	public IEnumerator WaitAFrame(){
		yield return 1;
	}

	public void EndGame(){
		SceneManager.LoadScene (3);
	}
}
