using UnityEngine;
using System.Collections;

public class AtaqueBlobman : MonoBehaviour {

	
	void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.GetComponent<PlayersDamangeHandler>() != null)
        {
            hit.gameObject.GetComponent<PlayersDamangeHandler>().HitPLayer(5f);
        }
    }
}
