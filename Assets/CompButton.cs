using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompButton : MonoBehaviour {
	Text instruction;
	public Button Suiv;
	public BaseBehaviour player;
	public bool isActiveBase;
	public Text Inf;

	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text> ();
		GetComponentInParent<Button> ().enabled = isActiveBase;
	}

	public void Barre(){
		if(player.xp >= 100){
			instruction.text = "X";
			GetComponentInParent<Button> ().enabled = false;
			Suiv.enabled = true;
			player.DownXp();
		}
	}

	public void MouseOverIt(string Msg) {
		Inf.text = Msg;
	}

}
