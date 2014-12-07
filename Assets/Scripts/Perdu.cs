using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Perdu : MonoBehaviour {

    public Text textePerdu;
    public bool aPerdu { get; set; }

    public void aGagne(EntityBehaviour player)
    {
        int teamWin = player.GetTeam();
        if (teamWin == 1)
            textePerdu.text = "Vous avez gagné";
        else
            textePerdu.text = "Vous avez perdu";
        aPerdu = teamWin == 2;
    }
}
