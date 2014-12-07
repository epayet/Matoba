using UnityEngine;
using System.Collections;

public class BarreDeVie : MonoBehaviour {

    public GameObject JauneWrapper;

    internal void updateScale(float vie, float vieDebut)
    {
        JauneWrapper.transform.localScale = new Vector3(vie/vieDebut, 1.0f, 1.0f);
    }
}
