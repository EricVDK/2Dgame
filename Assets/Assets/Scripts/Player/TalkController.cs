using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkController : MonoBehaviour {

	void OnTriggerStay2D(Collider2D col){
		
		if (Input.GetKeyDown (KeyCode.Q)) {
			
			if (col.gameObject.tag == "TalkBox") {
				col.gameObject.transform.parent.GetComponent<RPGTalk> ().NewTalk();

			}
		}
	}
}
