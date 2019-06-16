using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	[SerializeField] float accelerationForward = 6000;
	[SerializeField] float accelerationBackward = 3000;
	[SerializeField] float rotationSpeed = 30;
	[SerializeField] float breakForce = 2;
	[SerializeField] float angularDragMax = 1;
    public float handBrakeFactorMax = 2f;
    private float handBrakeFactor = 1f;
    public float maxSpeed = 2f;
	private float neutralDrag;  
	public AudioSource EngineSound;
	public bool drawGizmo = false;

	Vector3 EulerAngleVelocity;
	Rigidbody _rigidbody;
    Vector3 lastPosition;
    float _sideSlipAmount = 0;
    private bool touchingGround = false;
    private string horizontal, vertical, reset, breaks;
    private float actualPitchSound = 1f;
    private bool changingSpeed = false;
    private float coolDown;
    private float originalSpeed;

    public float SideSlipAmount
    {
        get
        {
            return _sideSlipAmount;
        }
    }

    private void SetSideSlip()
    {
        Vector3 direction = transform.position - lastPosition;
        Vector3 movement = transform.InverseTransformDirection(direction);
        lastPosition = transform.position;

        _sideSlipAmount = movement.x;
    }

	void Start () {
		_rigidbody = GetComponent<Rigidbody>();
        neutralDrag = _rigidbody.drag;
        originalSpeed = accelerationForward;
        EulerAngleVelocity = new Vector3(0, rotationSpeed, 0);
        // setting inputs
        if(_rigidbody.name == "Car1")
        {
            horizontal = "Horizontal1";
            vertical = "Vertical1";
            reset = "reset1";
            breaks = "break1";
        }
        if (_rigidbody.name == "Car2")
        {
            horizontal = "Horizontal2";
            vertical = "Vertical2";
            reset = "reset2";
            breaks = "break2";
        }
    }
	
	void Update () {
        if (touchingGround == true)
        {
            if (Input.GetButton(breaks))
            {
                _rigidbody.drag = breakForce;
                handBrakeFactor = handBrakeFactorMax;
            }

            if (Input.GetButtonUp(breaks))
            {
                _rigidbody.drag = neutralDrag;
                handBrakeFactor = 1f;
            }
        }

        if (changingSpeed == true)
        {
            coolDown -= Time.deltaTime;
            if (coolDown < 0)
            {
                changingSpeed = false;
                accelerationForward = originalSpeed;
            }
        }
        
		float engineSoundPitch = Mathf.Abs((float)Input.GetAxis (vertical) * 1.4f) + .6f; // Engine Sound
        if (engineSoundPitch > actualPitchSound)
            actualPitchSound += 0.01f;
        else actualPitchSound -= 0.01f;
        EngineSound.pitch = actualPitchSound;
        SetSideSlip();
	}

	void FixedUpdate ()
    {
		float v = Input.GetAxis (vertical);
		float h = Input.GetAxis (horizontal);
        if (touchingGround == true)
        {
            if (v >= 0)
            {
                EulerAngleVelocity.y = Mathf.Lerp(0, rotationSpeed * h * handBrakeFactor, _rigidbody.velocity.magnitude / 30f);

                Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * Time.deltaTime);
                //Debug.Log(_rigidbody.rotation);
                _rigidbody.AddRelativeForce(Vector3.forward * accelerationForward * v);
                _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
            }
            else
            {
                EulerAngleVelocity.y = Mathf.Lerp(0, -rotationSpeed * h * handBrakeFactor, _rigidbody.velocity.magnitude / 30f);
                Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * Time.deltaTime);
                _rigidbody.AddRelativeForce(Vector3.forward * accelerationBackward * v);
                _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
            }
        }
	}

    private Vector3 ForwardVelocity()
    {
        return new Vector3(0, 0, 0);
    }

    public void ResetCarRotation()
    {
        _rigidbody.rotation = Quaternion.identity;
        _rigidbody.position += new Vector3(0, 3, 0);
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        touchingGround = true;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        touchingGround = false;            
    }

    public void ChangeSpeed(float powerUp, float coolDown)
    {
        changingSpeed = true;
        accelerationForward = powerUp;
        this.coolDown = coolDown;
    }

    // ---------------------------------------------------------------------------------------
    // Tu ju¿ s¹ pierdo³y

    void OnDrawGizmos()
    {
        if (drawGizmo == true)
        {
            Gizmos.color = Color.red;
            Vector3 direction = transform.TransformDirection(Vector3.forward) * 20;
            Gizmos.DrawRay(transform.position, direction);
            Vector4 colorA = new Vector4(0, 0, 1, 0.4f);
            Gizmos.color = colorA;
            Gizmos.DrawSphere(transform.position, 6);
        }
    }
}