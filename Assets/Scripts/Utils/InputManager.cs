using UnityEngine;
using System.Collections;

public static class InputManager
{
	public static int players;
	private static float deadZone = 0.2f;

	#region Axis
	public static float LeftStickHorizontal(){
		float r = 0.0f;
		r += Input.GetAxis ("LEFT_JoystickHorizontal");
		r += Input.GetAxis ("Horizontal");
		return Mathf.Clamp (r, -1.0f, 1.0f);
	}

	public static float LeftStickVertical(){
		float r = 0.0f;
		r += Input.GetAxis ("LEFT_JoystickVertical");
		r += Input.GetAxis ("Vertical");
		return Mathf.Clamp (r, -1.0f, 1.0f);
	}

	public static Vector3 LeftStick(){
		return new Vector3 (LeftStickHorizontal (), 0, LeftStickVertical ());
	}

	public static float RightStickHorizontal(){
		float r = 0.0f;
		r += Input.GetAxis ("RIGHT_JoystickHorizontal");
		return Mathf.Clamp (r, -1.0f, 1.0f);
	}

	public static float RightStickVertical(){
		float r = 0.0f;
		r += Input.GetAxis ("RIGHT_JoystickVertical");
		return Mathf.Clamp (r, -1.0f, 1.0f);
	}

	public static Vector3 RightStick(){
		return new Vector3 (RightStickHorizontal (), 0, RightStickVertical ());
	}

	public static float DPadHorizontal(){
		float r = 0.0f;
		r += Input.GetAxis ("XBOX_DpadHorizontal");
		return Mathf.Clamp (r, -1.0f, 1.0f);
	}

	public static float DPadVertical(){
		float r = 0.0f;
		r += Input.GetAxis ("XBOX_DpadVertical");
		return Mathf.Clamp (r, -1.0f, 1.0f);
	}

	public static Vector3 Dpad(){
		return new Vector3 (DPadHorizontal (), 0, DPadVertical());
	}
	#endregion

	#region Buttons
	public static bool AButton()
	{
		return Input.GetButtonDown ("XBOX_buttonA");
	}

	public static bool BButton()
	{
		return Input.GetButtonDown ("XBOX_buttonB");
	}

	public static bool XButton()
	{
		return Input.GetButtonDown ("XBOX_buttonX");
	}

	public static bool YButton()
	{
		return Input.GetButtonDown ("XBOX_buttonY");
	}

	public static bool RButton()
	{
		return Input.GetButtonDown ("XBOX_buttonR");
	}

	public static bool LButton()
	{
		return Input.GetButtonDown ("XBOX_buttonL");
	}

	public static bool StartButton()
	{
		return Input.GetButtonDown ("XBOX_buttonSTART");
	}

	public static bool BackButton()
	{
		return Input.GetButtonDown ("XBOX_buttonBACK");
	}
	#endregion

	#region Hold Buttons
	public static bool BButtonHold()
	{
		return Input.GetButton ("XBOX_buttonB");
	}
	#endregion

	#region Axis as Buttons
	public static bool LeftTriggerInUse = false;
//	public static bool LeftTriggerButton(){
//
//	}
	#endregion
}
