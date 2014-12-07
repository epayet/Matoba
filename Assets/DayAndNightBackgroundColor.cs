using UnityEngine;
using System.Collections;

public class DayAndNightBackgroundColor : MonoBehaviour {
	public float maxBlue = 255f;
	public float minBlue = 0.2f;
	public float BlueNow = 1f;
	public float Speed = 0.2f;
	bool day = false;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (BlueNow >= maxBlue)
			day = false;
		if (BlueNow <= minBlue)
			day = true;

		if(day)
			BlueNow += Speed * Time.deltaTime;
		else
			BlueNow -= Speed * Time.deltaTime;

		Color newColor = new Color( 0, 0, BlueNow,1.0f );
		// apply it on current object's material
		renderer.material.color = newColor;
	}
}
