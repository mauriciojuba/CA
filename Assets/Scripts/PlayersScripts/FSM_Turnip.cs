using UnityEngine;
using UnityEngine.UI;

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
        currentWaypoint = 0;
        timer = 0;
        rb = GetComponent<Rigidbody>();
      
        follow = GameObject.FindWithTag("Player1").transform;


    }



    public void FixedUpdate()
    {
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

        // Check if target is in range to chase
        if (dir.magnitude <= distanceToStartChasing)
        {
            state = FSMStates.Chasing;
            return;
        }

        // Find the direction to the current waypoint,
        //   rotate and move towards it
        //transform.LookAt(follow.position);
        //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        //agent.SetDestination(follow.position);
        Vector3 followDir = follow.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(followDir), Time.deltaTime * rotSpeed);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if(followDir.magnitude < 2)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }
        


    }
    #endregion

    #region Chasing State
    private void ChaseState()
    {
        Debug.Log("Chase");
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
        Debug.Log("Hit");

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotSpeed);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        timer += Time.deltaTime;
        if (timer >= hitTime && dir.magnitude <= distanceToHit)
        {
            timer = 0;
            print("hit");
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

}