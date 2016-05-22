using UnityEngine;
using System.Collections;

public class TurnTrans : MonoBehaviour {

	public Transform player1, player2;
	public LayerMask ignorePlayer;
    public float separados = 12f;
    public float radiusSphere = 5f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.name == "Main Camera(Clone)")
        {
            Ray ray2 = new Ray(player2.transform.position, this.transform.position- player2.transform.position);
            Debug.DrawRay(player2.transform.position, this.transform.position - player2.transform.position);
            RaycastHit[] hits2;
            hits2 = Physics.SphereCastAll(ray2, radiusSphere, this.transform.position.y, ignorePlayer);
            foreach (RaycastHit hit2 in hits2)
            {
                //Debug.Log(hit2.collider);
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
            Ray ray = new Ray(player1.transform.position, this.transform.position - player1.transform.position);
            RaycastHit[] hits;
            //hits = Physics.RaycastAll(ray, this.transform.position.y, ignorePlayer);
            hits = Physics.SphereCastAll(ray, radiusSphere, this.transform.position.y, ignorePlayer);
            foreach (RaycastHit hit in hits)
            {
                //Debug.Log(hit.collider);
                if (hit.collider.GetComponent<Renderer>() != null)
                {
                    if (hit.collider.GetComponent<TransparentObject>() == null)
                    {
                        hit.collider.gameObject.AddComponent<TransparentObject>();
                        hit.collider.GetComponent<TransparentObject>().count = 0;

                    }
                    else
                    {
                        hit.collider.GetComponent<TransparentObject>().count = 0;
                    }
                }
            }
            if (Vector3.Distance(player2.position, player1.position) <= separados)
            {
                Ray ray3 = new Ray(player2.transform.position, this.transform.position - player2.transform.position);
                Debug.DrawRay(player2.transform.position, this.transform.position - player2.transform.position);
                RaycastHit[] hits3;
                hits3 = Physics.SphereCastAll(ray3, radiusSphere, this.transform.position.y, ignorePlayer);
                foreach (RaycastHit hit3 in hits3)
                {
                    //Debug.Log(hit3.collider);
                    if (hit3.collider.GetComponent<Renderer>() != null)
                    {
                        if (hit3.collider.GetComponent<TransparentObject>() == null)
                        {
                            hit3.collider.gameObject.AddComponent<TransparentObject>();
                            hit3.collider.GetComponent<TransparentObject>().count = 0;

                        }
                        else
                        {
                            hit3.collider.GetComponent<TransparentObject>().count = 0;
                        }
                    }
                }
            }

        }
	
	}
}
