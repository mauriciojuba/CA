using UnityEngine;
using System.Collections;

public class FSM_Demonio_Agua : MonoBehaviour {

	#region FSM States

	//Enum funciona como uma array, porem é Mais eficiente para FSM

	public enum  FSMStates { Andar, Ataque, Dano, Dividir, Juntar, Morrer}; // Estados
	public FSMStates state = FSMStates.Andar;
	#endregion

	#region Variaveis
	// Variaveis

	public GameObject target;
	public GameObject Minions;
	public GameObject Onda;
	public GameObject SpawAtaque;
	public Transform[] spawnMinions;
	public Quaternion rot = Quaternion.Euler(0f,5f,0f);
	public float TimerPraJuntar;
	public float vida = 100;
	public float force;
	private int minionsNaTela = 0;
	public bool junta;
	public float CooldownToATK = 10;
	public float CooldownToATKmin = 10;
	public float CooldownToATKmax = 10;

	public bool Ativar_Demonio = false;
	private bool atacar = false;
	public bool Morto = false;




	#endregion

	#region Unity Functions

	void Start () {

	}

	public void Update(){


	}


	public void FixedUpdate(){


		if (Ativar_Demonio) {

			//switch funciona como um "if" mas só para variaveis inteiras

			switch (state) {

			case FSMStates.Andar:
				Andar_State ();
				break;

			case FSMStates.Ataque:
				Ataque_State ();
				break;

			case FSMStates.Dano:
				Dano_State ();
				break;

			case FSMStates.Dividir:
				Dividir_State ();
				break;

			case FSMStates.Juntar:
				Juntar_State ();
				break;

			case FSMStates.Morrer:
				Morrer_State ();
				break;
			}
		}

	}
	#endregion

	//Codigo dos Estados

	#region Andar
	private void Andar_State(){



		//print ("Andar State");
		gameObject.transform.LookAt(target.transform.position);

		if (Input.GetKeyDown (KeyCode.M)) {
			state = FSMStates.Dano;
			return;
		}

		CooldownToATK -= Time.deltaTime;

		if (CooldownToATK <= 0) {

			atacar = true;

			state = FSMStates.Ataque;
			return;
		}

		//if (minionsNaTela >= 1 && TimerPraJuntar <= 0) {
		//	state = FSMStates.Juntar;
		//	return;
		//}
	}
	#endregion

	#region Ataque
	private void Ataque_State(){
		print ("Ataque State");


		CooldownToATK -= Time.deltaTime;

		if (atacar) {
			target.GetComponentInChildren<AudioManager> ().PlaySound (17);
			atacar = false;
		}

		if (CooldownToATK <= -1) {
			float r = 10;
			for (int i = 0; i < 36; i++) {


				Quaternion rodar = Quaternion.Euler (0, r, 0);
				GameObject ataque;
				ataque = GameObject.Instantiate (Onda, SpawAtaque.transform.position, SpawAtaque.transform.rotation) as GameObject;
				ataque.GetComponent<Rigidbody> ().AddForce (ataque.transform.forward * force);
				Destroy (ataque, 10);
				SpawAtaque.transform.localRotation = rodar;
				r += 10;
			}

			print (SpawAtaque.transform.localRotation);

			CooldownToATK = Random.Range (CooldownToATKmin, CooldownToATKmax);

			state = FSMStates.Andar;
			return;
		}

	}

	#endregion

	#region Dano
	private void Dano_State(){

		print ("Dano State");

		target.GetComponentInChildren<AudioManager> ().PlaySound (15);

		vida -= 5;

		print (vida);

		if (vida >= 0) {
			state = FSMStates.Dividir;
			return;
		}

		if (vida <= 0) {
			state = FSMStates.Morrer;
			return;
		} 

		else{
			state = FSMStates.Andar;
			return;
		}

	}
	#endregion

	#region Dividir
	private void Dividir_State(){
		print ("Dividir State");

		float radnum;

		for (int i = 0; i < 2; i++) {

			minionsNaTela += 1;

			radnum = Random.Range(0, 4);
			Mathf.FloorToInt (radnum);
			GameObject B;
			if (radnum == 0) {
				B = GameObject.Instantiate (Minions, spawnMinions [0].position, rot) as GameObject;
				B.GetComponent<Rigidbody> ().AddForce (spawnMinions[0].transform.forward * force);
			} else if (radnum == 1) {
				B = GameObject.Instantiate (Minions, spawnMinions [1].position, rot) as GameObject;
				B.GetComponent<Rigidbody> ().AddForce (spawnMinions[1].transform.forward * force);
			} else if (radnum == 2) {
				B = GameObject.Instantiate (Minions, spawnMinions [2].position, rot) as GameObject;
				B.GetComponent<Rigidbody> ().AddForce (spawnMinions[2].transform.forward * force);
			} else {
				B = GameObject.Instantiate (Minions, spawnMinions [3].position, rot) as GameObject;
				B.GetComponent<Rigidbody> ().AddForce (spawnMinions[3].transform.forward * force);
			}

			transform.localScale -= new Vector3 (0.025f, 0.025f, 0.025f);


		}



		state = FSMStates.Andar;
		return;

	}
	#endregion

	#region juntar
	private void Juntar_State(){
		print ("Juntar State");

		state = FSMStates.Andar;
		return;

	}
	#endregion

	#region Morrer
	private void Morrer_State(){

		Morto = true;
		target.GetComponentInChildren<AudioManager> ().PlaySound (16);
		gameObject.SetActive (false);
		print ("Morrer State");

	}
	#endregion

	public void OnCollisionEnter(Collision hit){
		if (hit.gameObject.tag == "Minion") {
		
			transform.localScale += new Vector3 (0.025f, 0.025f, 0.025f);

			vida += 2.5f;

			Destroy (hit.gameObject);

		}
	}
}
