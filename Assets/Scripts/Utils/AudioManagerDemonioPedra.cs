using UnityEngine;
using System.Collections;

public class AudioManagerDemonioPedra : MonoBehaviour {
	
	public AudioSource audio;

	#region Sons Demonio de Pedra
	public AudioClip laserCarregando, laserAtirando;
	public AudioClip dano;
	public AudioClip ataquePedrasCarregando, ataquePedrasAtirando;
	public AudioClip ataqueNormal;
	public AudioClip morte;
	public AudioClip voz1, voz2, voz3;
	#endregion

	void Start(){
		if(audio == null)
			audio = gameObject.GetComponentInChildren<AudioSource> ();
		
	}
	
	public void PlaySound(int sound){
		
		#region Sons Demonio de Pedra
		if(sound == 1){
			audio.clip = laserCarregando;
			audio.Play();
		}
		if(sound == 2){
			audio.clip = laserAtirando;
			audio.Play();
		}
		if(sound == 3)
			audio.PlayOneShot(dano);
		if(sound == 4){
			audio.clip = ataquePedrasCarregando;
			audio.Play();
		}
		if(sound == 5){
            audio.PlayOneShot(ataquePedrasAtirando);
		}
		if(sound == 6)
			audio.PlayOneShot(ataqueNormal);
		if(sound == 7)
			audio.PlayOneShot(morte);
		if(sound == 8)
			audio.PlayOneShot(voz1);
		if(sound == 9)
			audio.PlayOneShot(voz2);
		if(sound == 10)
			audio.PlayOneShot(voz3);

  		#endregion
	}
	
}

