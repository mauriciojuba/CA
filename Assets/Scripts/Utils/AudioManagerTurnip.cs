using UnityEngine;
using System.Collections;

public class AudioManagerTurnip : MonoBehaviour {
	
	public AudioSource audio;

	#region Sons Turnip
	public AudioClip ataqueTurnip;
	#endregion

	void Start(){
		if(audio == null)
			audio = gameObject.GetComponentInChildren<AudioSource> ();
		
	}
	
	public void PlaySound(int sound){

		#region SONS DE INTERAÇÃO DO TURNIP
		if (sound == 6) {
			audio.PlayOneShot(ataqueTurnip);
		}
		#endregion

	}
	
}

