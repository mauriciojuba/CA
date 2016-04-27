using UnityEngine;
using System.Collections;

// FootstepAudio.cs & AudioColliderType.cs
// Written by Mike Cannell, Altrius Ltd.
// http://altri.us
// YouTube instructions: http://youtu.be/yTCIbfH03GQ
// August 19, 2014

// This script assumes that it is attached to an object that uses the Mechanim
// Animation system and uses Animation Events to call the functions below.
// See Youtube video for detailed instructions on how to do this
// Must be used with FootstepAudio.cs attached to an object your character will walk on

public class AudioColliderType : MonoBehaviour {

//Enumerate the drop down list in the Inspe
public enum Mode {Water, Earth, Wood, Grass}
public Mode terrainType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string GetTerrainType(){
		
		string typeString = "";
		
		//This switch statement isn't necessary but it converts the integer
		//to a string so that in the other script you can use a string rather
		//than numbers. If you remove this, you need to modify the other script 
		//to use integers for the "case" 
		switch(terrainType){
		
		case Mode.Water:
			typeString = "Water";
			break;
		case Mode.Earth:
			typeString = "Earth";
			break;
		case Mode.Wood:
			typeString = "Wood";
			break;
		case Mode.Grass:
			typeString = "Grass";
			break;
		default:
			typeString = "";
			break;
			
		}
		
		//return the string value rather than the numerical value
		return typeString;
		
		//A switch statement replaces
		//a long string of if/then statements, it's like saying
		//if(terrainType == Mode.Grass){
		
	}
}
