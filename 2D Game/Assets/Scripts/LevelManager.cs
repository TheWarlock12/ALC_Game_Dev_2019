﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;
	public Rigidbody2D PC;

	// Particles
	public GameObject PC2;

	public GameObject DeathParticle;
	public GameObject RespawnParticle;

	// Respawn Delay

	public float RespawnDelay;

	//Point Penalty on Death
	
	public int PointPenaltyOnDeath;

	// Store Gravity Value
	
	private float GravityStore;

	// Use this for initialization

	void Start() {
		//PC = FindObjectOfType<Rigidbody2D> ();
		PC2 = GameObject.Find("PC");
		PC = GameObject.Find("PC").GetComponent<Rigidbody2D>();
		
	}

	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		//Generate Death Particle
		Instantiate (DeathParticle, PC.transform.position, PC.transform.rotation);
		//Hide PC
		// PC.enabled = false;
		PC2.SetActive(false);
		PC.GetComponent<Renderer> ().enabled = false;
		// Gravity Reset
		GravityStore = PC.GetComponent<Rigidbody2D>().gravityScale;
		PC.GetComponent<Rigidbody2D>().gravityScale = 0f;
		PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		// Point Penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		//Debug Message
		Debug.Log("PC Respawn");
		//Respawn Delay
		yield return new WaitForSeconds (RespawnDelay);
		//Gravity Restore
		PC.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		//Match PCs transform position
		PC.transform.position = CurrentCheckPoint.transform.position;
		//Show PC
		// PC.enabled = true;
		PC2.SetActive(true);
		PC.GetComponent<Renderer> ().enabled = true;
		//Spawn Particle Effects
		Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
}	