﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Unite : MonoBehaviour {

    public Transform CampSpawner,OriginalObj;
    public Transform Turnip;
    bool closeEnough, everybodyOk;
    public bool attach,skill;
    float count = 0;

    void Update()
    {
        
        if ((this.GetComponent<SwitchPlayer>().controlling == "Player1") && InputManager.YButton() && closeEnough && everybodyOk && !attach)
        {
            skill = true;
            //this.GetComponent<SwitchPlayer>().controlling = "Player2";
            this.GetComponent<Animator>().SetBool("OnGround", false);
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<ThirdPersonUserControlCamponesa>().enabled = false;
            this.GetComponent<CapsuleCollider>().enabled = false;
            
            //this.transform.SetParent(CampSpawner);
            
            attach = true;
            

        }
        if (attach)
        {
            count += Time.deltaTime;
            this.gameObject.transform.position = CampSpawner.transform.position;
            Vector3 heightCorrectedPoint = new Vector3(Turnip.transform.position.x, this.transform.position.y, Turnip.transform.position.z);
            this.transform.LookAt(heightCorrectedPoint);
            if (InputManager.YButton() && count >= 3f)
            {
                //this.transform.SetParent(OriginalObj);
                this.GetComponent<CapsuleCollider>().enabled = true;
                this.GetComponent<Animator>().SetBool("OnGround", true);
                this.GetComponent<Animator>().enabled = true;
                this.GetComponent<ThirdPersonUserControlCamponesa>().enabled = true;
                attach = false;
                count = 0;
            }
        }
        checkIfEverybodyIsOk();
    }
    void FixedUpdate()
    {
        if (Vector3.Distance(Turnip.position, this.transform.position) <= 1f) closeEnough = true;
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
}
