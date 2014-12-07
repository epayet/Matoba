using UnityEngine;
using System.Collections;

public abstract class EntityBehaviour : MonoBehaviour {

    public float vie = 10;
    public Perdu perdu;

    internal bool EstVivant()
    {
        return vie > 0;
    }

    internal virtual void RecoitAttaque(float attaque)
    {
        vie -= attaque;
    }

    public int GetTeam()
    {
        if (tag.Contains("2"))
            return 2;
        else 
            return 1;
    }
}
