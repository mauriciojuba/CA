using UnityEngine;
using System.Collections;

public class DestroyNabo : MonoBehaviour {
    public GameObject particle;

    
	void OnCollisionEnter(Collision hit){
		if (hit.collider.gameObject.CompareTag ("Player2"))
			hit.collider.gameObject.GetComponentInChildren<AudioManager> ().PlaySound (25);

		GameObject part = GameObject.Instantiate(particle, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
        Destroy(part, 3);
        Destroy (this.gameObject);
	}
}
