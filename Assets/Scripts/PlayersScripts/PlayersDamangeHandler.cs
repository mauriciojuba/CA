using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayersDamangeHandler : MonoBehaviour{

    public float HP, MaxHP;
    public Image Bar;
    public float _damangeAmount;

    void Update()
    {
        Bar.fillAmount = (HP / MaxHP);
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
