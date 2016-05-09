using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson;

public class FSM_Turnip : MonoBehaviour {



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

	private float forward = 0.8f;
	Animator m_Animator;
    #endregion

    #region Follow
    private int currentWaypoint;
    #endregion

    #region Chasing
    public float distanceToStartChasing;
    public float distanceToStopChasing;
    public float distanceToAttack;
    public float distanceToReturnChase;
    
    #endregion

    

    #region Hitting
    public float hitTime;
    public float distanceToHit;
    #endregion

    #region Die

    #endregion

    #region Unity Functions
    public void Start()
    {

		m_Animator = GetComponent<Animator>();
        currentWaypoint = 0;
        timer = 0;
        rb = GetComponent<Rigidbody>();
      
        follow = GameObject.FindWithTag("Player1").transform;
		m_Character = GetComponent<ThirdPersonCharacter>();
		myTransform = m_Character.transform;
		targets = new List<Transform>();
		AddAllEnemies ();

    }

	public void AddAllEnemies()
	{
		GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (GameObject enemy in go)
			AddTarget(enemy.transform);
	}

	public void AddTarget(Transform enemy)
	{
		targets.Add(enemy);
	}

	public void SortTargetByDistance()
	{
		targets.Sort(delegate (Transform t1, Transform t2) { return (Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position))); });

	}

    public void FixedUpdate()
    {
		for (int i = 0; i < (targets.Count - 1); i++) {
			if (targets [i] == null) {
				targets.RemoveAt (i);
			}
		}

		if (targets.Count != 0) {
			if (target == null) {
				SortTargetByDistance ();
				target = targets [0].gameObject;
			}
		}
		if(target != null)
        dir = target.transform.position - transform.position;

        switch (state)
        {
            case FSMStates.Following: FollowState(); break;
            case FSMStates.Chasing: ChaseState(); break;
            case FSMStates.Hitting: HitState(); break;
            case FSMStates.Damage: Damage(); break;
            case FSMStates.Die: DieState(); break;

            default: print("BUG: state should never be on default clause"); break;
        }
    }
    #endregion

    #region Follow State
    private void FollowState()
    {

        if (life <= 0)
        {
            state = FSMStates.Die;
            return;
        }
		if (target != null) {
			SortTargetByDistance ();
			if (Vector3.Distance (target.transform.position, myTransform.position) > Vector3.Distance (targets [0].position, myTransform.position))
				target = targets [0].gameObject;
		}
        // Check if target is in range to chase
        if (dir.magnitude <= distanceToStartChasing)
        {
            state = FSMStates.Chasing;
            return;
        }

		animacao ();
        


    }
    #endregion

    #region Chasing State
    private void ChaseState()
    {
       
        if (life <= 0)
        {
            state = FSMStates.Die;
            return;
        }
        // Check if target is close enough to shoot or hit
        //   or if target is too far way, then return to Follow
        if (dir.magnitude > distanceToStopChasing || target == null)
        {
            state = FSMStates.Following;
            return;
        }
        else if (dir.magnitude <= distanceToHit)
        {
            timer = 0;
            rb.velocity = Vector3.zero;
            state = FSMStates.Hitting;
            return;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotSpeed);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }
    #endregion

  

    #region Hitting State
    private void HitState()
    {
		m_Character.Attacking(m_Attack);
		m_Attack = false;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotSpeed);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        timer += Time.deltaTime;
        if (timer >= hitTime && dir.magnitude <= distanceToHit)
        {
            timer = 0;
            print("hit");
			m_Attack = true;
        }
        else if (dir.magnitude > distanceToHit && dir.magnitude <= distanceToReturnChase)
        {
            state = FSMStates.Chasing;
        }
        else if (dir.magnitude > distanceToReturnChase || target == null)
        {
            state = FSMStates.Following;
        }

        if (life <= 0)
        {
            state = FSMStates.Die;
            return;
        }
    }
    #endregion

    #region Die State
    private void DieState()
    {

        Debug.Log("Die");
        Destroy(gameObject, 3);
    }
    #endregion

    #region Damage
    private void Damage()
    {

        Debug.Log("Damage");

        if (dir.magnitude > distanceToHit && dir.magnitude <= distanceToReturnChase)
        {
            state = FSMStates.Chasing;
        }
        else if (dir.magnitude > distanceToReturnChase)
        {
            state = FSMStates.Following;
        }

        if (life <= 0)
        {
            state = FSMStates.Die;
            return;
        }

        //take damage
        print("Tomou Dano!");
        life -= 1;
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
		if(followDir.magnitude < 2 || followDir.y > 1)
		{
			forward = Mathf.Lerp (forward, 0f, Time.deltaTime * speed * 5);
			rb.velocity = Vector3.zero;
		}
		else if (followDir.magnitude < 3)
			forward = Mathf.Lerp (forward, 0.4f, Time.deltaTime * speed);
		else if (followDir.magnitude < 4)
			forward = Mathf.Lerp (forward, 0.6f, Time.deltaTime * speed);
		else // (followDir.magnitude > 5)
			forward = Mathf.Lerp (forward, 1f, Time.deltaTime * speed);

		m_Animator.SetFloat ("Forward",forward);

		//  else
		//   {
		//      rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
		// }


	}
}