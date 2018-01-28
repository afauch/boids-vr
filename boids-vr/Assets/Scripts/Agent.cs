using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

	public Vector3 _loc;
	public Vector3 _vel;

	public float _maxSpeed;
	public float _maxForce;

	public Vector3 _acc = Vector3.zero;

	List<Vector3> _prevLocs;

	public GameObject _targetObject;
	public Vector3 _target;

    public bool _useCustomSpeed;
	public float _updateSpeed = 0.05f;

	// Use this for initialization
	void Start () {

		// Subscribe to 'Reset' event
		BoidsManager.instance.ResetEvent.AddListener(Reset);

		// initalize _vel with randoms
		_vel = new Vector3 (Random.Range (-10.0f, 10.0f), Random.Range (-10.0f, 10.0f), Random.Range (-10.0f, 10.0f));

		// initialize list
		_prevLocs = new List<Vector3>();

		// set _loc
		_loc = this.gameObject.transform.position;

		// add to list
		_prevLocs.Add(_loc);

        // Only use this if you want to override regular update
        if (_useCustomSpeed)
        {
            InvokeRepeating("BoidUpdate", 0.0f, _updateSpeed);
        }

	}

    void Update()
    {
        if (!_useCustomSpeed)
        {
            BoidUpdate();
        }
    }

    void BoidUpdate () {

		_target = _targetObject.transform.position;

		Vector3 seekVec = Seek (_target);
		_maxSpeed = _maxSpeed;
		_maxForce = _maxForce;

		ApplyForce (seekVec);

		_vel = _acc + _vel;
		_vel = Limit (_vel, _maxSpeed);
		_loc = _loc + _vel;

		this.transform.position = _loc;
		this.transform.LookAt (_target);

		_prevLocs.Add (_loc);

	}

	Vector3 Seek (Vector3 target)
	{
		Vector3 desired = target - _loc;
		desired = Limit (desired, _maxSpeed);
		return Steer (desired);
	}

	Vector3 Steer (Vector3 desired)
	{
		Vector3 steerVec = desired - _vel;
		steerVec = Limit (steerVec, _maxForce);
		return steerVec;
	}

	Vector3 Limit (Vector3 vec, float limit)
	{
		if (vec.magnitude > limit) 
		{
			Vector3.Normalize (vec);
			vec = limit * vec;
		}
		return vec;
	}

	void ApplyForce (Vector3 vec)
	{
		_acc = vec + _acc;
	}

	void Reset() {

		Debug.Log ("Reset Called from agent.");

		// Any logic necessary for agents to understand clearing

	}


}
