using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public Vector3 rotationRate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		gameObject.transform.Rotate (rotationRate);

	}
}
