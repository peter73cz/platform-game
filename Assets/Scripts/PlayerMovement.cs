using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Animator animator;
	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	
	void Update () {
		
		if ((Input.GetKey(KeyCode.A) && gameObject.layer == 8) | (Input.GetKey(KeyCode.LeftArrow) && gameObject.layer == 9) | (Input.GetKey(KeyCode.Keypad4) && gameObject.layer == 10) | (Input.GetKey(KeyCode.J) && gameObject.layer == 11))
		{
			horizontalMove = -runSpeed;
			if ((Input.GetKey(KeyCode.D) && gameObject.layer == 8) | (Input.GetKey(KeyCode.RightArrow) && gameObject.layer == 9) | (Input.GetKey(KeyCode.Keypad6) && gameObject.layer == 10) | (Input.GetKey(KeyCode.L) && gameObject.layer == 11))
			{
				horizontalMove = 0;
			}
		}
		else if ((Input.GetKey(KeyCode.D) && gameObject.layer == 8) | (Input.GetKey(KeyCode.RightArrow) && gameObject.layer == 9) | (Input.GetKey(KeyCode.Keypad6) && gameObject.layer == 10) | (Input.GetKey(KeyCode.L) && gameObject.layer == 11))
		{
			horizontalMove = runSpeed;
			if ((Input.GetKey(KeyCode.A) && gameObject.layer == 8) | (Input.GetKey(KeyCode.LeftArrow) && gameObject.layer == 9) | (Input.GetKey(KeyCode.Keypad4) && gameObject.layer == 10) | (Input.GetKey(KeyCode.J) && gameObject.layer == 11))
			{
				horizontalMove = 0;
			}
		}
		else if (!((Input.GetKey(KeyCode.D) && gameObject.layer == 8) | (Input.GetKey(KeyCode.RightArrow) && gameObject.layer == 9) | (Input.GetKey(KeyCode.Keypad6) && gameObject.layer == 10) | (Input.GetKey(KeyCode.L) && gameObject.layer == 11)) && !((Input.GetKey(KeyCode.A) && gameObject.layer == 8) | (Input.GetKey(KeyCode.LeftArrow) && gameObject.layer == 9) | (Input.GetKey(KeyCode.Keypad4) && gameObject.layer == 10) | (Input.GetKey(KeyCode.J) && gameObject.layer == 11)))
		{
			horizontalMove = 0;
		}

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if ((Input.GetKey(KeyCode.W) && gameObject.layer == 8) | (Input.GetKey(KeyCode.UpArrow) && gameObject.layer == 9) | (Input.GetKey(KeyCode.Keypad8) && gameObject.layer == 10) | (Input.GetKey(KeyCode.I) && gameObject.layer == 11))
		{
			jump = true;
			animator.SetBool("Jump", true);
		}

		if ((Input.GetKeyDown(KeyCode.S) && gameObject.layer == 8) | (Input.GetKeyDown(KeyCode.DownArrow) && gameObject.layer == 9) | (Input.GetKeyDown(KeyCode.Keypad5) && gameObject.layer == 10) | (Input.GetKeyDown(KeyCode.K) && gameObject.layer == 11))
		{
			crouch = true;
		} else if ((Input.GetKeyUp(KeyCode.S) && gameObject.layer == 8) | (Input.GetKeyUp(KeyCode.DownArrow) && gameObject.layer == 9) | (Input.GetKeyUp(KeyCode.Keypad5) && gameObject.layer == 10) | (Input.GetKeyUp(KeyCode.K) && gameObject.layer == 11))
		{
			crouch = false;
		}

	}

	public void OnLanding()
	{
		animator.SetBool("Jump", false);
	}

	public void OnCrouching(bool Crouch)
	{
		animator.SetBool("Crouch", Crouch);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
