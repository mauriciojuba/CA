using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class FSM_Blobman : MonoBehaviour {

	#region FSM States

	//Enum funciona como uma array, porem é Mais eficiente para FSM

	public enum  FSMStates { Andar, Perseguir, Bater, Dano, Morrer}; // Estados
	public FSMStates state = FSMStates.Andar;
	#endregion

	#region Variaveis
	// Variaveis
	public GameObject target;
	public float speed;
	public float rotSpeed;
	private float timer;
	private Vector3 direcao;
	private Rigidbody rb;


	public GameObject Ataque;
	public float contToAtaque;
	private float setCont;


	public  Transform[] waypoints;
	public  float       distanceToChangeWaypoint;
	private int         currentWaypoint;


	public float distanceToStartChasing;
	public float distanceToStopChasing;
	public float distanceToAtaque;

	public float vida = 10;
	private bool dano = false;
	private float contar = 0.5f;

	private GameObject turnip, camponesa;
	private float turnipDis, camponesaDis;

	private bool morrer = true;
    bool targetMachucado;

	#endregion

	#region Unity Functions

	void Start () {

		target = GameObject.FindWithTag ("Player1");

		camponesa = GameObject.FindWithTag ("Player1");
		turnip = GameObject.FindWithTag ("Player2");
		
		currentWaypoint = 0;
		timer           = 0;
		rb              = GetComponent<Rigidbody>();

		setCont = contToAtaque;
		dano = false;

	}


	public void FixedUpdate(){


		direcao = target.transform.position - transform.position;

		//switch funciona como um "if" mas só para variaveis inteiras

		switch (state){

		case FSMStates.Andar:Andar_State ();break;

		case FSMStates.Perseguir:Perseguir_State ();break;

		case FSMStates.Bater:Bater_State ();break;

		case FSMStates.Dano:Dano_State ();break;

		case FSMStates.Morrer:Morrer_State ();break;
			
		}

        turnipDis = Vector3.Distance(transform.position, turnip.transform.position);
        camponesaDis = Vector3.Distance(transform.position, camponesa.transform.position);

        if (turnipDis < camponesaDis && !turnip.GetComponent<PlayersDamangeHandler>().hurted)
        {
            target = turnip;
        }
        else if(!camponesa.GetComponent<PlayersDamangeHandler>().hurted)
        {
            target = camponesa;
        }
        else
        {
            //chamar gameOver
        }

        if (target.GetComponent<PlayersDamangeHandler>().hurted) state = FSMStates.Andar;

    }
    #endregion

    //Codigo dos Estados

    #region Andar
    private void Andar_State(){


        if (!turnip.GetComponent<PlayersDamangeHandler>().hurted)
        {
            target = turnip;
        }
        else if (!camponesa.GetComponent<PlayersDamangeHandler>().hurted)
        {
            target = camponesa;
        }



            if (direcao.magnitude <= distanceToStartChasing) {
			state = FSMStates.Perseguir;
			return;
		}
		Vector3 wpDir         = waypoints[currentWaypoint].position - transform.position;
        Vector3 heightCorrectedPoint2 = new Vector3(wpDir.x, transform.position.y, wpDir.z);
        transform.LookAt(heightCorrectedPoint2);
        //transform.rotation    = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(wpDir), Time.deltaTime * rotSpeed);
		//transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		if (wpDir.magnitude <= distanceToChangeWaypoint) {
			currentWaypoint++;
			if (currentWaypoint >= waypoints.Length)
				currentWaypoint = 0;
		} else
			rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);

		if (dano) {
			state = FSMStates.Dano; return;
		}

		// if (........)
		//state = FSMStates.Estado_2;
	}
	#endregion

	#region Perseguir
	private void Perseguir_State(){

        //constrains
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        //end


        contToAtaque = setCont;

		contar -= Time.deltaTime;

		if (contar < 0) {
			gameObject.GetComponentInChildren<AudioManagerBlobman> ().PlaySound (4);
			contar = 0.5f;
		}
		if (direcao.magnitude > distanceToStopChasing && !target.GetComponent<PlayersDamangeHandler>().hurted) {
			state = FSMStates.Andar;
			return;
		}

		if (direcao.magnitude <= distanceToAtaque && !target.GetComponent<PlayersDamangeHandler>().hurted) {

			state = FSMStates.Bater; return;
		}
		//transform.rotation    = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direcao), Time.deltaTime * rotSpeed);
		//transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        Vector3 heightCorrectedPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(heightCorrectedPoint);
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);

		if (dano) {
			state = FSMStates.Dano; return;
		}

	}
	#endregion

	#region Bater
	private void Bater_State(){

		Ataque.SetActive (false);


		contToAtaque -= Time.deltaTime;

		if (direcao.magnitude <= distanceToAtaque && contToAtaque <= 0 ) {

			gameObject.GetComponentInChildren<AudioManagerBlobman> ().PlaySound (1);

            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			Ataque.SetActive (true);
			contToAtaque = setCont;

		} 
		else if(contToAtaque <= 0) {
			
			Ataque.SetActive (false);
			state = FSMStates.Perseguir;
			return;
		}

		if (dano) {
			state = FSMStates.Dano; return;
		}



	}
	#endregion

	#region Dano
	private void Dano_State(){
		if (dano){
			vida -= 5;
			gameObject.GetComponentInChildren<AudioManagerBlobman> ().PlaySound (2);
	}
		dano = false;

		if (vida <= 0) {
			state = FSMStates.Morrer;
			return;

		}
		else if (direcao.magnitude <= distanceToStartChasing) {
			state = FSMStates.Perseguir;
			return;
		} 
		else 
		{
			state = FSMStates.Andar;
			return;
		}
		if (!dano) {
			state = FSMStates.Andar;
		}


	}
	#endregion

	#region Morrer
	private void Morrer_State(){

		if (morrer) {
			
			gameObject.GetComponentInChildren<AudioManagerBlobman> ().PlaySound (3);
			Destroy (this.gameObject, 1f);
			print ("morreu");
			morrer = false;
		}

	}
	#endregion

	#region  ColliderEnter
	public void OnCollisionEnter(Collision hit){
		if (hit.gameObject.tag == "Nabo") {
			
			dano = true;
		}
	}
	#endregion

	#region TriggerEnter
	public void OnTriggerEnter(Collider hit){
		if (hit.tag == "TurnipAtk") {
			dano = true;
		}
	}
	#endregion
}