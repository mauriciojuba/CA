using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class EventTriggerCeleiro : MonoBehaviour {
	GameObject player1, player2;
	// Use this for initialization
	void Start () {
		player1 = GameObject.FindWithTag ("Player1");
		player2 = GameObject.FindWithTag ("Player2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
