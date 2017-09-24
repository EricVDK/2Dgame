using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapHealth : Projectile {



	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<PlayerController>();
		calculateRange ();
	}
	
	// Update is called once per frame
	void Update () {
		decrementLifetime ();
	}

	public override void castSpell(){
		transform.position = position;
		GetComponent<Rigidbody2D> ().velocity = spellSpeed * aim.normalized;
	}

	void OnTriggerEnter2D (Collider2D col){
		onEnemyHit (col);
	}

	public override void enemyHitBehavior(Enemy e){

		float enemyPercent = e.health / e.maxHealth;
		float playerPercent = player.health / player.maxHealth;

		player.health = enemyPercent * player.maxHealth;
		e.health = playerPercent * e.maxHealth;
	}
}
