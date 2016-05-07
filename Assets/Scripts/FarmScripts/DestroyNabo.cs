using UnityEngine;
using System.Collections;

public class DestroyNabo : MonoBehaviour {

	void OnCollisionEnter(Collision hit){
		Destroy (this.gameObject);
	}
}
