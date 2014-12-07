using UnityEngine;
using System.Collections;

public class HouseScript : MonoBehaviour {

	public GameObject unit;

	public void CreateArcher() {
		Instantiate(unit, gameObject.transform.position, gameObject.transform.rotation);
	}
}
