using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeasureTime : MonoBehaviour
{
    public CarController player1, player2;
    public TriggerVolume zone1, zone2, zone3;
    private TriggerVolume currentZoneP1, currentZoneP2;
    private int zonesPassedP1 = 0;
    private int zonesPassedP2 = 0;
    public Text P1SCore, P2Score;


    void Start()
    {
        currentZoneP1 = zone3;
        currentZoneP2 = zone3;
    }

    private void Update()
    {
        P1SCore.text = zonesPassedP1.ToString();
        P2Score.text = zonesPassedP2.ToString();
    }

    public void TriggerPassed(TriggerVolume trigger, CarController player)
    {
        if (player == player1)
        {
            if (trigger == zone1 && currentZoneP1 == zone3)
                UpdateTrigger(trigger, player);
            if (trigger == zone2 && currentZoneP1 == zone1)
                UpdateTrigger(trigger, player);
            if (trigger == zone3 && currentZoneP1 == zone2)
                UpdateTrigger(trigger, player);
         //   Debug.Log("Player 1 passed " + zonesPassedP1);
        }
        if (player == player2)
        {
            if (trigger == zone1 && currentZoneP2 == zone3)
                UpdateTrigger(trigger, player);
            if (trigger == zone2 && currentZoneP2 == zone1)
                UpdateTrigger(trigger, player);
            if (trigger == zone3 && currentZoneP2 == zone2)
                UpdateTrigger(trigger, player);
         //   Debug.Log("Player 2 passed " + zonesPassedP2);
        }
    }

    private void UpdateTrigger(TriggerVolume trigger, CarController player)
    {
        if (player == player1)
        {
            currentZoneP1 = trigger;
            zonesPassedP1++;
        }
        if (player == player2)
        {
            currentZoneP2 = trigger;
            zonesPassedP2++;
        }
    }
}
