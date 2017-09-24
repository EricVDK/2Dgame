using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackingDamage : Projectile {
	
	public float damage;
	public float bonusDamagePerStack = 3;



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
		e.takeDmg(damage + bonusDamagePerStack * addStack<StackingDamageEffect> (e, e.effectList, "stacking"));
}

}