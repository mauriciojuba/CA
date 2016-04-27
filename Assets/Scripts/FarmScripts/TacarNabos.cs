using UnityEngine;
using System.Collections;

public class TacarNabos : MonoBehaviour {
	public Rigidbody nabo;
	public Transform muzzle;
	public float naboForce;
	public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.JoystickButton2))
		{
			Rigidbody b = GameObject.Instantiate(nabo, muzzle.position, muzzle.rotation) as Rigidbody;
			b.AddForce(muzzle.forward * naboForce);
			gameObject.GetComponentInChildren<AudioManager> ().PlaySound (7);
		}
	}
}
