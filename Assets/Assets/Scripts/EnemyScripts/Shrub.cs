using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrub : Enemy {


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<PlayerController>();
		Rigidbody2D playerRb = player.GetComponent<Rigidbody2D> ();
		rb = GetComponent<Rigidbody2D> ();
		attacking = false;
		InvokeRepeating ("regenHealth", 0f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		checkDeath ();
		updateStatusEffects (effectList);
		updateStatusEffects (buffList);
		updateRenderOrder ();


		trackPlayer (3f,10f);

	}


	public void OnCollisionExit2D(Collision2D col){
		rb.velocity = new Vector2 (0f, 0f);
	}


}
