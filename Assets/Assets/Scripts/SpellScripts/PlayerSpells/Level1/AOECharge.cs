using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOECharge : Projectile {

	public float damage;
	PlayerController p;

	public int threshold;
	public float blastRadius;
	public float blastDmg;


	// Use this for initialization
	void Start () {
		calculateRange ();
		p = GameObject.Find ("Player").GetComponent<PlayerController> ();
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
		Debug.Log(p.buffList.Count);
		e.takeDmg (damage);
		if (addStack<AOEChargeEffect> (p, p.buffList, "AOEChargeEffect") >= threshold) {

			Collider2D[] c = Physics2D.OverlapCircleAll (transform.position, blastRadius, 9);

			for (int i = 0; i < c.Length; i++) {
				if (c [i].tag == "EnemyHitBox") {
					Enemy nearbyE = c[i].gameObject.transform.parent.gameObject.GetComponent<Enemy> ();
					nearbyE.takeDmg (blastDmg);
				}
			}

			for (int i = 0; i < p.buffList.Count; i++) {
				if (p.buffList [i].id.Equals("AOEChargeEffect")) {
					p.buffList [i].isActive = false;
				}
			}
		}
	}
}
