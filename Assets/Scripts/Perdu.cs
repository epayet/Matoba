using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Perdu : MonoBehaviour {

    public Text textePerdu;
    public bool aPerdu { get; set; }
    public bool fini;

    public void aGagne(EntityBehaviour player)
    {
        int teamWin = player.GetTeam();
        if (teamWin == 2)
            textePerdu.text = "Vous avez gagné";
        else
            textePerdu.text = "Vous avez perdu";
        aPerdu = teamWin == 2;
        fini = true;
    }
}
