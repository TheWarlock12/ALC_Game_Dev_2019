﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour { 

	// Player movement variables
	public int moveSpeed;
	public float jumpHeight;
	private bool doubleJump;

	//Player grounded variables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded; 

	//Non-Slide Player
	private float moveVelocity; 
	public Animator animator;
	// Use this for initialization
	void Start () {
		//animator.SetBool("isWalking",false);
		animator.SetBool("isJumping",true);

	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
	// Update is called once per frame
	void Update () {

		// This code makes the character jump
		if(Input.GetKeyDown (KeyCode.W)&& grounded){
			Jump();
		}
		
		// Double jump code
		if(grounded){
			doubleJump = false;
			animator.SetBool("isJumping",true);
		}	
		
		if(Input.GetKeyDown (KeyCode.W)&& !doubleJump && !grounded){
			Jump();
			doubleJump = true;
		}

		//Non-Slide Player
		moveVelocity = 0f;

		

		//This code makes the character move from side to side using the A&D keys
		if(Input.GetKey (KeyCode.D)){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = moveSpeed;
			//animator.SetBool("isWalking",true);
		}

		//else if(Input.GetKeyUp (KeyCode.D)){
			//animator.SetBool("isWalking",false);
		//}
		if(Input.GetKey (KeyCode.A)){
			//GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = -moveSpeed;
			//animator.SetBool("isWalking",true);
		}
		//else if(Input.GetKeyUp (KeyCode.A)){
			//animator.SetBool("isWalking",false);
		//}
		//Player flip
		if (GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(0.12f, 0.12f, 1f);

		else if (GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3(-0.12f, 0.12f, 1f);
			


		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
	}
	
	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		animator.SetBool("isJumping", false);
	}
	
}
