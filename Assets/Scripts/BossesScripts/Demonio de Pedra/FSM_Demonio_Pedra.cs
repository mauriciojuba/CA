using UnityEngine;
using System.Collections;
using Fungus;

public class FSM_Demonio_Pedra : MonoBehaviour
{

    #region FSM States

    //Enum funciona como uma array, porem é Mais eficiente para FSM

    public enum FSMStates { Idle, Ataque_Comum, Ataque_CriarPedra, Dano, Ataque_Laser, Morrer }; // Estados
    public FSMStates state = FSMStates.Idle;
    #endregion

    

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
    public GameObject Pedras;
    public Transform Down,Up;
    Vector3 initialPosRock;
	Vector3 OponentPoint;
    public float danoAtaqueParedePedras;
    float amplitude = 0.1f;
    float duration = 0.1f;
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
        ataquedePedras.SetActive(false);
        Eye.SetActive(false);



    }
	void Update(){
        lifeTime();
        if (subindoPedras) {
			Pedras.transform.position = Vector3.MoveTowards (Pedras.transform.position, Up.transform.position, subirVel * Time.deltaTime);
			if (Pedras.transform.position.y >= Up.transform.position.y) {
				Pedras.tag = "AtaqueSubirPedra";
				Invoke ("DescerPedras", 3f);
				subindoPedras = false;
			}
		} else if (descendoPedras) {
			Pedras.transform.position = Vector3.MoveTowards(Pedras.transform.position, Down.transform.position, descerVel * Time.deltaTime);
			if (Pedras.transform.position.y <= Down.transform.position.y) {
				Invoke("EsconderPedras", 5f);
				descendoPedras = false;
			}
		}
	}


    public void FixedUpdate()
    {
        
        EscolherOponente();
        transform.LookAt(OponentPoint);
		OponentPoint = new Vector3 (Oponente.position.x, transform.position.y, Oponente.position.z);
        



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

        if (!isAttacking && distanceToStartBattle < 10)
        {
			Invoke("EscolherAtaque", 5f);
        }
    }
    #endregion

    #region EscolherOponente
    void EscolherOponente()
    {
        turnipDistance = Vector3.Distance(transform.position, Turnip.position);
        camponesaDistance = Vector3.Distance(transform.position, Camponesa.position);

        if (turnipDistance < camponesaDistance)
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
		if (state == FSMStates.Idle && !isAttacking)
        {
			if (distanceToStartBattle < 2) {
				float random = Random.Range (0.0f, 1.0f);
				if (random <= 0.6f) {
					state = FSMStates.Ataque_Comum;
				} else if (random > 0.6f) {
					state = FSMStates.Ataque_CriarPedra;
				}
			}
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
        isAttacking = true;
        Eye.SetActive(true);
        Invoke("ApagarLaser", 8f);
    }
    void ApagarLaser()
    {
        Eye.SetActive(false);
        isAttacking = false;
		state = FSMStates.Idle;
        
    }
    #endregion

    #region Estado 5
    private void Ataque_CriarPedra_State()
    {
        if (!isAttacking)
        {
            
            ataquedePedras.SetActive(true);
            Invoke("SubirPedras",2f);
			isAttacking = true;
            
        }
    }
    #endregion

    #region Estado 6
    private void Ataque_Comum_State()
	{
		if (distanceToStartBattle < 1.2f){
			Oponente.GetComponent<PlayersDamangeHandler> ().HitPLayer (danoAtaqueComum);
		}
        state = FSMStates.Idle;
        return;
    }
    #endregion

    #region Estado 7
    private void Morrer_State()
    {

    }
    #endregion
    void SubirPedras()
    {
		subindoPedras = true;
        CameraShake.Instance.Shake(amplitude, duration);
        //Invoke("DescerPedras", 5f);
    }
    void DescerPedras()
    {
		
		descendoPedras = true;
        Pedras.tag = "Untagged";
    }
    void EsconderPedras()
    {
        
        ataquedePedras.SetActive(false);
        isAttacking = false;
        
		state = FSMStates.Idle;
    }

    void lifeTime()
    {
        if (dano)
        {
            vida -= 25;
            dano = false;
        }
        if(vida <= 0)
        {
			Flowchart.BroadcastFungusMessage ("FimCave");
            Destroy(gameObject);
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
        }
    }
    #endregion



}