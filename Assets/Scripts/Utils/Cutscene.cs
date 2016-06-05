using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Cutscene : MonoBehaviour {

	public Camera camera;
	public Transform posicao, posicao1, posicao2, posicao3;
	public GameObject cameraPlayers, camponesa, turnip, menuCircular;
	public float count;
	public bool skip;
    public GameObject particles;

    void Awake()
    {
		cameraPlayers.GetComponent<Camera> ().enabled = false;
    }
	// Use this for initialization
	void Start () {
        turnip.GetComponent<Animator>().enabled = false;
        count = 0;
		camera.transform.position = posicao.position;
		camera.transform.rotation = posicao.rotation;
        particles.SetActive(false);
        menuCircular.SetActive(false);
		camponesa.GetComponent<ThirdPersonCharacter> ().m_Animator.SetBool ("CutsceneTutorial", true);
		skip = false;
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;
		if (count > 7 && count <= 14) {
			camera.transform.position = posicao1.position;
			camera.transform.rotation = posicao1.rotation;

		} else if (count > 14 && count <= 15) {
			camera.transform.position = posicao2.position;
			camera.transform.rotation = posicao2.rotation;
            particles.SetActive(true);
		} else if (count > 15 && count <= 18) {
			float tempo = 7 * Time.deltaTime;
			camera.transform.position = Vector3.Slerp (camera.transform.position, posicao3.position, tempo);
            Destroy(particles, 5);
		} else if (count > 18 && count <= 22) {
			camera.fieldOfView = 20;
		} else if(count > 23){
			DialogHandlerTutorial.cutscene = false;
            //camponesa.GetComponent<DialogHandlerTutorial> ().beginGame = true;
            turnip.GetComponent<Animator>().enabled = true;
            camponesa.GetComponent<ThirdPersonCharacter> ().m_Animator.SetBool ("CutsceneTutorial", false);
			camera.gameObject.SetActive (false);
            //cameraPlayers.GetComponentInChildren<Camera>().enabled = true;
            menuCircular.SetActive(true);
			Destroy (this.gameObject);
		}

		if (skip && count > 5) {
			DialogHandlerTutorial.cutscene = false;
			//camponesa.GetComponent<DialogHandlerTutorial> ().beginGame = true;
			//turnip.GetComponent<DialogHandlerTutorial> ().beginGame = true;
			camponesa.GetComponent<ThirdPersonCharacter> ().m_Animator.SetBool ("CutsceneTutorial", false);
			camera.gameObject.SetActive (false);
            turnip.GetComponent<Animator>().enabled = true;
            //cameraPlayers.GetComponentInChildren<Camera>().enabled = true;

            Destroy (this.gameObject);
		}
		if(count > 5){
		if (Input.anyKeyDown)
			skip = true;
		}
	}

    void OnDestroy()
    {
        menuCircular.SetActive(true);
    }
}
