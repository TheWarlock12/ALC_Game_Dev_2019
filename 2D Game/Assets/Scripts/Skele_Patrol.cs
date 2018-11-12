﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skele_Patrol : MonoBehaviour {

	// Movement Variables

	public float MoveSpeed;

	public bool MoveRight;

	// Wall Check

	public Transform WallCheck;

	public Transform EdgeCheck;

	public float WallCheckRadius;
	
	public LayerMask WhatIsWall;

	private bool HittingWall;
	// Edge Check
	
	private bool NotAtEdge;
	
	// Update is called once per frame
	void Update () {
		NotAtEdge = Physics2D.OverlapCircle(EdgeCheck.position, WallCheckRadius, WhatIsWall);
		
		HittingWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);

		if (HittingWall || !NotAtEdge){
			MoveRight = !MoveRight;
		}

		if (MoveRight){
			transform.localScale = new Vector3(0.7f, 0.7f, 1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else {
			transform.localScale = new Vector3(-0.7f, 0.7f,1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		
		}
	}
}


