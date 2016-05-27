using UnityEngine;
using System.Collections;
using Fungus;
using UnityEngine.SceneManagement;

public class DialogHandlerCutscene : MonoBehaviour {

    
	public string message;
	public Camera camera;
	public Transform posicao2, posicao3, posicao4, posicao5, posicao6;
	public GameObject princesa, principe, suliman;
    public float count;

	void Start () {
		message = "Cena1";
	}

	void Update () {
        count += Time.deltaTime;

        if(count > 3)
        {
            if (Input.anyKeyDown)
                SceneManager.LoadScene(2);
        }

		Debug.Log (message);
     		if (message == "Cena1") {
				Flowchart.BroadcastFungusMessage (message);
				message = "";
			}

			if (message == "Cena2") {
				Flowchart.BroadcastFungusMessage (message);
				message = "";
			}

			if (message == "Cena3") {
				Flowchart.BroadcastFungusMessage (message);
				message = "";
			}

			if (message == "Cena4") {
				Flowchart.BroadcastFungusMessage (message);
				message = "";
			}

			if (message == "Cena5") {
				Flowchart.BroadcastFungusMessage (message);
				message = "";
			}
			
			if (message == "Cena6") {
				Flowchart.BroadcastFungusMessage (message);
				message = "";
			}

			if (message == "Cena7") {
				Flowchart.BroadcastFungusMessage (message);
				message = "";
			}

			if (message == "CenaFinal") {
				Flowchart.BroadcastFungusMessage (message);
				message = "";
			}
	
	}

	public void FimCena1(){
		camera.transform.position = posicao2.position;
		camera.transform.rotation = posicao2.rotation;
		message = "Cena2";
	}

	public void FimCena2(){
		camera.transform.position = posicao3.position;
		camera.transform.rotation = posicao3.rotation;
		message = "Cena3";
	}

	public void PrincesaFalaComTurnip(){
		princesa.GetComponent<Animator> ().SetBool ("FalaComPrincipe", true);
	}

	public void FimCena3(){
		princesa.GetComponent<Animator> ().SetBool ("FalaComPrincipe", false);
		message = "Cena4";
	}

	public void PrincipePara(){
		principe.GetComponent<Animator> ().SetBool ("Parar", true);
	}

	public void FimCena4(){
		camera.transform.position = posicao2.position;
		camera.transform.rotation = posicao2.rotation;
		princesa.GetComponent<Animator> ().SetBool ("Parada", true);
		message = "Cena5";
	}

	public void FocaMadame(){
		camera.transform.position = posicao4.position;
		camera.transform.rotation = posicao4.rotation;
		princesa.GetComponent<Animator> ().SetBool ("Parada", false);
	}

	public void FimCena5(){
		camera.transform.position = posicao5.position;
		camera.transform.rotation = posicao5.rotation;
		suliman.GetComponent<Animator> ().SetBool ("Levantar", true);
	}

	public void LancarMagia(){
		suliman.GetComponent<Animator> ().SetBool ("Magia", true);
		message = "Cena6";
	}

	public void PosicaoCamera(){
		camera.transform.position = posicao6.position;
		camera.transform.rotation = posicao6.rotation;
		princesa.GetComponent<Animator> ().SetBool ("Fugir", true);
		message = "Cena7";
	}

	public void TransformaJustin(){
		principe.GetComponent<Animator> ().SetBool ("AbrirBracos", true);
		message = "CenaFinal";
	}

	public void End(){
		SceneManager.LoadScene (1);
	}
}