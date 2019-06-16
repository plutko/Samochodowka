using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpeed : MonoBehaviour
{

    public float powerUp;
    public float coolDown;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered Trigger");
        if (other.name == "Car1" || other.name == "Car2")
        {
            other.GetComponent<CarController>().ChangeSpeed(powerUp, coolDown);
        }
    }
}

