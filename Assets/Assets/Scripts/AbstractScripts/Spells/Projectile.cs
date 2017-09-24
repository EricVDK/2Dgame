using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : Spell {

	/// <summary>
	/// For AoE spells that activate on hit, use Physics2D.OverlapCircle and iterate through the 'results' array to look for enemies
	/// </summary>

	public Vector2 position;
	public Vector2 aim;
	public float range;
	public float spellSpeed;
	float lifetime;
	float lifetimer;

	public void setPosition(Vector2 pos){
		position = pos;
	}


	public void setAim(Vector2 aim){
		this.aim = aim;
	}

	public void calculateRange(){
		lifetime =  range/spellSpeed;
		lifetimer = lifetime;
	}

	public void decrementLifetime(){
		lifetimer -= Time.deltaTime;
		if (lifetimer < 0) {
			Destroy (gameObject);
		}
	}

	public void rangeTimer(){
		
	}

	/// <summary>
	/// To set up a new projectile spell in a concrete class, first define and override for method : enemyHitBehavior(Enemy e)
	/// Then, make sure OnTriggerEnter2D(Collider2D col){} contains the following line : onEnemyHit(col); 
	/// </summary>


	public void onEnemyHit(Collider2D col){
		if (col.gameObject.tag == "EnemyHitBox") {
			Enemy e = col.gameObject.transform.parent.gameObject.GetComponent<Enemy> ();
			enemyHitBehavior (e);
			Destroy (gameObject);
		}

	}


	//specify what unique behaviors happen upon collision with an enemy
	// apply a debuff here if the spell is supposed to have an associated debuff
	public abstract void enemyHitBehavior (Enemy e);

}
