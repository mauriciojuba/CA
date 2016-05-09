using UnityEngine;
using System.Collections;

public class AudioManagerDemonioAgua : MonoBehaviour {
	
	public AudioSource audio;

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

	void Start(){
		if(audio == null)
			audio = gameObject.GetComponentInChildren<AudioSource> ();
		
	}
	
	public void PlaySound(int sound){
		
		#region SONS DO DEMONIO DA AGUA
		if(sound == 1)
			audio.PlayOneShot(Demonio_Agua_Voz_1);
		if(sound == 2)
			audio.PlayOneShot(Demonio_Agua_Voz_2);
		if(sound == 3)
			audio.PlayOneShot(Demonio_Agua_Andar);
		if(sound == 4)
			audio.PlayOneShot(Demonio_Agua_Dano);
		if(sound == 5)
			audio.PlayOneShot(Demonio_Agua_Morte);
		if(sound == 6)
			audio.PlayOneShot(Demonio_Agua_Ataque);

		#endregion

		#region Sons Mob Demonio de Agua
		if(sound == 7)
			audio.PlayOneShot(Demonio_Agua_Mob_Voz_1);
		if(sound == 8)
			audio.PlayOneShot(Demonio_Agua_Mob_Voz_2);
		if(sound == 9)
			audio.PlayOneShot(Demonio_Agua_Mob_Voz_3);
		if(sound == 10)
			audio.PlayOneShot(Demonio_Agua_Mob_Andar);
		if(sound == 11)
			audio.PlayOneShot(Demonio_Agua_Mob_Morte);
		#endregion
	}
	
}

