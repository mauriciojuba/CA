using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MudaNome : MonoBehaviour {

	public GameObject fala;

	// Use this for initialization
	void Start () {

		fala = GameObject.FindWithTag ("Flow");
		gameObject.GetComponent<Text>().text = GameControl.control.CamponesaNome;
		fala.SetActive (false);
		fala.SetActive (true);
	}
	

}