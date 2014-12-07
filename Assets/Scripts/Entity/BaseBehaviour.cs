using UnityEngine;
using System.Collections;

public class BaseBehaviour : EntityBehaviour {

    public ParticleSystem smokeWeed;

    public override void Start()
    {
        base.Start();
        smokeWeed.Stop();
    }

    internal override void RecoitAttaque(float attaque) 
    {
        base.RecoitAttaque(attaque);
        if((vie / vieDebut) < 0.33f)
            smokeWeed.Play();

        if(!EstVivant())
            perdu.aGagne(this);
    }
}
