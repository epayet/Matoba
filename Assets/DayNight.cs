using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {

	private Time time;
	public int DayDuration = 30;
	public Light Soleil;
	public Light Lune;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, Time.deltaTime * 50);
		if (transform.rotation.eulerAngles.z > 100 && transform.rotation.eulerAngles.z < 260) {
			Soleil.enabled = true;
			Lune.enabled = false;
		} 
		else {
			Soleil.enabled = false;
			Lune.enabled = true;
		}
	}
}