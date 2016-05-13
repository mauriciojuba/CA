using UnityEngine;
using System.Collections;

public class AudioManagerDemonioPedra : MonoBehaviour {
	
	public AudioSource audio;

	#region Sons Demonio de Pedra
	public AudioClip laser;
	public AudioClip dano;
	public AudioClip ataquePedras;
	public AudioClip ataqueNormal;
	public AudioClip morte;
	#endregion

	void Start(){
		if(audio == null)
			audio = gameObject.GetComponentInChildren<AudioSource> ();
		
	}
	
	public void PlaySound(int sound){
		
		#region Sons Demonio de Pedra
		if(sound == 1)
			audio.PlayOneShot(laser);
		if(sound == 2)
			audio.PlayOneShot(dano);
		if(sound == 3)
			audio.PlayOneShot(ataquePedras);
		if(sound == 4)
			audio.PlayOneShot(ataqueNormal);
		if(sound == 5)
			audio.PlayOneShot(morte);
  		#endregion
	}
	
}

