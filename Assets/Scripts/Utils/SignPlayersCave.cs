using UnityEngine;
using System.Collections;

public class SignPlayersCave : MonoBehaviour {

    public GameObject camponesa, turnip;
	
	void Start () {
        camponesa.transform.Find("SelectedPlayer").GetComponentInChildren<ParticleSystem>().Play();
        turnip.transform.Find("SelectedPlayer").GetComponentInChildren<ParticleSystem>().Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
