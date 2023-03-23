using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePrinter : MonoBehaviour
{
    public PlayerController playerCtrl;
    public TextMeshProUGUI scoreUI;

    // Update is called once per frame
    void Update()
    {
        this.scoreUI.text = this.playerCtrl.distanceTraveled.ToString() + " m";
    }
}
