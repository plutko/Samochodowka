using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour {

	public Transform observeable;
	[SerializeField] float aheadSpeed;
	[SerializeField] float followDamping;
	[SerializeField] float cameraHeight;
    [SerializeField] float speedFactor = 80f;

    Rigidbody _observableRigidbody; 

	// Use this for initialization
	void Start () {
		_observableRigidbody = observeable.GetComponent<Rigidbody>();
        //Debug.Log(runGame.GetCar1().name);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (observeable.transform == null)
		{
			return;
		}
		
		Vector3 targetPosition = observeable.transform.position + Vector3.up * cameraHeight * (Mathf.Abs(_observableRigidbody.velocity.magnitude) / speedFactor + 1) + _observableRigidbody.velocity * aheadSpeed;
		transform.position = Vector3.Lerp(transform.position, targetPosition, followDamping * Time.deltaTime);
	}
}
