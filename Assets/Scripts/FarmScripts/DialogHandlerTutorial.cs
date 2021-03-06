﻿using UnityEngine;
using System.Collections;
using Fungus;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

public class DialogHandlerTutorial : MonoBehaviour {

    public string message;
    public bool canTalk;
    public GameObject girar, trocarPersonagem, atirarNabos, mirarTurnip, chegaPertoTurnip, descerTurnip;
    public GameObject montarTurnip, pegaNaboVida, agachar, hudPlayers;
    public static bool cutscene;
    public bool beginGame, change, aim, shoot, agarraTurnip, final;
    public int count;
    public static int countDaninha;
    public GameObject camponesa, turnip, triggerCeleiro2;
    public float delayAtk, delayToTalk;
    public bool toTalk;
    public bool canUp;

    void Start() {
        canUp = false;
        hudPlayers.SetActive(false);
        message = "começou";
        canTalk = false;
        girar.SetActive(false);
        mirarTurnip.SetActive(false);
        trocarPersonagem.SetActive(false);
        atirarNabos.SetActive(false);
		descerTurnip.SetActive (false);
        count = 0;
        cutscene = true;
        toTalk = false;
        delayToTalk = 0;
        countDaninha = 0;
        delayAtk = 0;
        beginGame = false;
        change = false;
        shoot = false;
        camponesa.GetComponent<SwitchPlayer>().enabled = false;
        //		turnip.GetComponent<SwitchPlayer> ().enabled = false;
        turnip.GetComponent<ThirdPersonUserControlTurnip>().enabled = false;

        montarTurnip.SetActive(false);
        chegaPertoTurnip.SetActive(false);
        pegaNaboVida.SetActive(false);
        agachar.SetActive(false);
    }

    void Update() {
        delayAtk += Time.deltaTime;
        if (cutscene) {
            DesativarPlayers();
        }

        if (beginGame) {
            girar.SetActive(true);
            if (InputManager.players == 2) {
                if (InputManager.XButton2() || Input.GetKeyDown(KeyCode.X)) {
                    TurnipRotate();
                    beginGame = false;
                    aim = true;
                    ChangeText();
                }
            } else {
                if (InputManager.XButton() || Input.GetKeyDown(KeyCode.X)) {
                    TurnipRotate();
                    beginGame = false;
                    change = true;
                    ChangeText();
                }
            }
        }
        if (change) {
            if (InputManager.LButton() || Input.GetKeyDown(KeyCode.Tab)) {
                ChangePlayer();
                change = false;
                aim = true;
                ChangeText();

            }
        }

        if (aim) {
            if (Vector3.Distance(camponesa.transform.position, turnip.transform.position) <= 6.0f) {
                aim = false;
                shoot = true;
                ChangeText();
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
                ChangeText();

				camponesa.GetComponent<ThirdPersonUserControlCamponesa>().selectedTarget.Find("SelectedPoint").GetComponentInChildren<ParticleSystem>().enableEmission = false;
                camponesa.GetComponent<ThirdPersonUserControlCamponesa>().selectedTarget = null;
                camponesa.GetComponent<ThirdPersonUserControlCamponesa>().targets.Clear();
                camponesa.GetComponent<ThirdPersonUserControlCamponesa>().AddAllEnemies();

                canTalk = true;
                if (InputManager.players == 2)
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

        if (canTalk)
        {

            if (message == "Farm2Players1") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

            if (message == "Farm2Players2") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

            if (message == "Farm2Players3") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

            if (message == "TurnipRotate2Players") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

            if (message == "Daninha2Players") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

            if (message == "TriggerVida2Players") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

            if (message == "PegouNabo2Players") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

            if (message == "Farm1") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

            if (message == "Farm2") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

            if (message == "Farm3") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

            if (message == "TurnipRotate") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

            if (message == "ChangePlayer") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

            if (message == "Daninha") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

            if (message == "TriggerVida") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

            if (message == "PegouNabo") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

            if (message == "FIM") {
                Flowchart.BroadcastFungusMessage(message);
                canTalk = false;
                message = "";
            }

        }


        if (Vector3.Distance(camponesa.transform.position, turnip.transform.position) <= 2f && canUp) {
            chegaPertoTurnip.SetActive(false);
            montarTurnip.SetActive(true);

        } else {
            montarTurnip.SetActive(false);
        }
        if (Vector3.Distance(camponesa.transform.position, turnip.transform.position) <= 2f && InputManager.YButton()) {
            montarTurnip.SetActive(false);
            canUp = false;
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
            if (this.gameObject.tag == "Player2") {
                if (hit.tag == "PegouNabo") {
                    canTalk = true;
                    message = "PegouNabo2Players";
                    triggerCeleiro2.SetActive(true);
                }
            }
            if (hit.tag == "PassarBuraco") {
                agachar.SetActive(true);
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
            if (this.gameObject.tag == "Player2") {
                if (hit.tag == "PegouNabo") {
                    canTalk = true;
                    message = "PegouNabo";
                    triggerCeleiro2.SetActive(true);
                }
            }
            if (hit.tag == "PassarBuraco") {
                agachar.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider hit)
    {
        canTalk = false;
        if (hit.tag == "PassarBuraco") {
            agachar.SetActive(false);
        }
    }

    public void TurnipRotate() {
        canTalk = true;
        if (InputManager.players == 2)
            message = "TurnipRotate2Players";
        else
            message = "TurnipRotate";
    }

    public void ChangePlayer() {
        canTalk = true;
        message = "ChangePlayer";
        trocarPersonagem.SetActive(false);
        CamponesaActivation();
    }

    public void ChangeText() {
        if (InputManager.players == 2) {
            if (beginGame) {
                girar.SetActive(true);
            } else if (aim) {
                mirarTurnip.SetActive(true);
                camponesa.GetComponent<ThirdPersonUserControlCamponesa>().AddTarget(turnip.transform);
                girar.SetActive(false);
            } else if (shoot) {
                mirarTurnip.SetActive(false);
                atirarNabos.SetActive(true);
            } else {
                atirarNabos.SetActive(false);
            }


        } else {
            if (beginGame) {
                girar.SetActive(true);
            } else if (change) {
                trocarPersonagem.SetActive(true);
                girar.SetActive(false);
            } else if (aim) {
                mirarTurnip.SetActive(true);
                camponesa.GetComponent<ThirdPersonUserControlCamponesa>().AddTarget(turnip.transform);
                trocarPersonagem.SetActive(false);
            } else if (shoot) {
                mirarTurnip.SetActive(false);
                atirarNabos.SetActive(true);

            } else {
                atirarNabos.SetActive(false);
            }
        }
    }

    public void DesativarPlayers() {

        camponesa.GetComponent<ThirdPersonUserControlCamponesa>().enabled = false;
        turnip.GetComponent<ThirdPersonUserControlTurnip>().enabled = false;

        camponesa.GetComponent<ThirdPersonCharacter>().m_Animator.SetFloat("Forward", 0);
        camponesa.GetComponent<ThirdPersonCharacter>().m_Animator.SetFloat("Turn", 0);
        turnip.GetComponent<ThirdPersonCharacter>().m_Animator.SetFloat("Forward", 0);
        turnip.GetComponent<ThirdPersonCharacter>().m_Animator.SetFloat("Turn", 0);

        turnip.GetComponent<FSM_Turnip>().enabled = false;
        camponesa.GetComponent<FSM_Camponesa>().enabled = false;
        camponesa.GetComponent<SwitchPlayer>().enabled = false;
        //		turnip.GetComponent<SwitchPlayer> ().enabled = false;
    }

    public void TurnipActivation() {
        camponesa.GetComponent<ThirdPersonCharacter>().enabled = true;
        camponesa.GetComponent<ThirdPersonUserControlCamponesa>().enabled = false;
        turnip.GetComponent<ThirdPersonCharacter>().enabled = true;
        turnip.GetComponent<ThirdPersonUserControlTurnip>().enabled = true;
		camponesa.transform.Find("SelectedPlayer").GetComponentInChildren<ParticleSystem> ().Stop();
		turnip.transform.Find("SelectedPlayer").GetComponentInChildren<ParticleSystem> ().Play();
    }

    public void CamponesaActivation() {
        camponesa.GetComponent<ThirdPersonCharacter>().enabled = true;
        camponesa.GetComponent<ThirdPersonUserControlCamponesa>().enabled = true;
        turnip.GetComponent<ThirdPersonCharacter>().enabled = true;
        turnip.GetComponent<ThirdPersonUserControlTurnip>().enabled = false;
		camponesa.transform.Find("SelectedPlayer").GetComponentInChildren<ParticleSystem> ().Play();
		turnip.transform.Find("SelectedPlayer").GetComponentInChildren<ParticleSystem> ().Stop();
    }

    public void TwoPlayersActivation() {
        camponesa.GetComponent<ThirdPersonUserControlCamponesa>().enabled = true;
        turnip.GetComponent<ThirdPersonUserControlTurnip>().enabled = true;
        camponesa.GetComponent<ThirdPersonCharacter>().enabled = true;
        turnip.GetComponent<ThirdPersonCharacter>().enabled = true;
		camponesa.transform.Find("SelectedPlayer").GetComponentInChildren<ParticleSystem> ().Play();
		turnip.transform.Find("SelectedPlayer").GetComponentInChildren<ParticleSystem> ().Play();
    }

    public void ActivateFollowTurnip() {
        turnip.GetComponent<FSM_Turnip>().enabled = true;
    }

    public void ActivateFollowCamponesa() {
        camponesa.GetComponent<FSM_Camponesa>().enabled = true;
    }

    public void SwitchActivation() {
        camponesa.GetComponent<SwitchPlayer>().enabled = true;
        //		turnip.GetComponent<SwitchPlayer> ().enabled = true;
    }

    public IEnumerator WaitAFrame() {
        yield return 1;
    }

    public void EndGame() {
//        SceneManager.LoadScene(3);
		LoadingScreenManager.LoadScene(3);
    }

    public void PegaNaboVida() {
        pegaNaboVida.SetActive(true);
    }

    public void AtivaHUD()
    {
        hudPlayers.SetActive(true);
    }
		
}
