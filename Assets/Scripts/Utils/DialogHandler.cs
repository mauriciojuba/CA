using UnityEngine;
using System.Collections;
using Fungus;

public class DialogHandler : MonoBehaviour {

    
    public bool canTalk;


	void Start () {

	
	}
	void Update () {
        if (canTalk)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Flowchart.BroadcastFungusMessage("Farm3");
                canTalk = false;
            }
        }
	}

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player1" || hit.tag == "Player2")
        {
            canTalk = true;
        }
    }
    void OnTriggerExit(Collider hit)
    {
        if (hit.tag == "Player1" || hit.tag == "Player2")
        {
            canTalk = false;
        }
    }
}
