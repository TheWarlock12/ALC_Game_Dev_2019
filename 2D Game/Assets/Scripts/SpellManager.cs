using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour {

	public static int Mana;


	Text ManaValue;


	// Use this for initialization
	void Start () {
		ManaValue = GetComponent<Text>();

		Mana = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		if (Score < 0)
			Score = 0;

		ScoreText.text = " " + Score;
	}

	public static void AddPoints (int PointsToAdd){
		Score += PointsToAdd;
	}
}




	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
	