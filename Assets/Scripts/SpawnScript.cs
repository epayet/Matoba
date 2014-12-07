using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{

		public GameObject ArcherPrefab;
		public GameObject WarriorPrefab;
		public GameObject ArcherGobelinPrefab;
		public GameObject OrcPrefab;
		public Perdu perdu;
		public bool enemy;
		private BaseBehaviour maBase;

		void Start ()
		{
				maBase = GetComponentInParent<BaseBehaviour> ();
		}

		public void CreateArcher ()
		{
				CreateUnit (ArcherPrefab, false);
		}

		public void CreateOrc ()
		{
				CreateUnit (OrcPrefab, true);
		}

		public void CreateGobelin ()
		{
				CreateUnit (ArcherGobelinPrefab, false);
		}

		public void CreateWarrior ()
		{
				CreateUnit (WarriorPrefab, true);
		}

		private void CreateUnit (GameObject unite, bool warrior)
		{
				int prix = unite.GetComponent<UniteBehaviour> ().prix;
				if (prix > maBase.argent) {
						return;
				}
				GameObject archer = (GameObject)Instantiate (unite, gameObject.transform.position, gameObject.transform.rotation);
				UniteBehaviour uniteBehaviour = archer.GetComponent<UniteBehaviour> ();
				uniteBehaviour.vaADroite = !enemy;
				uniteBehaviour.perdu = perdu;
				uniteBehaviour.maBase = maBase;
				uniteBehaviour.warrior = warrior;
				archer.tag = enemy ? "unit_team_2" : "unit_team_1";
		}
}
