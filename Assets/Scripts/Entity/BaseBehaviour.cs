using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseBehaviour : EntityBehaviour
{
		public int argent = 100;
		public Text affichageArgent;
		public ParticleSystem smokeWeed;
		public int incomeRate = 5;
		public float incomeTimeRate = 30;
		private float lastRate = 0;

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
		}    
}
