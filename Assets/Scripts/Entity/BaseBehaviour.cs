using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseBehaviour : EntityBehaviour
{
		public int argent = 100;
		public int xp;
		public Text affichageArgent;
		public Text affichageXp;
		public ParticleSystem smokeWeed;
		public int incomeRate = 5;
		public float incomeTimeRate = 30;
		public float xpRate = 1;
		public float prixRate = 1;
		private float lastRate = 0;
		public float attackWarriorFactor = 1;
		public float attackBowmanFactor = 1;
		public float defenseUnites = 1;

		public override void Start ()
		{
				base.Start ();
				smokeWeed.Stop ();
		}

		internal override void RecoitAttaque (float attaque)
		{
				base.RecoitAttaque (attaque);
				if ((vie / vieDebut) < 0.33f)
						smokeWeed.Play ();
		
				if (!EstVivant ())
						perdu.aGagne (this);
		}

		void Update ()
		{
				lastRate += Time.deltaTime;		
				if (lastRate >= incomeTimeRate) {
						lastRate = 0;
						argent += (int)((incomeRate * 0.01) * argent);
				}
				if (affichageArgent != null) {
						affichageArgent.text = argent.ToString ();		
				}
				if (affichageXp != null) {
						affichageXp.text = xp.ToString ();		
				}
		}    
}
