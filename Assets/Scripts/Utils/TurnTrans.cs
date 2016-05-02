using UnityEngine;
using System.Collections;

public class TurnTrans : MonoBehaviour {

	public Transform player1, player2;
    public TransparencyManager TM;
	public LayerMask ignorePlayer;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.name == "Main Camera(Clone)")
        {
            Ray ray2 = new Ray(player2.position, Camera.main.transform.position);
            RaycastHit hit2;
            if (Physics.Linecast(player2.position, Camera.main.transform.position, out hit2, ignorePlayer) && this.gameObject.name == "Main Camera(Clone)")
            {
                Debug.Log(hit2.collider);
                if (!(hit2.collider.GetComponent<Renderer>() == null))
                {
                    if (hit2.collider.GetComponent<TransparentObject>() == null)
                    {
                        hit2.collider.gameObject.AddComponent<TransparentObject>();
                        //hit.collider.GetComponent<TransparentObject>().beTransparent = true;
                        TM.New2 = hit2.collider.gameObject;
                    }
                    else
                    {
                        //hit.collider.GetComponent<TransparentObject>().beTransparent = true;
                        TM.New2 = hit2.collider.gameObject;
                    }
                }
            }
        }
        else
        {
            Ray ray = new Ray(player1.position, Camera.main.transform.position);
            RaycastHit hit;
            if (Physics.Linecast(player1.position, Camera.main.transform.position, out hit, ignorePlayer))
            {
                Debug.Log(hit.collider);
                if (!(hit.collider.GetComponent<Renderer>() == null))
                {
                    if (hit.collider.GetComponent<TransparentObject>() == null)
                    {
                        hit.collider.gameObject.AddComponent<TransparentObject>();
                        //hit.collider.GetComponent<TransparentObject>().beTransparent = true;
                        TM.New = hit.collider.gameObject;
                    }
                    else
                    {
                        //hit.collider.GetComponent<TransparentObject>().beTransparent = true;
                        TM.New = hit.collider.gameObject;
                    }
                }
            }
        }
	
	}
}
