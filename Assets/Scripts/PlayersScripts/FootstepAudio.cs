using UnityEngine;
using System.Collections;


public class FootstepAudio : MonoBehaviour {
	
	public AudioClip waterSound;
	public AudioClip earthSound;
	public AudioClip woodSound;
	public AudioClip grassSound;
	public AudioSource audio;
	private string colliderType;
    public GameObject particle;
    public Transform collisionPlace1;
    public Transform collisionPlace2;


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
            GameObject place = GameObject.Instantiate(particle, collisionPlace1.position, collisionPlace1.rotation) as GameObject;
            Destroy(place, 3);
			break;
		case "Wood":
			audio.PlayOneShot(woodSound);
			break;
		case "Grass":
			audio.PlayOneShot(grassSound);
            GameObject place1 = GameObject.Instantiate(particle, collisionPlace2.position, collisionPlace2.rotation) as GameObject;
            Destroy(place1, 3);
                break;	
		}
		
	}
	
	
	
	
}