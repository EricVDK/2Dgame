using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpeed : StatusEffect {

	public float speedBoost;
	public float radius;
	public bool once;


	public BonusSpeed(){
		speedBoost = 2;
		id = "HealthRegen";
		once = true;
	}



	public override void applyEffect(){
		if (once) {
			target.speed += speedBoost;
			once = false;
		}
	}

	public override void reverseEffect(){
		target.speed -= speedBoost;

	}

	public override bool Equals(object obj){
		return base.Equals (obj);

	}
}
