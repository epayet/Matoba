using UnityEngine;
using System.Collections;

public class IA : MonoBehaviour
{

		private float time = 0;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				time -= Time.deltaTime;
				if (time <= 0.0) {
						time = Random.Range (1, 5);
						if (Random.Range ((float)0.0, (float)1.0) > 0.5) {
								gameObject.GetComponent<SpawnScript> ().CreateOrc ();
						} else {
								gameObject.GetComponent<SpawnScript> ().CreateGobelin ();
						}
				}
		}
}
