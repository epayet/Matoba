using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LastSkill : MonoBehaviour {
	Text instruction;
	public Text one;
	public Text two;
	public Text three;
	
	void Start () {
		GetComponentInParent<Button> ().enabled = false;
		instruction = GetComponent<Text> ();
	}
	
	bool AllOk(){
		// oups
		return one.text == "X" && two.text == "X" && three.text == "X";
	}

	void Update(){
		if(AllOk())
			GetComponentInParent<Button> ().enabled = true;
	}

	public void Barre(){
		if (AllOk()) {
			GetComponentInParent<Button> ().enabled = true;
			instruction.text = "X";
			GetComponentInParent<Button> ().enabled = false;
		}
	}
}
