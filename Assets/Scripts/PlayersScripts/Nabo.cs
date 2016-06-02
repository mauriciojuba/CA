using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Nabo : MonoBehaviour {

	public GameObject particula;

	void OnTriggerEnter(Collider hit){
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (hit.CompareTag("Player2"))
            {
                hit.GetComponent<PlayersDamangeHandler>().RecoveryPlayer(40f);
                hit.gameObject.GetComponentInChildren<AudioManager>().PlaySound(1);
				hit.gameObject.GetComponent<DialogHandlerTutorial> ().pegaNaboVida.SetActive (false);
				GameObject part = GameObject.Instantiate (particula, hit.transform.position, hit.transform.rotation) as GameObject;
				Destroy (part, 3);
                Destroy(gameObject);
            }
        }
		else if(hit.CompareTag("Player1") || hit.CompareTag("Player2")){
			hit.GetComponent<PlayersDamangeHandler>().RecoveryPlayer(40f);
			hit.gameObject.GetComponentInChildren<AudioManager> ().PlaySound (1);
			Destroy (gameObject);
		}
	}
}
