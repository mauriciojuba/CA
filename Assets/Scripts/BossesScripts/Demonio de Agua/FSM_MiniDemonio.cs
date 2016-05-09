using UnityEngine;
using System.Collections;

public class FSM_MiniDemonio : MonoBehaviour {

	public float velocidade = 2;
	public float velocidadeDeRotacao;
	private Rigidbody rb;
	public float TimerParaVirar = 3;
	private float tempo;
	public GameObject target;
	private GameObject minionsom;

	private Vector3 direcao;

	public float timer;
	private GameObject mini;

	public float cooldownToAndar = 1;
	public float cooldownToVoice = 2;
	public float cooldownToVoiceMin = 2;
	public float cooldownToVoiceMax = 2;

	// Use this for initialization
	void Start () {

		minionsom = GameObject.FindWithTag ("Player1");
		target = GameObject.FindWithTag ("Demonio_de_agua");

		mini = this.gameObject;
		rb = GetComponent<Rigidbody>();
		tempo = TimerParaVirar;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		if (cooldownToVoice <= 0) {

			float voice;
			voice = Random.Range (0, 3);


			if(voice < 1)
				gameObject.GetComponentInChildren<AudioManager> ().PlaySound (18);

			else if(voice < 1 && voice <2)
				gameObject.GetComponentInChildren<AudioManager> ().PlaySound (19);

			else
				gameObject.GetComponentInChildren<AudioManager> ().PlaySound (20);



			cooldownToVoice = Random.Range (cooldownToVoiceMin, cooldownToVoiceMax);
		}

		if (cooldownToAndar <= 0){
			gameObject.GetComponentInChildren<AudioManager> ().PlaySound (21);
			cooldownToAndar = 1;
		}

		if (target.GetComponent<FSM_Demonio_Agua> ().Morto) {
			gameObject.GetComponentInChildren<AudioManager> ().PlaySound (22);
			Destroy (gameObject);
		}
		direcao = target.transform.position - transform.position;

		if(timer <= 0){
			transform.rotation    = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direcao), Time.deltaTime * velocidadeDeRotacao);
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
			rb.MovePosition(transform.position + transform.forward * velocidade * Time.deltaTime);
		}

		rb.MovePosition(transform.position + transform.forward * velocidade * Time.deltaTime);

		TimerParaVirar -= Time.deltaTime;
		timer -= Time.deltaTime;
		cooldownToAndar -= Time.deltaTime;
		cooldownToVoice -= Time.deltaTime;

		if (TimerParaVirar <= 0 && timer > 0) {

			float randum = Random.Range (-360, 360);

			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, randum, 0), Time.deltaTime * velocidadeDeRotacao);
		
			TimerParaVirar = tempo;

		}
	}

	public void OnCollisionEnter(Collision hit){
		if (hit.gameObject.tag == "Player1" || hit.gameObject.tag == "Player2") {
			gameObject.GetComponentInChildren<AudioManager> ().PlaySound (22);
			Destroy (gameObject,1f);
		}
	}
}
