using UnityEngine;
using System.Collections;

public class BaseBehaviour : EntityBehaviour {
    internal override void RecoitAttaque(float attaque) 
    {
        base.RecoitAttaque(attaque);
        if(!EstVivant())
            perdu.aGagne(this);
    }
}
