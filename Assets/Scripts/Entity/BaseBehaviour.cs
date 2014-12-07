using UnityEngine;
using System.Collections;

public class BaseBehaviour : EntityBehaviour {
	public int argent = 100;
    internal override void RecoitAttaque(float attaque) 
    {
        base.RecoitAttaque(attaque);
        if(!EstVivant())
            perdu.aGagne(this);
    }
}
