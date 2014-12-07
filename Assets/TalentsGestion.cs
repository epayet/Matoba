using UnityEngine;
using System.Collections;

public class TalentsGestion : MonoBehaviour {/*
	int[] attack;
	int[] defense;
	int[] others;*/

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);/*
		attack = new int[]{0,0,0};
		defense = new int[]{0,0,0};
		others = new int[]{0,0,0};*/
	}

	public void AddAttack(int value){
		//attack [value] += 1;
	}

	public void Show(){
		gameObject.SetActive (true);
	}

	public void Hide(){
		gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
