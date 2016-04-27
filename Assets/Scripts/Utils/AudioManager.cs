using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	
	public AudioSource audio;

	#region sons fase
	public AudioClip pegaVida;
	public AudioClip destroiErva;
	public AudioClip abrirPortaCeleiro;
	public AudioClip magicaNabos;
	public AudioClip faseConcluida;
	#endregion

	#region Sons do Menu e Progressao do Jogo
	public AudioClip start;
	public AudioClip selectMenu;
	public AudioClip questCompleted;
	public AudioClip gameOver;
	#endregion

	#region Sons Camponesa
	public AudioClip tacarNabos;
	#endregion

	#region Sons Turnip
	public AudioClip ataqueTurnip;
	#endregion

	#region Sons Blobman

	#endregion

	#region Sons Demonio de Agua

	#endregion

	#region Sons Demonio de Pedra

	#endregion

	void Start(){
		if(audio == null)
			audio = gameObject.GetComponentInChildren<AudioSource> ();
	}
	
	public void PlaySound(int sound){
		
		#region SONS DE INTERACAO COM A FASE
		if (sound == 1) {
			audio.PlayOneShot(pegaVida);
		}

		if (sound == 2) {
			audio.PlayOneShot(destroiErva);
		}

		if (sound == 3) {
			audio.PlayOneShot(abrirPortaCeleiro);
		}

		if (sound == 4) {
			audio.PlayOneShot(magicaNabos);
		}

		if (sound == 5) {
			audio.PlayOneShot(faseConcluida);
		}
		#endregion

		#region SONS DE INTERAÇÃO DO TURNIP
		if (sound == 6) {
			audio.PlayOneShot(ataqueTurnip);
		}
		#endregion

		#region SONS DE INTERAÇÃO DA CAMPONESA
		if (sound == 7) {
			audio.PlayOneShot(tacarNabos);
		}
		#endregion
	}
	
}

