using UnityEngine;
using System.Collections;

public class CreateUnit : MonoBehaviour {

	public GameObject unit;
	public GameObject startPosition;

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			// créer le GameObject
			Instantiate(unit, startPosition.transform.position, startPosition.transform.rotation);
		}
	}
}
