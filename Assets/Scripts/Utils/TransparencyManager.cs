using UnityEngine;
using System.Collections;

public class TransparencyManager : MonoBehaviour {

    public GameObject Last, New;
    public GameObject transparent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckObjects();
        if(transparent != null) transparent.GetComponent<TransparentObject>().beTransparent = true;
        if(Last != null) Last.GetComponent<TransparentObject>().beTransparent = false;
    }
    

    void CheckObjects()
    {
        if (New != null)
        {
            if (transparent == null)
            {
                transparent = New;
            }
            else
            {
               if(New.transform.position != transparent.transform.position)
                {
                    Last = transparent;
                    transparent = New;
                } 
            }
        }

    }
}
