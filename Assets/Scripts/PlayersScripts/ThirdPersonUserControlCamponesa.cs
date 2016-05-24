using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControlCamponesa : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
		public bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
		public List<Transform> targets;
		public Transform selectedTarget;
		private float dampTime = 0;
        //metodo ataque
        bool m_Attack;
		private Transform myTransform;
		public Rigidbody nabo;
		public float naboForce;
		public Transform muzzle;
		public bool active;
        public float speedOnAir = 4;
        public LayerMask Sombra_ignorePlayer;
        public GameObject Sombra;
		public bool onAir;
		public bool crouch = false;

        private void Start()
        {
			active = true;
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
			myTransform = m_Character.transform;
			targets = new List<Transform>();
			selectedTarget = null;
			AddAllEnemies ();
        }


        private void Update()
		{ 
			
			if (Camera.main != null) {
				m_Cam = Camera.main.transform;
			}

			if (active) {
				if (!m_Jump) {
					m_Jump = InputManager.AButton ();
				}
				Attack ();
				m_Character.Attacking (m_Attack);
				m_Attack = false;
				dampTime += Time.deltaTime;

				for (int i = 0; i <= (targets.Count - 1); i++) {
					if (targets [i] == null) {
						targets.RemoveAt (i);
					}
				}

				if (targets.Count > 0) {
					SortTargetByDistance ();
					if (Vector3.Distance (targets [0].position, myTransform.position) <= 6.0f) {
						TargetEnemy ();
					} else if(selectedTarget != null) {
						selectedTarget.FindChild ("SelectedPoint").GetComponent<MeshRenderer> ().enabled = false;
						selectedTarget = null;
					}
				}
			}
			if (onAir) castShadowOnJump();
            else Sombra.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.02f, this.transform.position.z);


        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {


			float h;
			float v;

            // read inputs
//			if (active) {
				h = InputManager.LeftStickHorizontal ();
				v = InputManager.LeftStickVertical ();
			if (InputManager.BButton ()) {
				if(crouch)
					crouch = false;
				else
					crouch = true;
			}
//			} else {
//				h = 0;
//				v = 0;
//				crouch = false;
//			}
			Debug.Log (active);
            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v*m_CamForward + h*m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v*Vector3.forward + h*Vector3.right;
            }
#if !MOBILE_INPUT
			// walk speed multiplier
//	        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
			if (!m_Character.m_IsGrounded) onAir = true;
			else onAir = false;
			m_Jump = false;
			if (onAir)
            {
                float step = speedOnAir * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, m_Move + transform.position, step);
            }

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

		private void TargetEnemy()
		{
			
			if (targets.Count > 0) {
				if (selectedTarget == null) { 
					SortTargetByDistance ();
					selectedTarget = targets [0];
					SelectTarget ();
				} 
			}


			int index = targets.IndexOf(selectedTarget);
			//Debug.Log ("index " + index);


		}

		public void SortTargetByDistance()
		{
			targets.Sort(delegate (Transform t1, Transform t2) { return (Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position))); });

		}

		private void SelectTarget()
		{
			if(selectedTarget != null)
			selectedTarget.FindChild("SelectedPoint").GetComponent<MeshRenderer>().enabled = true;
		}

        void Attack()
        {
			if (InputManager.XButton() && !m_Attack)
            {
				if (selectedTarget != null) {
					m_Attack = true;
					transform.LookAt (selectedTarget.position);
					transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
				} else {
					m_Attack = true;

				}
            }
        }

		public void ThrowNabo(){
			Rigidbody b = GameObject.Instantiate(nabo, muzzle.position, muzzle.rotation) as Rigidbody;
			if (selectedTarget != null) {
				muzzle.LookAt (selectedTarget.FindChild ("Alvo").position);
			} else {
//				muzzle.transform.eulerAngles = new Vector3 (-25, muzzle.transform.rotation.y, muzzle.transform.rotation.z);
			}
			b.AddForce(muzzle.forward * naboForce);
		}

		public void EndAtk(){
			
		}
        void castShadowOnJump()
        {
            Ray ray = new Ray(this.transform.position, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10f, Sombra_ignorePlayer))
            {
                Vector3 correctedPoint = new Vector3(hit.point.x, hit.point.y + 0.02f, hit.point.z);
                Sombra.transform.position = correctedPoint;
            }
        }
    }
}
