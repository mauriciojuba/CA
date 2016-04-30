using UnityEngine;
using System.Collections;

public class FSM_MiniDemonio : MonoBehaviour {

	public float velocidade = 2;
	public float velocidadeDeRotacao;
	private Rigidbody rb;
	public float TimerParaVirar = 3;
	private float tempo;
	public GameObject target;

	private Vector3 direcao;

	public float timer;
	private GameObject mini;

	// Use this for initialization
	void Start () {

		target = GameObject.FindWithTag ("Demonio_de_agua");

		mini = this.gameObject;
		rb = GetComponent<Rigidbody>();
		tempo = TimerParaVirar;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (target.GetComponent<FSM_Demonio_Agua>().Morto)
			Destroy (gameObject);

		direcao = target.transform.position - transform.position;

		//if (mini.GetComponent<FSM_Demonio_Agua>().junta) {
		if(timer <= 0){
			transform.rotation    = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direcao), Time.deltaTime * velocidadeDeRotacao);
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
			rb.MovePosition(transform.position + transform.forward * velocidade * Time.deltaTime);
		}
		rb.MovePosition(transform.position + transform.forward * velocidade * Time.deltaTime);
		//mini.GetComponent<Rigidbody> ().AddForce (transform.forward * velocidade);

		TimerParaVirar -= Time.deltaTime;
		timer -= Time.deltaTime;


		if (TimerParaVirar <= 0 && timer > 0) {

			float randum = Random.Range (-360, 360);

			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, randum, 0), Time.deltaTime * velocidadeDeRotacao);
		
			TimerParaVirar = tempo;

		}
	}
}
