using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {

	private Time time;
	public int DayDuration = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, Time.deltaTime * DayDuration);
	}
}