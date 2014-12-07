﻿using UnityEngine;
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
		public GameObject attackOrigin;

		public bool EstVivant ()
		{
				return vie > 0;
		}

		// Use this for initialization
		void Start ()
		{
				animator = GetComponentInChildren<Animator> ();
				if (!vaADroite) {
						vitesse = -vitesse;
						Vector3 scale = animator.gameObject.transform.localScale;
						scale.x = -scale.x;
						animator.gameObject.transform.localScale = scale;
				}
				enemy_tag = "unit_team_" + (vaADroite ? "2" : "1");
		}

		// Update is called once per frame
		void FixedUpdate ()
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
				foreach (var raycastHit2D in Physics2D.RaycastAll (attackOrigin.transform.position, vaADroite ? Vector2.right : Vector2.right * (-1), portee)) {
						var enemyGameObject = raycastHit2D.collider.gameObject;
						if (enemyGameObject.tag == enemy_tag) {
								UniteBehaviour enemyBehaviour = enemyGameObject.GetComponent<UniteBehaviour> ();
								if (enemyBehaviour.EstVivant ()) {
										return enemyGameObject;
								}
						}
				}
				return null;
		}

		bool AttaqueSiPossible (GameObject closest)
		{
				if (closest != null) {
						animator.SetTrigger ("attack");
						estEnTrainDAttaquer = true;
						UniteBehaviour other = closest.GetComponent<UniteBehaviour> ();
						other.vie -= attaque;
						return true;
						
				}
				return false;
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
