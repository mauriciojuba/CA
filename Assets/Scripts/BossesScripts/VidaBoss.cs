using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VidaBoss : MonoBehaviour {

	public Image BarraDeVida;

	void Update () {
		BarraDeVida.fillAmount = FSM_Demonio_Pedra.vida / 100;
	}
		
}
