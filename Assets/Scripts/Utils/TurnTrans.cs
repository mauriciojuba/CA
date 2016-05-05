using UnityEngine;
using System.Collections;

public class TurnTrans : MonoBehaviour {

	public Transform player1, player2, correctionClone;
	public LayerMask ignorePlayer;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.name == "Main Camera(Clone)")
        {
            Ray ray2 = new Ray(player2.transform.position, correctionClone.position - player2.transform.position);
            Debug.DrawRay(player2.transform.position, correctionClone.position - player2.transform.position);
            RaycastHit[] hits2;
            hits2 = Physics.RaycastAll(ray2,this.transform.position.y, ignorePlayer);
            foreach (RaycastHit hit2 in hits2)
            {
                Debug.Log(hit2.collider);
                if (hit2.collider.GetComponent<Renderer>() != null)
                {
                    if (hit2.collider.GetComponent<TransparentObject>() == null)
                    {
                        hit2.collider.gameObject.AddComponent<TransparentObject>();
                        hit2.collider.GetComponent<TransparentObject>().count = 0;

                    }
                    else
                    {
                        hit2.collider.GetComponent<TransparentObject>().count = 0;
                    }
                }
            }
        }
        else
        {
            
            RaycastHit hit;
            if (Physics.Linecast(player1.position, Camera.main.transform.position, out hit, ignorePlayer))
            {
                //Debug.Log(hit.collider);
                if (!(hit.collider.GetComponent<Renderer>() == null))
                {
                    if (hit.collider.GetComponent<TransparentObject>() == null)
                    {
                        hit.collider.gameObject.AddComponent<TransparentObject>();
                        //hit.collider.GetComponent<TransparentObject>().beTransparent = true;
                        //TM.New = hit.collider.gameObject;
                    }
                    else
                    {
                        //hit.collider.GetComponent<TransparentObject>().beTransparent = true;
                        //TM.New = hit.collider.gameObject;
                    }
                }
            }
        }
	
	}
}
