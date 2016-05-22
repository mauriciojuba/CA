using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControlTurnip : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
		public GameObject atkCollider;
        //metodo ataque
        bool m_Attack;
		public bool active;
        public float speedOnAir = 4;
        public LayerMask Sombra_ignorePlayer;
        public GameObject Sombra;
		public bool onAir;

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
        }


        private void Update()
        {

			if (Camera.main != null) {
				m_Cam = Camera.main.transform;
			}

			if (active) {
				if (!m_Jump) {
					if (InputManager.players == 2) {
						if (InputManager.AButton2 ())
							//Debug.Log ("Pula porra");
						m_Jump = InputManager.AButton2 ();
					} else {
						m_Jump = InputManager.AButton ();
                    }
				}
				Attack ();
				m_Character.Attacking (m_Attack);
				m_Attack = false;
			}
			if (onAir) castShadowOnJump();
            else Sombra.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.02f, this.transform.position.z);
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
			float h;
			float v;
			if (active) {
				if (InputManager.players == 2) {
					h = InputManager.LeftStickHorizontal2 ();
					v = InputManager.LeftStickVertical2 ();
				} else {
					h = InputManager.LeftStickHorizontal ();
					v = InputManager.LeftStickVertical ();
				}
			} else {
				h = 0;
				v = 0;
			}
			bool crouch = false;

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
	        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            
            if (!m_Character.m_IsGrounded) onAir = true;
			else onAir = false;
			m_Jump = false;
			if (onAir)
            {
                float step = speedOnAir * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, m_Move + transform.position,step);
                
            }
            


        }

        void Attack()
        {
			if (InputManager.players == 2) {
				if (InputManager.XButton2 () && !m_Attack)
 {					//if(CrossPlatformInputManager.GetButtonDown("XBOX_buttonX") && cooldown >= 2) {
					m_Attack = true;
				}
			} else {
				if (InputManager.XButton () && !m_Attack)
 {            //if(CrossPlatformInputManager.GetButtonDown("XBOX_buttonX") && cooldown >= 2) {
					m_Attack = true;
				}
			}
        }

		public void ThrowNabo(){
			atkCollider.GetComponent<BoxCollider> ().enabled = true;
		}

		public void EndAtk(){
			atkCollider.GetComponent<BoxCollider> ().enabled = false;
		}
        void castShadowOnJump()
        {
            Ray ray = new Ray(this.transform.position, Vector3.down);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 10f, Sombra_ignorePlayer))
            {
                Vector3 correctedPoint = new Vector3(hit.point.x, hit.point.y + 0.02f, hit.point.z);
                Sombra.transform.position = correctedPoint;
            }
        }
    }
}
