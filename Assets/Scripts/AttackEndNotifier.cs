using UnityEngine;
using System.Collections;

public class AttackEndNotifier : MonoBehaviour
{

		void NotifyAttackEnd ()
		{
				Debug.Log (GetComponentInParent<UniteBehaviour> ().vie);
				GetComponentInParent<UniteBehaviour> ().AttaqueFinie ();
		}
}
