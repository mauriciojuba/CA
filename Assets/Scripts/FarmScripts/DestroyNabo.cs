using UnityEngine;
using System.Collections;

public class DestroyNabo : MonoBehaviour {
    public GameObject particle;

    
	void OnCollisionEnter(Collision hit){
        Vector3 posicao = new Vector3(hit.transform.position.x, hit.transform.position.y + 1f, hit.transform.position.z);
        GameObject part = GameObject.Instantiate(particle, posicao, hit.gameObject.transform.rotation) as GameObject;
        Destroy(part, 3);
        Destroy (this.gameObject);
	}
}
