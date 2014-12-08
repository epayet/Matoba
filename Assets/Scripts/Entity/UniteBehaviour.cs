﻿using UnityEngine;
using System.Collections;

public class UniteBehaviour : EntityBehaviour
{
		public float attaque;
		public float portee = 5;
		public bool vaADroite;
		public float vitesse;
		public GameObject attackOrigin;
		public BaseBehaviour maBase;
		public int prix;
		public bool warrior;
		private Animator animator;
		private string enemy_tag;
		private string base_enemy_tag;
		private float lastAttack = 0;
		private bool vivant = true;

		// Use this for initialization
		public override void Start ()
		{
				base.Start ();
				animator = GetComponentInChildren<Animator> ();
				if (!vaADroite) {
						vitesse = -vitesse;
						Vector3 scale = animator.gameObject.transform.localScale;
						scale.x = -scale.x;
						animator.gameObject.transform.localScale = scale;
				}
				enemy_tag = "unit_team_" + (vaADroite ? "2" : "1");
				base_enemy_tag = "base_team_" + (vaADroite ? "2" : "1");
		}
		
		
		// Update is called once per frame
		void Update ()
		{
				lastAttack -= Time.deltaTime;
				bool 
				estEnTrainDAttaquer = lastAttack > 0;
				if (vivant) {
						if (vie <= 0) {
								Mourir ();
						} else if (!estEnTrainDAttaquer) {
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
						if (enemyGameObject.tag == enemy_tag || enemyGameObject.tag == base_enemy_tag) {
								EntityBehaviour enemyBehaviour = enemyGameObject.GetComponent<EntityBehaviour> ();
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
						EntityBehaviour other = closest.GetComponent<EntityBehaviour> ();
						other.RecoitAttaque (GetAttaque ());
						lastAttack = 1;
						if (!other.EstVivant () && other is UniteBehaviour) {
								maBase.argent += (int)((double)((UniteBehaviour)other).prix * 0.7 * maBase.prixRate);
								maBase.xp += (int)((double)((UniteBehaviour)other).prix * 0.7 * maBase.xpRate);
						}
						return true;
						
				}
				return false;
		}

		private float GetAttaque ()
		{
				float factor = warrior ? maBase.attackWarriorFactor : maBase.attackBowmanFactor;
				return attaque * factor;
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

				if (perdu.fini)
						return false;

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

		internal override void RecoitAttaque (float attaque)
		{
				base.RecoitAttaque (attaque / maBase.defenseUnites);
		}

		public void AttaqueFinie ()
		{
				Debug.LogWarning ("Attack end");
		}
}
