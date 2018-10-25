using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour {

	public static int ManaValue;


	Text ManaText;


	// Use this for initialization
	void Start () {
		ManaValue = GetComponent<Text>();

		ManaValue = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		if (ManaValue <= 0)
			
			

		ManaText.text = " " + ManaValue;
	}

	public static void AddPoints (int PointsToAdd){
		ManaValue += PointsToAdd;
	}
}