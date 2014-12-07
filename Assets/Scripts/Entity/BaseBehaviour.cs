using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaseBehaviour : EntityBehaviour
{
		public int argent = 100;
		public Text affichageArgent;

		internal override void RecoitAttaque (float attaque)
		{
				base.RecoitAttaque (attaque);
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
