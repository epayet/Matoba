using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseBehaviour : EntityBehaviour
{
		public int argent = 100;
		public Text affichageArgent;
		public ParticleSystem smokeWeed;

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
				if (affichageArgent) {
						affichageArgent.text = argent.ToString ();		
				}
		}    
}
