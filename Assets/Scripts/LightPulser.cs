using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulser : MonoBehaviour
{
    private Light lightObject;
    public float phase = 10f;
    public float maxIntensity = 2f;
    // Start is called before the first frame update
    void Start()
    {
        lightObject = GetComponent<Light>(); 
    }

    // Update is called once per frame
    void Update()
    {
        lightObject.intensity = ((Mathf.Sin(phase * Time.time) / 2f) + 0.5f) * maxIntensity;
    }
}
