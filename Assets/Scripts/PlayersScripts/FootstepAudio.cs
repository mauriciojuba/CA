using UnityEngine;
using System.Collections;


public class FootstepAudio : MonoBehaviour {
	
	public AudioClip waterSound;
	public AudioClip earthSound;
	public AudioClip woodSound;
	public AudioClip grassSound;
	public AudioSource audio;
	private string colliderType;
	
	
	void Start () {
		audio = GameObject.Find ("Sound Control").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(audio == null)
			audio = GameObject.Find ("Sound Control").GetComponent<AudioSource>();
		
		
	}
	
	void OnControllerColliderHit (ControllerColliderHit col){
		
		if(col.gameObject.GetComponent<AudioColliderType>()){
			
			colliderType = col.gameObject.GetComponent<AudioColliderType>().GetTerrainType();
		}
	}
	
	
	void OnCollisionEnter (Collision col){
		
		if(col.gameObject.GetComponent<AudioColliderType>()){
			
			colliderType = col.gameObject.GetComponent<AudioColliderType>().GetTerrainType();
		}
	}
	
	
	
	void PlayStepSoundRunning(){
		switch(colliderType){
		case "Water":
			audio.PlayOneShot(waterSound);
			break;
		case "Earth":
			audio.PlayOneShot(earthSound);
			break;
		case "Wood":
			audio.PlayOneShot(woodSound);
			break;
		case "Grass":
			audio.PlayOneShot(grassSound);
			break;	
		}
		
	}
	
	
	
	
}