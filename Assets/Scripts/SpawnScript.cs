using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject ArcherPrefab;
	public bool enemy;

	public void CreateArcher() {
		CreateUnit(ArcherPrefab);
	}

	private void CreateUnit(GameObject unite)
	{
		GameObject archer = (GameObject)Instantiate(unite, gameObject.transform.position, gameObject.transform.rotation);
		archer.GetComponent<UniteBehaviour>().vaADroite = !enemy;
		archer.tag = enemy ? "unit_team_2" : "unit_team_1";
	}
}
