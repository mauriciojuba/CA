using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CustomizeText : MonoBehaviour {

	private Text myText;

	public Text[] letras;
	public int id;


	public void Start() {
		myText = GetComponent<Text> ();
		myText.text = null;
		id = 2;
	}

	public void Update(){

		if (id < 0)
			id = 4;
		if (id > 4)
			id = 0;

		if (Input.GetButtonDown ("XBOX_buttonA")
		    && myText.text == null
		    && letras [id].text != "Bksp"
		    && letras [id].text != "Clear"
			&& letras [id].text != "Enter") {
			myText.text = ("" + letras [id].text);
		} else if (myText.text.Length <= 12
			&& Input.GetButtonDown ("XBOX_buttonA")
		    && letras [id].text != "Bksp"
		    && letras [id].text != "Clear"
			&& letras [id].text != "Enter") {
			myText.text = (myText.text + letras [id].text);

		} else if (Input.GetButtonDown ("XBOX_buttonA")
		    && letras [id].text == "Bksp"
			&& myText.text != null) {
			string bkspString = myText.text;
			myText.text = bkspString.Substring (0, bkspString.Length - 1);

		} else if (Input.GetButtonDown ("XBOX_buttonA")
		         && letras [id].text == "Clear") {
			myText.text = null;
		}
		else if (Input.GetButtonDown ("XBOX_buttonA")
			&& letras [id].text == "Enter") {

			GameControl.control.CamponesaNome = myText.text;
			Application.LoadLevel (5);


		}

	}

	public void SetBlaBla(GameObject go) {
		if(myText.text == null){
			myText.text = ("" + go.GetComponent<Text> ().text);
		}
		else{
			if (go.GetComponent<Text> ().text == "Bksp") {
				string bkspString = myText.text;
				myText.text = bkspString.Substring (0, bkspString.Length - 1);
			} else {
				if (go.GetComponent<Text> ().text == "Clear") {
					myText.text = null;
				} else {

					if(myText.text.Length<=12){
						myText.text = (myText.text + go.GetComponent<Text> ().text);

					}
				}

		}
	}

	}
}

