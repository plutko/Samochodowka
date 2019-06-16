using UnityEngine;
using System.Collections;

public class WheelSkid : MonoBehaviour
{
    public float intensityModifier = 1.5f;

    Skidmarks skidMarkController;
    CarController playerCar;

    int lastSkidId = -1;

    void Start()
    {
        skidMarkController = FindObjectOfType<Skidmarks>();
        playerCar = GetComponentInParent<CarController>();
    }

    void LateUpdate()
    {
        float intensity = playerCar.SideSlipAmount;
        if (intensity < 0)
            intensity = -intensity;

        if (intensity > 0.3f)
        {
            lastSkidId = skidMarkController.AddSkidMark(transform.position, transform.right, intensity * intensityModifier, lastSkidId);
        }
        else
        {
            lastSkidId = -1;
        }
    }
}
