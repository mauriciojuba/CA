using UnityEngine;
using System.Collections;

public class TransparencyManager : MonoBehaviour {

    public GameObject Last, New;
    public GameObject Last2, New2;
    public GameObject transparent;
    public GameObject transparent2;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckObjects();
        CheckObjects2();
        if(transparent != null) transparent.GetComponent<TransparentObject>().beTransparent = true;
        if(Last != null) Last.GetComponent<TransparentObject>().beTransparent = false;
        if (transparent2 != null) transparent2.GetComponent<TransparentObject>().beTransparent = true;
        if (Last2 != null) Last2.GetComponent<TransparentObject>().beTransparent = false;
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
    void CheckObjects2()
    {
        if (New2 != null)
        {
            if (transparent2 == null)
            {
                transparent2 = New2;
            }
            else
            {
                if (New2.transform.position != transparent2.transform.position)
                {
                    Last2 = transparent2;
                    transparent2 = New2;
                }
            }
        }

    }
}
