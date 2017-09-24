using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Spell {
	
	public float healAmount;


	void Start(){
	}

	public override void castSpell(){
		player = GameObject.Find ("Player").GetComponent<PlayerController>();

		player.health += healAmount;
		if (player.health > player.maxHealth) {
			player.health = player.maxHealth;
		}
	
	
		Destroy (gameObject);
	}


}
