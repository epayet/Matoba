using UnityEngine;
using System.Collections;

public class UniteBehaviour : MonoBehaviour
{
		private Animator animator;
		public float vie = 10;
		public float attaque;
		public float portee = 5;
		public bool vaADroite;
		public float vitesse;
		private string enemy_tag;
		private bool estEnTrainDAttaquer = false;
		private bool vivant = true;

		public bool EstVivant ()
		{
				return vie > 0;
		}

		// Use this for initialization
		void Start ()
		{
				animator = GetComponent<Animator> ();
				if (!vaADroite) {
						vitesse = -vitesse;
						float factorX = -transform.localScale.x;

						Vector3 scale = transform.localScale;
						scale.x = factorX;
						transform.localScale = scale;
				}
				enemy_tag = "unit_team_" + (vaADroite ? "2" : "1");
		}

		// Update is called once per frame
		void Update ()
		{
				if (vivant) {
						if (vie <= 0) {
								Mourir ();
						} else if (estEnTrainDAttaquer) {
								if (!animator.GetCurrentAnimatorStateInfo (0).IsName ("Attack")) {
										estEnTrainDAttaquer = false;	
								}
						} else {
								var closest = EnemieLePlusProche ();
								if (!AttaqueSiPossible (closest)) {
										Marche ();
								}
						}
						//peutAvancer = true;
				} 
		}

		void Mourir ()
		{
				vivant = false;
				animator.SetTrigger ("die");
				Object.Destroy (gameObject, 2);
				Destroy (rigidbody2D);
				Destroy (GetComponent<BoxCollider2D> ());
		}

		GameObject EnemieLePlusProche ()
		{
				GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemy_tag);
				GameObject closest = null;
				float closestDistance = 0;
				foreach (GameObject enemy in enemies) {
						float distance = System.Math.Abs (transform.position.x - enemy.transform.position.x);
						UniteBehaviour otherBehaviour = enemy.GetComponent<UniteBehaviour> ();
						if ((closest == null || closestDistance >= distance) && otherBehaviour.EstVivant ()) {
								closestDistance = distance;
								closest = enemy;
						}
				}
				return closest;
		}

		bool AttaqueSiPossible (GameObject closest)
		{
				if (closest != null) {
						if (EstAPortee (closest)) {
								animator.SetTrigger ("attack");
								estEnTrainDAttaquer = true;
								UniteBehaviour other = closest.GetComponent<UniteBehaviour> ();
								other.vie -= attaque;
								return true;
						}
				}
				return false;
		}

		bool EstAPortee (GameObject closest)
		{
				return closest.collider2D.bounds.SqrDistance (transform.position) <= portee * portee;
		}

		void Marche ()
		{
				bool peutAvancer = PeutAvancer ();
				animator.SetBool ("idle", !peutAvancer);
				if (peutAvancer) {
						transform.Translate (Vector3.right * vitesse * Time.deltaTime);
				}
		}

		bool PeutAvancer ()
		{
				GameObject prochaineUnite = null;
				GameObject[] monEquipe = GameObject.FindGameObjectsWithTag (gameObject.tag);
				foreach (GameObject unite in monEquipe) {
						UniteBehaviour behaviour = unite.GetComponent<UniteBehaviour> ();
						if (unite != gameObject && behaviour.EstVivant ()) {
								if (unite.collider2D.bounds.Intersects (this.collider2D.bounds) && EstDevant (unite)) {
										return false;
								}
						}
				}
				return true;
		}

		bool EstDevant (GameObject other)
		{
				return (vaADroite && this.transform.position.x < other.transform.position.x) ||
						(!vaADroite && this.transform.position.x > other.transform.position.x);
		}
}
