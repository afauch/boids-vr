using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple hover effect to give the illusion of the chessboard floating in space.
/// </summary>
public class Hover : MonoBehaviour {

	float x0;
	float y0;
	float z0;
	public float amplitude;
	public float speed;
	private float offset;

	void Start () {

		offset = Random.Range(0.0f,1.0f);
		x0 = transform.position.x;
		y0 = transform.position.y;
		z0 = transform.position.z;

	}

	void Update () {

		Vector3 pos = transform.position;
		pos = new Vector3(
			x0 + (1.1f*amplitude)*Mathf.Sin(speed*(Time.time + offset)),
			y0 + (1.2f*amplitude)*Mathf.Sin(speed*(Time.time + offset)),
			z0 + (1.3f*amplitude)*Mathf.Sin(speed*(Time.time + offset)));
		transform.position = pos;
	}

}
