using UnityEngine;
using System.Collections;

public class DestroyNabo : MonoBehaviour {
    public GameObject particle;

    
	void OnCollisionEnter(Collision hit){
		GameObject part = GameObject.Instantiate(particle, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
        Destroy(part, 3);
        Destroy (this.gameObject);
	}
}
