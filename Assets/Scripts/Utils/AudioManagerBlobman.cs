using UnityEngine;
using System.Collections;

public class AudioManagerBlobman : MonoBehaviour {
	
	public AudioSource audio;

	#region Sons Blobman

	public AudioClip Blobman_Ataque;
	public AudioClip Blobman_Dano;
	public AudioClip Blobman_Morte;
	public AudioClip Blobman_Passos;

	#endregion



	void Start(){
		if(audio == null)
			audio = gameObject.GetComponentInChildren<AudioSource> ();
		
	}
	
	public void PlaySound(int sound){
		
		#region SONS DO BLOBMAN
		if (sound == 1)
			audio.PlayOneShot (Blobman_Ataque);
		if (sound == 2)
			audio.PlayOneShot (Blobman_Dano);
		if (sound == 3)
			audio.PlayOneShot (Blobman_Morte);
		if (sound == 4)
			audio.PlayOneShot (Blobman_Passos);
		#endregion
	}
}

