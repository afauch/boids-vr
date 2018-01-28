using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;

	void OnMouseDown(){

		if(Input.GetKey(KeyCode.LeftAlt)) {
			return;
		}

		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag(){

		if(Input.GetKey(KeyCode.LeftAlt)) {
			return;
		}

		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
	}

}