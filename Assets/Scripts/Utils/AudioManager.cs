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
	public AudioClip navigateMenu;
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

	public AudioClip Blobman_Ataque;
	public AudioClip Blobman_Dano;
	public AudioClip Blobman_Morte;
	public AudioClip Blobman_Passos;

	#endregion

	#region Sons Demonio de Agua

	public AudioClip Demonio_Agua_Voz_1;
	public AudioClip Demonio_Agua_Voz_2;
	public AudioClip Demonio_Agua_Andar;
	public AudioClip Demonio_Agua_Dano;
	public AudioClip Demonio_Agua_Morte;
	public AudioClip Demonio_Agua_Ataque;

	#endregion

	#region Sons Mob Demonio de Agua

	public AudioClip Demonio_Agua_Mob_Voz_1;
	public AudioClip Demonio_Agua_Mob_Voz_2;
	public AudioClip Demonio_Agua_Mob_Voz_3;
	public AudioClip Demonio_Agua_Mob_Andar;
	public AudioClip Demonio_Agua_Mob_Morte;

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

		#region SONS DO BLOBMAN
		if(sound == 8)
			audio.PlayOneShot(Blobman_Ataque);
		if(sound == 9)
			audio.PlayOneShot(Blobman_Dano);
		if(sound == 10)
			audio.PlayOneShot(Blobman_Morte);
		if(sound == 11)
			audio.PlayOneShot(Blobman_Passos);
		#endregion

		#region SONS DO DEMONIO DA AGUA
		if(sound == 12)
			audio.PlayOneShot(Demonio_Agua_Voz_1);
		if(sound == 13)
			audio.PlayOneShot(Demonio_Agua_Voz_2);
		if(sound == 14)
			audio.PlayOneShot(Demonio_Agua_Andar);
		if(sound == 15)
			audio.PlayOneShot(Demonio_Agua_Dano);
		if(sound == 16)
			audio.PlayOneShot(Demonio_Agua_Morte);
		if(sound == 17)
			audio.PlayOneShot(Demonio_Agua_Ataque);

		#endregion

		#region Sons Mob Demonio de Agua
		if(sound == 18)
			audio.PlayOneShot(Demonio_Agua_Mob_Voz_1);
		if(sound == 19)
			audio.PlayOneShot(Demonio_Agua_Mob_Voz_2);
		if(sound == 20)
			audio.PlayOneShot(Demonio_Agua_Mob_Voz_3);
		if(sound == 21)
			audio.PlayOneShot(Demonio_Agua_Mob_Andar);
		if(sound == 22)
			audio.PlayOneShot(Demonio_Agua_Mob_Morte);
		#endregion
	}
	
}

