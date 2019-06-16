using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolume : MonoBehaviour
{
    public MeasureTime measureTime;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered Trigger");
        if (other.name == "Car1" || other.name == "Car2")
        {
            measureTime.TriggerPassed(this, other.GetComponent<CarController>());
        }
    }
}
