using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expolosive : MonoBehaviour
{
    private float range = 500000f;
    public GameObject explo;
    private ParticleSystem particle;

    void OnCollisionStay(Collision other)
    {
        
        if (other.gameObject.name == "Car1" || other.gameObject.name == "Car2")
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(-range, range), Random.Range(range/2f, range), Random.Range(-range, range));
            other.gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(Random.Range(-range, range), Random.Range(-range, range),Random.Range(-range, range)));
            Instantiate(explo, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
