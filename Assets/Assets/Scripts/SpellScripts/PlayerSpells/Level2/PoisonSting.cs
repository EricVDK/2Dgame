using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSting : Projectile {

	public float damage;


	// Use this for initialization
	void Start () {
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
		e.takeDmg (damage);

		if (checkExist (e, e.effectList, "PoisonStingEffect", true)) {
			//
		} else {

			PoisonStingEffect debuff = new PoisonStingEffect ();
			debuff.victim = e;
			e.effectList.Add (debuff);
		}
	}


}

