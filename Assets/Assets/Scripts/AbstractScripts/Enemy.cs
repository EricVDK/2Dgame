using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Creature {
	public Rigidbody2D rb;
	public PlayerController player;
	public bool attacking;
		
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void followLocation(Vector2 v){
		rb.velocity = (v - rb.position).normalized * speed;
	}

	public void trackPlayer(float minDistance, float maxDistance){
		float currentDistance = (player.GetComponent<Rigidbody2D> ().position - rb.position).magnitude;
		if (currentDistance > minDistance && currentDistance < maxDistance) {
			followLocation (player.transform.position);
		} else {
			//rb.velocity = new Vector2 (0f, 0f);
			rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, 0.05f),
				Mathf.Lerp(rb.velocity.y, 0, 0.05f));
		}
	}
}
