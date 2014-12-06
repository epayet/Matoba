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
		private bool peutAvancer = true;

		public bool estVivant ()
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
								bool marche = true;
								GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemy_tag);
								GameObject closest = null;
								float closestDistance = 0;
								foreach (GameObject enemy in enemies) {
										float distance = System.Math.Abs (transform.position.x - enemy.transform.position.x);
										UniteBehaviour otherBehaviour = enemy.GetComponent<UniteBehaviour> ();
										if ((closest == null || closestDistance >= distance) && otherBehaviour.estVivant ()) {
												closestDistance = distance;
												closest = enemy;
										}
								}
								if (closest != null) {
										if (closestDistance <= portee) {
												marche = false;
												animator.SetTrigger ("attack");
												estEnTrainDAttaquer = true;
												UniteBehaviour other = closest.GetComponent<UniteBehaviour> ();
												other.vie -= attaque;
										}
								}
								if (marche) {
										animator.SetBool ("idle", !peutAvancer);
										if (peutAvancer) {
												transform.Translate (Vector3.right * vitesse * Time.deltaTime);
										}
								}
						}
						peutAvancer = true;
				} 
		}

		void OnCollisionStay2D (Collision2D other)
		{
				if (other.gameObject.tag == this.gameObject.tag) {
						if (other.gameObject.transform.position.x < transform.position.x && !vaADroite ||
								other.gameObject.transform.position.x > this.transform.position.x && vaADroite) {
								peutAvancer = false;
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
}
