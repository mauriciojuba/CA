using UnityEngine;
using System.Collections;

public class AudioManagerCamponesa : MonoBehaviour {
	
	public AudioSource audio;

	#region Sons Camponesa
	public AudioClip tacarNabos;
	#endregion


	void Start(){
		if(audio == null)
			audio = gameObject.GetComponentInChildren<AudioSource> ();
		
	}
	
	public void PlaySound(int sound){
		
		#region SONS DE INTERAÇÃO DA CAMPONESA
		if (sound == 1) {
			audio.PlayOneShot(tacarNabos);
		}
		#endregion
	}
	
}

