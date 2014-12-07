using UnityEngine;
using System.Collections;

public class UniteBehaviour : EntityBehaviour
{
		private Animator animator;
		public float attaque;
		public float portee = 5;
		public bool vaADroite;
		public float vitesse;
		private string enemy_tag;
        private string base_enemy_tag;
		private bool estEnTrainDAttaquer = false;
		private bool vivant = true;
		public GameObject attackOrigin;

		// Use this for initialization
		public override void Start ()
		{
            base.Start();
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
						if (enemyGameObject.tag == enemy_tag || enemyGameObject.tag == base_enemy_tag) {
                            EntityBehaviour enemyBehaviour = enemyGameObject.GetComponent<EntityBehaviour>();
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
                        EntityBehaviour other = closest.GetComponent<EntityBehaviour>();
                        other.RecoitAttaque(attaque);
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
            if (perdu.aPerdu)
                return false;

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

        //internal override void RecoitAttaque(float attaque)
        //{
        //    base.RecoitAttaque(attaque);
        //}
}
