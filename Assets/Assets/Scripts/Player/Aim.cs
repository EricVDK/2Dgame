using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

	public Transform target; 

	//anything

	public float speed;
	public float fRadius = 3.0f;
	public float targetAngle;
	public float currentAngle;

	float x;
	float y;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {/*
		Vector3 mousePosition2D = Camera.main.WorldToScreenPoint (target.position);
		mousePosition2D = Input.mousePosition - mousePosition2D;

		currentAngle = Mathf.Atan2 (transform.position.y, transform.position.x) * Mathf.Rad2Deg;

		targetAngle = Mathf.Atan2 (mousePosition2D.y, mousePosition2D.x) * Mathf.Rad2Deg;

		mousePosition2D = Quaternion.AngleAxis (targetAngle, Vector3.forward) * (Vector3.right * fRadius);
		//Debug.Log (mousePosition2D);
		transform.position = target.position + mousePosition2D;
*/

		Vector3 targetScreenPos = Camera.main.WorldToScreenPoint (target.position);
		targetScreenPos.z = 0;
		Vector3 targetToMouseDir = Input.mousePosition - targetScreenPos;

		Vector3 targetToMe = transform.position - target.position;
		targetToMe.z = 0;

		Vector3 newTargetToMe = Vector3.RotateTowards(targetToMe, targetToMouseDir, speed, 0f);

		transform.position = target.position + 1f * newTargetToMe.normalized;


		transform.eulerAngles = new Vector3 (0f, 0f, (-180f/Mathf.PI) * Mathf.Atan2(targetToMe.x, targetToMe.y));
	}
}
