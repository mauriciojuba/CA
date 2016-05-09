using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NeedHelp : MonoBehaviour {

    public Image Bar, _Button;
    public GameObject helpParticle;




    GameObject canvas, otherPlayer;
    bool pressingButton;
    bool canHelp;
    float helpingTime, saveTime = 2f;
    Vector3 screenPosition;



    void Start()
    {
        canvas = GameObject.Find("Canvas");
        Bar = Resources.Load("BarHelp") as Image;
        Bar = Resources.Load("_Button") as Image;
        SetOtherPlayer();
        NeedHelpAnimation();
        //helpParticle.SetActive(true);
        screenPosition = Camera.main.WorldToScreenPoint(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z));
        

    }
    void Update()
    {
        //substituir pelo botão do controle
        if (Input.GetKeyDown(KeyCode.L)) pressingButton = true;
        else pressingButton = false;
        
        SetButtonON();
    }
    void FreezePlayer()
    {
        //stop Controlles from that Character
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
        Debug.Log(otherPlayer);
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
            _Button.transform.SetParent(canvas.transform, false);
            _Button.transform.position = screenPosition;
            //set the bar ON
            Bar.transform.SetParent(canvas.transform, false);
            Bar.transform.position = screenPosition;
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
