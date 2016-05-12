using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayersDamangeHandler : MonoBehaviour{

    public float HP, MaxHP;
    public Image Bar;
    public float _damangeAmount;

    public bool hurted = false;

    void Update()
    {
        Bar.fillAmount = (HP / MaxHP);
        if (HP <= 10 && !hurted)
        {
            NeedHelp.Instance.CreateHelpSign(this.gameObject);
            hurted = true;
            if (this.GetComponent<ThirdPersonUserControlTurnip>() != null)
            {
                this.GetComponent<ThirdPersonUserControlTurnip>().active = false;
            }
            if (this.GetComponent<ThirdPersonUserControlCamponesa>() != null)
            {
                this.GetComponent<ThirdPersonUserControlCamponesa>().active = false;
            }
        }
        else if(HP > 10) {
            hurted = false;
            if (this.GetComponent<ThirdPersonUserControlTurnip>() != null)
            {
                this.GetComponent<ThirdPersonUserControlTurnip>().active = true;
            }
            if (this.GetComponent<ThirdPersonUserControlCamponesa>() != null && !this.GetComponent<Unite>().attach)
            {
                this.GetComponent<ThirdPersonUserControlCamponesa>().active = true;
            }
        }
    }

//use essa função com para infligir dano no personagem.
    public void HitPLayer(float damangeAmount)
    {
        HP = HP - damangeAmount;
        Bar.fillAmount = (HP / MaxHP);
	}
	//use essa função com para recuperar HP no personagem.
	public void RecoveryPlayer(float recoveryAmount)
	{
		HP = HP + recoveryAmount;
		Bar.fillAmount = (HP / MaxHP);
	}
    
}
