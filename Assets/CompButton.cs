using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompButton : MonoBehaviour {
	Text instruction;
	public Button Suiv;
	public bool isActiveBase;
	public Text Inf;

	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text> ();
		GetComponentInParent<Button> ().enabled = isActiveBase;
	}

	public void Barre(){
			instruction.text = "X";
			GetComponentInParent<Button> ().enabled = false;
			Suiv.enabled = true;
	}

	public void MouseOverIt(string Msg) {
		Inf.text = Msg;
	}

}
