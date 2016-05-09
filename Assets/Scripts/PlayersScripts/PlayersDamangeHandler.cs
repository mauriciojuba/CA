using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayersDamangeHandler : MonoBehaviour{

    public float HP, MaxHP;
    public Image Bar;
    public float _damangeAmount;

    bool hurted = false;

    void Update()
    {
        Bar.fillAmount = (HP / MaxHP);
        if (HP <= 10 && !hurted)
        {
            NeedHelp.Instance.CreateHelpSign(this.gameObject);
            hurted = true;
        }
        else if(HP > 10) hurted = false;
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
