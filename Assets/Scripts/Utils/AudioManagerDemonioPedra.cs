using UnityEngine;
using System.Collections;

public class AudioManagerDemonioPedra : MonoBehaviour {
	
	public AudioSource audio;

	#region Sons Demonio de Pedra
	public AudioClip laser;
	public AudioClip andar;
	public AudioClip ataquePedras;
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
			audio.PlayOneShot(andar);
		if(sound == 3)
			audio.PlayOneShot(ataquePedras);
  		#endregion
	}
	
}

