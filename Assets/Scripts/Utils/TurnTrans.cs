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
        
		Ray ray= new Ray(player1.position,Camera.main.transform.position);
		Ray ray2 = new Ray(player2.position,Camera.main.transform.position);
		RaycastHit hit;
        RaycastHit hit2;
		if (Physics.Linecast(player1.position,Camera.main.transform.position,out hit,ignorePlayer)) {
            Debug.Log(hit.collider);
            if (!(hit.collider.GetComponent<Renderer> () == null)) {
                if(hit.collider.GetComponent<TransparentObject>() == null)
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
		if (Physics.Linecast (player2.position,Camera.main.transform.position,out hit2,ignorePlayer)) {
            Debug.Log(hit2.collider);
            if (!(hit2.collider.GetComponent<Renderer> () == null)) {
                if (hit2.collider.GetComponent<TransparentObject>() == null)
                {
                    hit2.collider.gameObject.AddComponent<TransparentObject>();
                    //hit.collider.GetComponent<TransparentObject>().beTransparent = true;
                    TM.New = hit2.collider.gameObject;
                }
                else
                {
                    //hit.collider.GetComponent<TransparentObject>().beTransparent = true;
                    TM.New = hit2.collider.gameObject;
                }
            }
		}
	
	}
}
