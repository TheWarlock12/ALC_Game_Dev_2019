using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour {

	public static int Mana;


	Text ManaText;


	// Use this for initialization
	void Start () {
		ManaText = GetComponent<Text>();

		Mana = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		if (Mana < 0)
			Mana = 0
			
			

		ManaText.text = " " + Mana;
	}

	public static void AddPoints (int PointsToAdd){
		Mana += PointsToAdd;
	}
}