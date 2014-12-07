using UnityEngine;
using System.Collections;

public abstract class EntityBehaviour : MonoBehaviour {

    public float vie = 10;
    public Perdu perdu;
    protected float vieDebut;

    public virtual void Start()
    {
        vieDebut = vie;
    }

    internal bool EstVivant()
    {
        return vie > 0;
    }

    internal virtual void RecoitAttaque(float attaque)
    {
        vie -= attaque;
        BarreDeVie barreDeVie = gameObject.GetComponentInChildren<BarreDeVie>();
        barreDeVie.updateScale(vie, vieDebut);
    }

    public int GetTeam()
    {
        if (tag.Contains("2"))
            return 2;
        else 
            return 1;
    }
}
