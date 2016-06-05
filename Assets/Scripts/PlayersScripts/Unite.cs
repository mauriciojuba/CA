using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Unite : MonoBehaviour {

    public Transform CampSpawner, CampDump;
    public Transform Turnip;
    bool closeEnough, everybodyOk,alturaChecked;
    public bool attach,skill;
    float count = 0,alturaInicial;

    void Start()
    {
        Invoke("getStartedPosY", 3f);
    }

    void Update()
    {
        preventLimbo();
        if (InputManager.players == 2) {
			if (InputManager.YButton () && closeEnough && everybodyOk && !attach) {
				skill = true;
				this.GetComponent<Animator> ().SetBool ("Unite", true);
				this.GetComponent<CapsuleCollider> ().enabled = false;

				attach = true;
			}
		} else {
        	if ((this.GetComponent<SwitchPlayer> ().controlling == "Player1") && InputManager.YButton () && closeEnough && everybodyOk && !attach) {
				skill = true;
                this.GetComponent<Animator>().SetBool("Unite", true);
				this.GetComponent<CapsuleCollider> ().enabled = false;
            
            
				attach = true;
            

			}
		}
        
		if (attach) {
			count += Time.deltaTime;
			this.gameObject.transform.position = CampSpawner.transform.position;
			Vector3 heightCorrectedPoint = new Vector3 (Turnip.transform.position.x, this.transform.position.y, Turnip.transform.position.z);
			this.transform.LookAt (heightCorrectedPoint);
			if (InputManager.YButton () && count >= 3f) {
                this.transform.position = CampDump.position;
				this.GetComponent<CapsuleCollider> ().enabled = true;
                this.GetComponent<Animator>().SetBool("Unite", false);

                attach = false;
				count = 0;
			}
		
		}
        checkIfEverybodyIsOk();
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(Turnip.position, this.transform.position) <= 2f) closeEnough = true;
        else closeEnough = false;
    }
    
	void checkIfEverybodyIsOk()
    {
        if(Turnip.gameObject.GetComponent<PlayersDamangeHandler>().hurted == true || this.gameObject.GetComponent<PlayersDamangeHandler>().hurted == true)
        {
            everybodyOk = false;
        }
        else
        {
            everybodyOk = true;
        }
    }
    void getStartedPosY()
    {
        alturaInicial = transform.position.y - 5f;
        alturaChecked = true;

    }
    void preventLimbo()
    {
        if(alturaChecked == true && this.transform.position.y<= alturaInicial)
        {
            transform.position = CampSpawner.position;
        }
    }
}
