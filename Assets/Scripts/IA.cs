using UnityEngine;
using System.Collections;

public class IA : MonoBehaviour {

	private float time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > 5) {
			gameObject.GetComponent<SpawnScript> ().CreateArcher ();
			time = 0;
		}
	}
}
