using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson;

public class ControleCamponesaCutscene : MonoBehaviour {

	#region FSM States
	public enum FSMStates { Following, Chasing, Shooting, Hitting, Damage, Die };
	public FSMStates state = FSMStates.Following;
	#endregion

	#region Generic Variable
	public GameObject target;
	public Transform follow;
	public float speed;
	public float rotSpeed;
	private float timer;
	private Vector3 dir;
	private Rigidbody rb;
	private int life = 10;
	private Transform myTransform;
	private bool m_Attack;
	private ThirdPersonCharacter m_Character;
	public List<Transform> targets;
	public Transform ray1, ray2;
	private float forward;
	Animator m_Animator;
	#endregion

	#region Follow
	private int currentWaypoint;
	#endregion


	#region Unity Functions
	public void Start() {
		m_Animator = GetComponent<Animator>();
		currentWaypoint = 0;
		timer = 0;
		rb = GetComponent<Rigidbody>();


		m_Character = GetComponent<ThirdPersonCharacter>();
		myTransform = m_Character.transform;


	}

	void Update(){
		FollowState ();
	}

	#endregion

	#region Follow State
	private void FollowState() {
		RaycastHit hit;
		animacao ();

	}
	#endregion



	private void animacao(){

		// Find the direction to the current waypoint,
		//   rotate and move towards it
		//transform.LookAt(follow.position);
		//transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		//agent.SetDestination(follow.position);
		Vector3 followDir = follow.position - transform.position;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(followDir), Time.deltaTime * rotSpeed);
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

		if (followDir.magnitude < 1f) {
			forward = 0.0f;
			rb.velocity = Vector3.zero;
		} else 
			forward = 0.5f;
		

		m_Animator.SetFloat ("Forward", forward);

	}
}
