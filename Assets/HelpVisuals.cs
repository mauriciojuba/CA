using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelpVisuals : MonoBehaviour {

    public Image _Button, Bar;
	// Use this for initialization
	void OnEnable() {
	    
	}
	// Update is called once per frame
	void Update () {
        if (Bar.fillAmount >= 1) Destroy(this.gameObject);
	}
    void OnDestroy()
    {
        NeedHelp.Instance.CharSaved();
    }
}
