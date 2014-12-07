using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{

		public GameObject ArcherPrefab;
		public Perdu perdu;
		public bool enemy;
		public BaseBehaviour maBase;

		public void CreateArcher ()
		{
				CreateUnit (ArcherPrefab);
		}

		private void CreateUnit (GameObject unite)
		{
				int prix = unite.GetComponent<UniteBehaviour> ().prix;
				if (prix < maBase.argent) {
						return;
				}
				GameObject archer = (GameObject)Instantiate (unite, gameObject.transform.position, gameObject.transform.rotation);
				UniteBehaviour uniteBehaviour = archer.GetComponent<UniteBehaviour> ();
				uniteBehaviour.vaADroite = !enemy;
				uniteBehaviour.perdu = perdu;
				archer.tag = enemy ? "unit_team_2" : "unit_team_1";
		}
}
