using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	// Destination variables
	public Transform Destination;
	public GameObject PC;
	// Use this for initialization
	void Start () {
		PC = GameObject.Find("PC");
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "PC")
		PC.transform.position = Destination.transform.position;
	}
}
