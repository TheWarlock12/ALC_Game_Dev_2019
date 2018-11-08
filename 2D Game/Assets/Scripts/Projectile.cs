﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float Speed;
	
	public Rigidbody2D PC;
	
	public GameObject EnemyDeath;

	public GameObject ProjectileParticle;

	public int PointsForKill;

	// Use this for initialization
	void Start () {

		if(PC.transform.localScale.x < 0)
			Speed = -Speed;
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);

//Player flip
	if (GetComponent<Rigidbody2D>().velocity.x > 0)
		transform.localScale = new Vector3(-0.7f, 0.7f, 1f);

	else if (GetComponent<Rigidbody2D>().velocity.x < 0)
		transform.localScale = new Vector3(0.7f, 0.7f, 1f);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Enemy"){
			Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
			ScoreManager.AddPoints (PointsForKill);	
		}
		
		Instantiate(ProjectileParticle, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}	

