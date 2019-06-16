using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

	public float MotorForce;
	public WheelCollider WheelFL;
	public WheelCollider WheelFR;
	public WheelCollider WheelBL;
	public WheelCollider WheelBR;
	public float SteerForce;
	public float BreakForce;

	public AudioSource EngineSound;

	public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {   
    	rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {        
    	float v = Input.GetAxis ("Vertical") * MotorForce;
    	float h = Input.GetAxis ("Horizontal") * SteerForce;

    	WheelFL.motorTorque = v;
    	WheelFR.motorTorque = v;

    	WheelFL.steerAngle = h;
    	WheelFR.steerAngle = h;

    	if (Input.GetKey(KeyCode.JoystickButton2))
    	{

    		WheelBL.brakeTorque = BreakForce;
    		WheelBR.brakeTorque = BreakForce;
    	}

    	if (Input.GetKeyUp(KeyCode.JoystickButton2))
    	{
    		WheelBL.brakeTorque = 0;
    		WheelBR.brakeTorque = 0;
    	}

    	//float minSoundPitch = .6f;
    	//float maxSoundPitch = 1.9f;
    	float engindSoundPitch = Mathf.Abs((float)Input.GetAxis ("Vertical") * 1.4f) + .6f; 
    	EngineSound.pitch = engindSoundPitch;

    	float speed = rb.velocity.magnitude; 
    	 //   		Debug.Log(speed);
    }
}
     