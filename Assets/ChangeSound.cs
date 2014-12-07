using UnityEngine;
using System.Collections;

public class ChangeSound : MonoBehaviour {
	public AudioSource audioBase;
	public AudioSource audioAfter;

	// Use this for initialization
	void Start () {
	
	}

	public void ChangeAudio(){
		audioBase.Stop ();
		audioAfter.Play ();
		audioAfter.mute = false;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
