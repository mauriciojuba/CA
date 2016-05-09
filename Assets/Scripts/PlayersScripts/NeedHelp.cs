using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NeedHelp : MonoBehaviour {

    public Image Bar, Button;
    public GameObject helpParticle;



    GameObject otherPlayer;
    bool pressingButton;
    bool canHelp;
    float helpingTime, saveTime = 2f;


	void Start()
    {
        SetOtherPlayer();
        NeedHelpAnimation();
    }
    void Update()
    {
        SetButtonON();
    }
    void SetOtherPlayer()
    {
        if (this.CompareTag("Player1"))
        {
            otherPlayer = GameObject.Find("PlayerTurnip");
        }
        else if (this.CompareTag("Player2"))
        {
            otherPlayer = GameObject.Find("PlayerCamponesa");
        }
    }
    void NeedHelpAnimation()
    {
        Animator anim;
        anim = GetComponent<Animator>();
        //set the bool to start animation
    }
    void Particles()
    {
        //Set the Particles ON
    }
    void SetButtonON()
    {
        if (canHelp)
        {
            //Set Button On and Place at player position
            //aumenta o tamanho do botão
            //set the bar ON
            if (pressingButton)
            {
                //Set Circle Bar ON
                Bar.fillAmount = ((saveTime * 5f) / (helpingTime * 5f));
                helpingTime += Time.deltaTime;
                if (helpingTime >= saveTime) savedPlayer();
            }
            else
            {
                helpingTime = 0;
                Bar.fillAmount = 0;
            }
        }

    }
    void CheckPlayerNear()
    {
        if (Vector3.Distance(this.transform.position, otherPlayer.transform.position) <= 1.5f) canHelp = true;
        else canHelp = false;
    }
    void savedPlayer()
    {
        Destroy(this);
    }
    void OnDestroy()
    {
        this.gameObject.GetComponent<PlayersDamangeHandler>().HP = 50f;
    }
}
