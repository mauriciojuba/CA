﻿using UnityEngine;
using System.Collections;
using Fungus;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FSM_Demonio_Pedra : MonoBehaviour
{

    #region FSM States

    //Enum funciona como uma array, porem é Mais eficiente para FSM

    public enum FSMStates { Idle, Ataque_Comum, Ataque_CriarPedra, Dano, Ataque_Laser, Morrer }; // Estados
    public FSMStates state = FSMStates.Idle;
    #endregion
	public bool active;
	public Animator geodomAnimator;
	public float countVoz;

    #region AndarVariaveis
    #endregion
    #region EscolherAtaqueVariaveis
    public float distanceToStartBattle;
    public float distanceToAtaque;
    public Transform Turnip, Camponesa;
    private Transform Oponente;
    private float turnipDistance;
    private float camponesaDistance;
    #endregion
    #region DanoVariaveis
    public static float vida = 100;
    private bool dano;
    #endregion
    #region Ataque_CriarPedraVariaveis
    public GameObject ataquedePedras;
	public GameObject pedrasCol;
    public GameObject Pedras, particle, particulaDano;
    public Transform Down,Up;
    Vector3 initialPosRock;
	Vector3 OponentPoint;
    public float danoAtaqueParedePedras;
    float amplitude = 0.2f;
    float duration = 0.5f;
	float subirVel = 10f;
	float descerVel = 2f;
	float posPedras;
	bool subindoPedras,descendoPedras;
    #endregion
    #region AtaqueLaser
    public GameObject Eye;
    #endregion
    #region AtaqueComumVariaveis;
    public float danoAtaqueComum;
    #endregion

    bool isAttacking = false;


    #region Unity Functions


    void Start()
    {
        //Deixa os 2 GameObjects Que cuidam do ataque desligados.
        ataquedePedras.SetActive(false);
        Eye.SetActive(false);
		countVoz = 0;
		active = false;

    }
	void Update(){
        //checa a vida
        lifeTime();

        //se o ataque de pedras fr ativado ele vai subir as pedras usando o moveTowards
        if (subindoPedras) {
			Pedras.transform.position = Vector3.MoveTowards (Pedras.transform.position, Up.transform.position, subirVel * Time.deltaTime);
			if (Pedras.transform.position.y >= Up.transform.position.y) {
				pedrasCol.GetComponent<BoxCollider> ().enabled = false;
				Pedras.tag = "AtaqueSubirPedra";
				Invoke ("DescerPedras", 1.5f);
				subindoPedras = false;
			}
		}
        //Depois de atacar ele vai descer as pedras com o MoveTowards
        else if (descendoPedras) {
			Pedras.transform.position = Vector3.MoveTowards(Pedras.transform.position, Down.transform.position, descerVel * Time.deltaTime);
			if (Pedras.transform.position.y <= Down.transform.position.y) {
				Invoke("EsconderPedras", 1.5f);
				descendoPedras = false;
			}
		}
	}


    public void FixedUpdate()
    {
        //Seta o personagem mais próximo como target e olha para ele
        EscolherOponente();
        transform.LookAt(OponentPoint);
		OponentPoint = new Vector3 (Oponente.position.x, transform.position.y, Oponente.position.z);
        


        //estados, sem novidade...
        switch (state)
        {

			case FSMStates.Idle:
				Idle_State();
				break;
            case FSMStates.Dano:
                Dano_State();
                break;

            case FSMStates.Ataque_Laser:
                if (!isAttacking)
                Ataque_Laser_State();
                break;

            case FSMStates.Ataque_CriarPedra:
                if(!isAttacking)
                Ataque_CriarPedra_State();
                break;

            case FSMStates.Ataque_Comum:
                Ataque_Comum_State();
                break;

            case FSMStates.Morrer:
                Morrer_State();
                break;


        }

    }
    #endregion

    


    #region Andar
    private void Idle_State() {
		if (active) {
			if (vida <= 0) {
				state = FSMStates.Morrer;
				return;
			}
			countVoz += Time.deltaTime;
			if (countVoz > 5) {
				int num = Random.Range (8, 11);
				this.gameObject.GetComponentInChildren<AudioManagerDemonioPedra> ().PlaySound (num);
				countVoz = 0;
			}
			//se ele não estiver no meio de um ataque e o target entrou na area de alcance, o boss escolhe o ataque
			if (!isAttacking && distanceToStartBattle < 10) {
				Invoke ("EscolherAtaque", 4f);
			}
		}
    }
    #endregion

    #region EscolherOponente
    //função que escolhe o oponente mais próximo como target
    void EscolherOponente()
    {
		if (vida <= 0) {
			state = FSMStates.Morrer;
			return;
		}

		turnipDistance = Vector3.Distance(transform.position, Turnip.position);
        camponesaDistance = Vector3.Distance(transform.position, Camponesa.position);

		if (turnipDistance < camponesaDistance )
        {
            Oponente= Turnip;
        }
        else
        {
            Oponente= Camponesa;
        }

        distanceToStartBattle = Vector3.Distance(transform.position, Oponente.position);

    }
    #endregion

    #region EscolherAtaque
    private void EscolherAtaque()
    {
		if (vida <= 0) {
			state = FSMStates.Morrer;
			return;
		}

		if (state == FSMStates.Idle && !isAttacking)
        {
            //escolhe entre ataque comum e ataque criar pedras quando o target esta muito próximo
			if (distanceToStartBattle < 4) {
				float random = Random.Range (0.0f, 1.0f);
				if (random <= 0.4f) {
					state = FSMStates.Ataque_Comum;
				} else if (random > 0.4f) {
					state = FSMStates.Ataque_CriarPedra;
				}
			}
            //escolhe entre raio laser ou Idle caso o target esteja muito longe
			else if (distanceToStartBattle < 10)
			{
				float random = Random.Range(0.0f, 1.0f);
				if (random <= 0.3f)
				{
					state = FSMStates.Ataque_Laser;
				}
				else if (random > 0.3f && random < 0.6f)
				{
					state = FSMStates.Idle;
				}
				else if (random > 0.6f)
				{
					state = FSMStates.Idle;
				}
            }
        }

    }
    #endregion

    #region Estado 3
    private void Dano_State()
    {
    }
    #endregion

    #region Estado 4
    private void Ataque_Laser_State()
    {
		if (vida <= 0) {
			state = FSMStates.Morrer;
			return;
		}
        //EXTREMAMENTE NECESSÁRIO VER O SCRIPT --- AtaqueLaser

        //esta no meio de um ataque
        isAttacking = true;
        //liga o gameObject que lida com o ataque do olho
        Eye.SetActive(true);
		this.gameObject.GetComponentInChildren<AudioManagerDemonioPedra>().PlaySound(1);
        //vai chamar a função apagar o laser em 8 segundos
		Invoke("ApagarLaser", 8f);
        //toca o efeito(?)

    }
    void ApagarLaser()
    {
        //essa função desliga o gameObject do olho e diz que o boss não esta mais no meio de um ataque
        Eye.SetActive(false);
        isAttacking = false;
		state = FSMStates.Idle;
        
    }
    #endregion

    #region Estado 5
    private void Ataque_CriarPedra_State()
    {
		if (vida <= 0) {
			state = FSMStates.Morrer;
			return;
		}

        //se ele não estiver no meio de um ataque
        if (!isAttacking)
        {
            gameObject.GetComponentInChildren<AudioManagerDemonioPedra>().PlaySound(4);
			geodomAnimator.SetBool ("HeavyAttack", true);
            //ativa o gameObject que lida com as pedras
            ataquedePedras.SetActive(true);
			pedrasCol.GetComponent<BoxCollider> ().enabled = true;
            //chamara a fução subir pedras em 2 segundos... fiz isso pra que os jogadores tivessem uma indicação antes do ataque maior.
            Invoke("SubirPedras", 3f);
            //o boss está atacando agora
            isAttacking = true;

        }
       
    }
    #endregion

    #region Estado 6
    private void Ataque_Comum_State()
	{
		if (vida <= 0) {
			state = FSMStates.Morrer;
			return;
		}
        //ataque simples
		if (distanceToStartBattle < 2f){
			Oponente.GetComponent<PlayersDamangeHandler> ().HitPLayer (danoAtaqueComum);
			gameObject.GetComponentInChildren<AudioManagerDemonioPedra> ().PlaySound (6);
		}
        state = FSMStates.Idle;
        return;
    }
    #endregion

    #region Estado 7
    private void Morrer_State()
    {
		
		if(!gameObject.GetComponentInChildren<AudioManagerDemonioPedra> ().audio.isPlaying)
		gameObject.GetComponentInChildren<AudioManagerDemonioPedra> ().PlaySound (7);
		gameObject.GetComponent<Animator> ().SetBool ("Death", true);
        //checar porque não está funcionando
		Flowchart.BroadcastFungusMessage ("FimCave");

    }
    #endregion

    void SubirPedras()
    {
        gameObject.GetComponentInChildren<AudioManagerDemonioPedra>().audio.Stop();
        gameObject.GetComponentInChildren<AudioManagerDemonioPedra> ().PlaySound (5);
        //sobe as pedras nesse momento elas causam dano
		subindoPedras = true;
        //balança a camera
        CameraShake.Instance.Shake(amplitude, duration);
        Vector3 posicaoParticula = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        GameObject pedras = GameObject.Instantiate(particle, posicaoParticula, Quaternion.Euler(0, 0, 0)) as GameObject;
        Destroy(pedras, 4);
    }
    void DescerPedras()
    {
		//desc as pedras depois do ataque
		descendoPedras = true;
        //muda a Tag, para que não cause mais dano aos jogadores
        Pedras.tag = "Untagged";
		geodomAnimator.SetBool ("HeavyAttack", false);
    }
    void EsconderPedras()
    {
        //desativa o gameObject responsavel pelas pedras
        ataquedePedras.SetActive(false);
        isAttacking = false;
        
		state = FSMStates.Idle;
    }

    void lifeTime()
    {
        if (dano)
        {
			gameObject.GetComponentInChildren<AudioManagerDemonioPedra> ().PlaySound (3);
            vida -= 5;
            dano = false;
        }
        
       
    }

    #region  ColliderEnter
    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Nabo")
        {
			
            dano = true;
        }
    }
    #endregion

    #region TriggerEnter
    public void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "TurnipAtk")
        {
            dano = true;
            GameObject particleDmg = GameObject.Instantiate(particulaDano, hit.transform.position, hit.transform.rotation) as GameObject;
			Destroy(particleDmg, 1);
        }
    }
    #endregion

	public void FimJogo(){
//		SceneManager.LoadScene (7);
		LoadingScreenManager.LoadScene(7);
	}

	public void ActivateBoss(){
		active = true;
	}

}