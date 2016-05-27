using UnityEngine;
using System.Collections;
using Fungus;
using UnityEngine.SceneManagement;

public class DialogHandlerCutsceneFinal : MonoBehaviour {

	public string message;
	public Camera camera;
	public Transform posicaoPersonagem, posicao2, posicao3, posicao4, posicao5, posicao6, posicao7;
	public GameObject camponesa, principe, princesa;
	private float forward = 0.8f;
	private Rigidbody rb;
    public float count;

	void Start () {
		message = "CenaInicial";
		rb = camponesa.GetComponent<Rigidbody> ();
	}

	void Update () {
        count += Time.deltaTime;

        if (count > 3)
        {
            if (InputManager.StartButton() || Input.GetKeyDown(KeyCode.Escape))
                SceneManager.LoadScene(5);
        }


        Debug.Log (message);
		if (message == "CenaInicial") {
			Flowchart.BroadcastFungusMessage (message);
			message = "";
		}
	}

	public void Posicao2(){
		camera.transform.position = posicao2.position;
		camera.transform.rotation = posicao2.rotation;
	}

	public void Posicao3(){
		camera.transform.position = posicao3.position;
		camera.transform.rotation = posicao3.rotation;
	}

	public void Posicao4(){
		camera.transform.position = posicao4.position;
		camera.transform.rotation = posicao4.rotation;
	}

	public void Posicao6(){
		camera.transform.position = posicao6.position;
		camera.transform.rotation = posicao6.rotation;
	}

	public void Posicao7(){
		camera.transform.position = posicao7.position;
		camera.transform.rotation = posicao7.rotation;
	}

	public void End(){
		SceneManager.LoadScene (5);
	}
}
