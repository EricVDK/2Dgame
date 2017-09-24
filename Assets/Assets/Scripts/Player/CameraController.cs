using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Camera camera;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void LateUpdate () {
		camera.transform.position = new Vector3 (transform.position.x, transform.position.y, camera.transform.position.z);
	}
}

